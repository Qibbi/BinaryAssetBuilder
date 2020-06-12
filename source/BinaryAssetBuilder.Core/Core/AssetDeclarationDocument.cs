using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    // TODO:
    [Serializable]
    public class AssetDeclarationDocument : IXmlSerializable
    {
        private class XmlNodeWithMetaData
        {
            public XmlNode Node;
            public int LineNumber;

            public XmlNodeWithMetaData(XmlNode node, int line)
            {
                Node = node;
                LineNumber = line;
            }

            public bool Equals(XmlNodeWithMetaData other)
            {
                return Node.Equals(other.Node);
            }
        }

        private class DependencyComparer : IComparer<InstanceDeclaration>
        {
            public int Compare([AllowNull] InstanceDeclaration x, [AllowNull] InstanceDeclaration y)
            {
                if (x is null || y is null)
                {
                    throw new ArgumentNullException();
                }
                if (y.AllDependentInstances.Count != x.AllDependentInstances.Count)
                {
                    return x.AllDependentInstances.Count.CompareTo(y.AllDependentInstances.Count);
                }
                bool a = y.AllDependentInstances != null && y.AllDependentInstances.Contains(x.Handle);
                bool b = x.AllDependentInstances != null && x.AllDependentInstances.Contains(y.Handle);
                if (a)
                {
                    if (b)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.CircularDependency,
                                                              "Illegal circular dependency found between {0} and {1}. This should have been caught during parsing.",
                                                              x,
                                                              y);
                    }
                    return -1;
                }
                return b ? 1 : string.Compare(x.Handle.TypeName, y.Handle.TypeName);
            }
        }

        private class TypeDepComapre : IComparer<InstanceDeclaration>
        {
            private readonly IDictionary<uint, int> _typeDependencies;

            public TypeDepComapre(IDictionary<uint, int> typeDependencies)
            {
                _typeDependencies = typeDependencies;
            }

            public int Compare([AllowNull] InstanceDeclaration x, [AllowNull] InstanceDeclaration y)
            {
                int result = _typeDependencies[x.Handle.TypeId].CompareTo(_typeDependencies[y.Handle.TypeId]);
                if (result != 0)
                {
                    return result;
                }
                result = string.Compare(x.Handle.TypeName, y.Handle.TypeName);
                return result == 0 ? string.Compare(x.Handle.InstanceName, y.Handle.InstanceName) : result;
            }
        }

        [Serializable]
        private class LastState : IXmlSerializable
        {
            public uint DocumentHash;
            public uint DependentFileHash;
            public List<string> DependentFiles;
            public uint IncludePathHash;
            public List<InclusionItem> InclusionItems;
            public List<OutputAsset> OutputAssets;
            public List<Definition> SelfDefines;
            public List<InstanceDeclaration> SelfInstances;
            public List<DefinitionPair> UsedDefines;
            public List<string> StreamHints;

            public LastState()
            {
            }

            public LastState(CurrentState current)
            {
                DocumentHash = current.DocumentHash;
                IncludePathHash = current.IncludePathHash;
                InclusionItems = current.InclusionItems.Count > 0 ? new List<InclusionItem>(current.InclusionItems) : null;
                DependentFileHash = current.DependentFileHash;
                DependentFiles = current.DependentFiles.Count > 0 ? new List<string>(current.DependentFiles) : null;
                OutputAssets = current.OutputAssets.Count > 0 ? new List<OutputAsset>(current.OutputAssets) : null;
                SelfDefines = current.SelfDefines.Count > 0 ? new List<Definition>(current.SelfDefines) : null;
                SelfInstances = current.SelfInstances.Count > 0 ? new List<InstanceDeclaration>(current.SelfInstances) : null;
                List<DefinitionPair> list = new List<DefinitionPair>();
                foreach (KeyValuePair<string, string> usedDefine in current.UsedDefines)
                {
                    list.Add(new DefinitionPair
                    {
                        Name = usedDefine.Key,
                        EvaluatedValue = usedDefine.Value
                    });
                }
                UsedDefines = new List<DefinitionPair>(list);
                StreamHints = current.StreamHints.Count > 0 ? new List<string>(current.StreamHints) : null;
            }

            private void ReadOldStrings(XmlReader reader)
            {
                string[] sValues = XmlHelper.ReadStringArrayElement(reader, "s");
                string[] pValues = XmlHelper.ReadStringArrayElement(reader, "p");
                if (sValues != null)
                {
                    foreach (string stringhash in sValues)
                    {
                        HashProvider.RecordHash(HashProvider.StringHashTableName, stringhash);
                    }
                }
                if (pValues != null)
                {
                    foreach (string poid in pValues)
                    {
                        HashProvider.RecordHash(HashProvider.PoidTableName, poid);
                    }
                }
            }

            public XmlSchema GetSchema()
            {
                return null;
            }

            public void ReadXml(XmlReader reader)
            {
                reader.MoveToAttribute("d");
                string[] values = reader.Value.Split(';');
                DocumentHash = Convert.ToUInt32(values[0]);
                DependentFileHash = Convert.ToUInt32(values[1]);
                IncludePathHash = Convert.ToUInt32(values[2]);
                reader.Read();
                if (!reader.IsStartElement())
                {
                    return;
                }
                ReadOldStrings(reader);
                object obj = XmlHelper.ReadStringArrayElement(reader, "sf");
                DependentFiles = obj is null ? null : new List<string>(obj as string[]);
                obj = XmlHelper.ReadStringArrayElement(reader, "dsf");
                StreamHints = obj is null ? null : new List<string>(obj as string[]);
                obj = XmlHelper.ReadCollection(reader, "iic", typeof(InclusionItem));
                InclusionItems = obj is null ? null : new List<InclusionItem>(obj as InclusionItem[]);
                obj = XmlHelper.ReadCollection(reader, "oac", typeof(OutputAsset));
                OutputAssets = obj is null ? null : new List<OutputAsset>(obj as OutputAsset[]);
                obj = XmlHelper.ReadCollection(reader, "sdc", typeof(Definition));
                SelfDefines = obj is null ? null : new List<Definition>(obj as Definition[]);
                obj = XmlHelper.ReadCollection(reader, "sic", typeof(InstanceDeclaration));
                SelfInstances = obj is null ? null : new List<InstanceDeclaration>(obj as InstanceDeclaration[]);
                obj = XmlHelper.ReadCollection(reader, "udc", typeof(DefinitionPair));
                UsedDefines = obj is null ? null : new List<DefinitionPair>(obj as DefinitionPair[]);
                reader.Read();

            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("ad");
                writer.WriteAttributeString("d", $"{DocumentHash};{DependentFileHash};{IncludePathHash}");
                XmlHelper.WriteStringArrayElement(writer, "sf", DependentFiles?.ToArray());
                XmlHelper.WriteStringArrayElement(writer, "dsf", StreamHints?.ToArray());
                XmlHelper.WriteCollection(writer, "iic", InclusionItems);
                XmlHelper.WriteCollection(writer, "oac", OutputAssets);
                XmlHelper.WriteCollection(writer, "sdc", SelfDefines);
                XmlHelper.WriteCollection(writer, "sic", SelfInstances);
                XmlHelper.WriteCollection(writer, "udc", UsedDefines);
                writer.WriteEndElement();
            }
        }

        private class CurrentState
        {
            public List<InstanceDeclaration> OutputInstances = new List<InstanceDeclaration>();
            public DefinitionSet AllDefines = new DefinitionSet();
            public InstanceSet Instances = new InstanceSet();
            public InstanceSet AllInstances = new InstanceSet();
            public InstanceSet TentativeInstances = new InstanceSet();
            public InstanceSet ReferenceInstances = new InstanceSet();
            public StringDictionary Tags = new StringDictionary();
            public List<OutputAsset> OutputAssets = new List<OutputAsset>();
            public uint DocumentHash;
            public string SourcePath;
            public string SourceDirectory;
            public string SourcePathFromRoot;
            public string LogicalSourcePath;
            public uint DependentFileHash;
            public uint IncludePathHash;
            public uint OutputChecksum;
            public bool IsLoaded;
            public bool Processing;
            public string ChangeReason;
            public bool Changed;
            public DocumentState State;
            public List<Definition> SelfDefines;
            public InstanceSet SelfInstances;
            public List<string> DependentFiles;
            public List<InclusionItem> InclusionItems;
            public IDictionary<string, string> UsedDefines;
            public bool VerificationErrors;
            public FileHashItem HashItem;
            public XmlDocument XmlDocument;
            public XmlNamespaceManager NamespaceManager;
            public DocumentProcessor DocumentProcessor;
            public List<string> StreamHints;
            public LinkedList<XmlNodeWithMetaData> NodeSourceInfoSet;
            public IDictionary<InstanceHandle, InstanceDeclaration> OutputInstanceSet;
            public XmlReader XmlReader;
            public string ConfigurationName;
            public List<OutputAsset> LastOutputAssets;
            public uint LastDocumentHash;
            public uint LastDependentFileHash;
            public uint LastIncludePathHash;

            public CurrentState()
            {
            }

            public CurrentState(DocumentProcessor documentProcessor, FileHashItem hashItem, string logicalSourcePath, string configuration)
            {
                DocumentProcessor = documentProcessor;
                HashItem = hashItem;
                SourcePath = hashItem.Path;
                LogicalSourcePath = logicalSourcePath;
                SourceDirectory = Path.GetDirectoryName(SourcePath);
                DocumentHash = HashItem.Hash;
                ConfigurationName = configuration;
                string dataRoot = FileNameResolver.GetDataRoot(SourcePath);
                if (!string.IsNullOrEmpty(dataRoot))
                {
                    string path = SourcePath.Substring(dataRoot.Length + 1);
                    SourcePathFromRoot = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(SourcePath));
                    LogicalSourcePath = "DATA:" + path.Replace('\\', '/');
                }
                else
                {
                    SourcePathFromRoot = Path.GetFileNameWithoutExtension(SourcePath);
                }
            }

            public void FromLast(AssetDeclarationDocument document, LastState last)
            {
                InclusionItems = last.InclusionItems != null ? new List<InclusionItem>(last.InclusionItems) : new List<InclusionItem>();
                DependentFiles = last.DependentFiles != null ? new List<string>(last.DependentFiles) : new List<string>();
                StreamHints = last.StreamHints != null ? new List<string>(last.StreamHints) : new List<string>();
                UsedDefines = new SortedDictionary<string, string>();
                if (last.UsedDefines != null)
                {
                    foreach (DefinitionPair usedDefine in last.UsedDefines)
                    {
                        UsedDefines[usedDefine.Name] = usedDefine.EvaluatedValue;
                    }
                }
                SelfDefines = last.SelfDefines != null ? new List<Definition>(last.SelfDefines) : new List<Definition>();
                foreach (Definition selfDefine in SelfDefines)
                {
                    selfDefine.Document = document;
                }
                SelfInstances = last.SelfInstances != null ? new InstanceSet(document, last.SelfInstances) : new InstanceSet();
                Changed = (int)last.DocumentHash != (int)DocumentHash;
                LastOutputAssets = last.OutputAssets;
                LastDocumentHash = last.DocumentHash;
                LastIncludePathHash = last.IncludePathHash;
                LastDependentFileHash = last.DependentFileHash;
                State = DocumentState.Shallow;
            }

            public void FromScratch()
            {
                InclusionItems = new List<InclusionItem>();
                DependentFiles = new List<string>();
                UsedDefines = new SortedDictionary<string, string>();
                SelfDefines = new List<Definition>();
                SelfInstances = new InstanceSet();
                StreamHints = new List<string>();
                State = DocumentState.None;
            }
        }

        private static Tracer _tracer = Tracer.GetTracer(nameof(AssetDeclarationDocument), "Provides Xml processing functionality");

        private LastState _last;
        [NonSerialized] private CurrentState _current;
        [NonSerialized] private bool _procesing;

        [NonSerialized] public bool ReloadForInheritance;

        public FileHashItem HashItem => _current.HashItem;
        public List<OutputAsset> LastOutputAssets => _current.LastOutputAssets;
        public string SourcePathFromRoot => _current.SourcePathFromRoot;
        public string SourcePath => _current.SourcePath;
        public InstanceSet SelfInstances => _current.SelfInstances;
        public List<Definition> SelfDefines => _current.SelfDefines;
        public List<InclusionItem> InclusionItems => _current.InclusionItems;
        public string LogicalSourcePath => _current.LogicalSourcePath;
        public uint OutputChecksum => _current.OutputChecksum;
        public bool IsLoaded => _current.IsLoaded;
        public DefinitionSet AllDefines => _current.AllDefines;
        public IDictionary<string, string> UsedDefines => _current.UsedDefines;
        public List<InstanceDeclaration> OutputInstances => _current.OutputInstances;
        public InstanceSet Instances => _current.Instances;
        public InstanceSet AllInstances => _current.AllInstances;
        public InstanceSet TentativeInstances => _current.TentativeInstances;
        public InstanceSet ReferenceInstances => _current.ReferenceInstances;
        public DocumentState State
        {
            get => _current != null ? _current.State : DocumentState.None;
            set => _current.State = value;
        }
        public StringDictionary Tags => _current.Tags;
        public XmlDocument XmlDocument => _current.XmlDocument;
        public XmlNamespaceManager NamespaceManager => _current.NamespaceManager;
        public string SourceDirectory => _current.SourceDirectory;
        public bool VerificationErrors => _current.VerificationErrors;
        public List<string> StreamHints => _last.StreamHints;
        public bool Processing
        {
            get => _current != null && _current.Processing;
            set => _current.Processing = value;
        }

        public AssetDeclarationDocument()
        {
        }

        public AssetDeclarationDocument(DocumentProcessor documentProcessor, FileHashItem hashItem, string logicalPath, string configuration)
        {
            Open(documentProcessor, hashItem, logicalPath, configuration);
        }

        private bool TryGetFileHashItem(string logicalPath, out FileHashItem item)
        {
            return _current.DocumentProcessor.Cache.TryGetFile(FileNameResolver.ResolvePath(SourceDirectory, logicalPath),
                                                               _current.ConfigurationName,
                                                               Settings.Current.TargetPlatform,
                                                               out item);
        }

        private void UpdateDocumentHashes()
        {
            if (_current.DependentFiles.Count == 0)
            {
                _current.DependentFileHash = 0u;
            }
            else
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryWriter writer = new BinaryWriter(memoryStream);
                    foreach (string dependentFile in _current.DependentFiles)
                    {
                        if (TryGetFileHashItem(dependentFile, out FileHashItem item))
                        {
                            writer.Write(HashProvider.GetTextHash(item.Path.ToLower()));
                            writer.Write(item.Hash);
                        }
                    }
                    byte[] array = memoryStream.ToArray();
                    _current.DependentFileHash = array.Length <= 0 ? 0u : FastHash.GetHashCode(array);
                }
            }
            if (_current.InclusionItems.Count == 0)
            {
                _current.IncludePathHash = 0u;
            }
            else
            {
                _current.IncludePathHash = (uint)_current.InclusionItems.Count;
                foreach (InclusionItem inclusionItem in _current.InclusionItems)
                {
                    if (TryGetFileHashItem(inclusionItem.LogicalPath, out FileHashItem item))
                    {
                        _current.IncludePathHash = FastHash.GetHashCode(_current.IncludePathHash, item.Path.ToLower());
                    }
                }
            }
        }

        private void Load(string reason)
        {
            _current.FromScratch();
            InternalLoad(reason, true);
        }

        private void InternalLoad(string reason, bool loadFromScratch)
        {
            SetChanged(reason);
            if (State == DocumentState.Shallow)
            {
                _tracer.TraceInfo("Reloading 'file://{0}'. Reason: {1}", SourcePath, _current.ChangeReason);
            }
            else
            {
                _tracer.TraceInfo("Loading 'file://{0}'.", SourcePath);
            }
            LoadXml(loadFromScratch);
            GatherUnvalidatedTags();
            GatherDefines();
            if (!loadFromScratch)
            {
                GatherUnvalidatedIncludes();
            }
            GatherUnvalidatedInstances();
            _current.State = DocumentState.Loaded;
            _current.IsLoaded = true;
        }

        private void PrevalidatedLoad(string reason)
        {
            if (_current.State != DocumentState.Complete)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                      "Prevalidation load for {0} was cancelled because of '{1}' when document has not been previously validated",
                                                      SourcePath,
                                                      reason);
            }
            LoadXml(false);
            GatherUnvalidatedTags();
            GatherDefines();
            GatherUnvalidatedIncludes();
            GatherUnvalidatedInstances();
            _current.State = DocumentState.Loaded;
            _current.IsLoaded = true;
            ReloadForInheritance = true;
        }

        private void NodeInsertedHandler(object sender, XmlNodeChangedEventArgs args)
        {
            IXmlLineInfo xmlReader = _current.XmlReader as IXmlLineInfo;
            if (!xmlReader.HasLineInfo())
            {
                return;
            }
            _current.NodeSourceInfoSet.AddFirst(new XmlNodeWithMetaData(args.Node, xmlReader.LineNumber));
        }

        public void SetChanged(string reason)
        {
            _current.ChangeReason = reason != null || _current.ChangeReason != null ? reason : string.Empty;
            _current.Changed = true;
        }

        public void Reset()
        {
            _current.XmlDocument = null;
            if (!ReloadForInheritance)
            {
                return;
            }
            State = DocumentState.Complete;
            ReloadForInheritance = false;
        }

        public void Reinitialize(OutputManager outputManager)
        {
            if (_current.HashItem is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.DependencyCacheFailure, "File hashing information for cached document missing: {0}", _current.SourcePath);
            }
            string reason = null;
            if ((int)_current.LastDocumentHash != (int)_current.DocumentHash)
            {
                reason = "content changed";
            }
            else
            {
                UpdateDocumentHashes();
                if ((int)_current.LastDependentFileHash != (int)_current.DependentFileHash)
                {
                    reason = "dependent file changed";
                }
                else
                {
                    foreach (InstanceDeclaration selfInstance in _current.SelfInstances)
                    {
                        BinaryAsset binaryAsset = outputManager.GetBinaryAsset(selfInstance, false);
                        if (binaryAsset != null && binaryAsset.GetLocation(AssetLocation.All, AssetLocationOption.None) == AssetLocation.None)
                        {
                            reason = "previous output missing";
                            break;
                        }
                        ExtendedTypeInformation extendedTypeInformation = _current.DocumentProcessor.Plugins.GetExtendedTypeInformation(selfInstance.Handle.TypeId);
                        if ((int)selfInstance.Handle.TypeHash != (int)extendedTypeInformation.TypeHash)
                        {
                            reason = "type hash changed";
                            break;
                        }
                        if ((int)selfInstance.ProcessingHash != (int)extendedTypeInformation.ProcessingHash)
                        {
                            reason = "plugin output changed";
                            break;
                        }
                    }
                }
            }
            if (reason != null)
            {
                Load(reason);
            }
            else if ((int)_current.LastIncludePathHash != (int)_current.IncludePathHash)
            {
                foreach (InclusionItem inclusionItem in _current.InclusionItems)
                {
                    inclusionItem.PhysicalPath = FileNameResolver.ResolvePath(SourceDirectory, inclusionItem.LogicalPath).ToLower();
                }
            }
            _current.StreamHints.Clear();
        }

        public void ReloadIfRequired(InstanceHandleSet requiredOverrideSources)
        {
            string reason = null;
            InstanceHandleSet set = new InstanceHandleSet();
            foreach (InstanceHandle requiredOverrideSource in requiredOverrideSources)
            {
                if (_current.SelfInstances.Contains(requiredOverrideSource))
                {
                    set.Add(requiredOverrideSource);
                }
            }
            if (set.Count > 0)
            {
                if (reason is null)
                {
                    reason = "inheritFrom target changed";
                }
                foreach (InstanceHandle instanceHandle in set)
                {
                    requiredOverrideSources.Remove(instanceHandle);
                }
            }
            if (reason is null)
            {
                return;
            }
            if (State == DocumentState.Complete && !IsLoaded)
            {
                PrevalidatedLoad(reason);
            }
            else
            {
                Load(reason);
            }
        }

        public void UpdateOutputAssets(OutputManager outputManager)
        {
            foreach (BinaryAsset asset in outputManager.Assets.Values)
            {
                if (asset.IsOutputAsset)
                {
                    _current.OutputAssets.Add(new OutputAsset(asset));
                }
            }
        }

        public void LoadXml(bool updateDependentFiles)
        {
            if (_current.XmlDocument != null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Document {0} atttempted to load twice", _current.SourcePath);
            }
            FileNameXmlResolver xmlResolver = FileNameResolver.GetXmlResolver(SourceDirectory);
            _current.XmlReader = File.Exists(_current.SourcePath) ? XmlReader.Create(_current.SourcePath) : XmlReader.Create(new StringReader("<?xml version='1.0' encoding='UTF-8'?>\n<AssetDeclaration xmlns=\"uri:ea.com:eala:asset\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n</AssetDeclaration>"));
            _current.XmlDocument = new XmlDocument();
            XmlReader reader = XIncludeReaderWrapper.GetReader(_current.XmlReader, xmlResolver) ?? _current.XmlReader;
            _current.NodeSourceInfoSet = new LinkedList<XmlNodeWithMetaData>();
            try
            {
                bool isXml = _current.LogicalSourcePath.EndsWith(".xml");
                if (isXml)
                {
                    _current.XmlDocument.NodeInserted += NodeInsertedHandler;
                }
                _current.XmlDocument.Load(reader);
                if (isXml)
                {
                    _current.XmlDocument.NodeInserted -= NodeInsertedHandler;
                }
            }
            catch (XmlSchemaValidationException ex)
            {
                throw new BinaryAssetBuilderException(ex, ErrorCode.SchemaValidation);
            }
            catch (XmlException ex)
            {
                throw new BinaryAssetBuilderException(ex, ErrorCode.XmlFormattingError);
            }
            finally
            {
                _current.XmlReader.Close();
            }
            if (updateDependentFiles)
            {
                foreach (PathMapItem path in xmlResolver.Paths)
                {
                    _current.DependentFiles.Add(path.SourceUri.ToLower());
                }
            }
            _current.NamespaceManager = new XmlNamespaceManager(reader.NameTable);
            _current.NamespaceManager.AddNamespace("ea", "uri:ea.com:eala:asset");
            _current.NamespaceManager.AddNamespace("ms", "urn:schemas-microsoft-com:xslt");
        }

        public void InplaceLoad(string reason)
        {
            InternalLoad(reason, false);
        }

        public void FromLastHack()
        {
            if (_current != null)
            {
                return;
            }
            _current = new CurrentState();
            _current.FromLast(this, _last);
        }

        public void Open(DocumentProcessor documentProcessor, FileHashItem hashItem, string logicalPath, string configuration)
        {
            if (_current != null && _current.State == DocumentState.Complete)
            {
                return;
            }
            _current = new CurrentState(documentProcessor, hashItem, logicalPath, configuration);
            if (_last != null)
            {
                _current.FromLast(this, _last);
            }
            else
            {
                Load("New Document");
            }
        }

        public void ResetState()
        {
            _current = null;
        }

        public void MakeCacheable()
        {
            if (_current is null || _last != null)
            {
                return;
            }
            _last = new LastState(_current);
            foreach (InstanceDeclaration selfInstance in _current.SelfInstances)
            {
                selfInstance.MakeCacheable();
            }
        }

        public void MakeComplete()
        {
            _current.State = DocumentState.Complete;
            foreach (InstanceDeclaration selfInstance in _current.SelfInstances)
            {
                selfInstance.MakeComplete();
            }
            _last = null;
        }

        public void AddStreamHints(string[] streams)
        {
            foreach (string stream in streams)
            {
                if (!_current.StreamHints.Contains(stream))
                {
                    _current.StreamHints.Add(stream);
                }
            }
        }

        public void HandleValidationEvents(object sender, ValidationEventArgs args)
        {
            if (args.Exception is XmlSchemaValidationException ex)
            {
                LinkedListNode<XmlNodeWithMetaData> node = _current.NodeSourceInfoSet.Find(new XmlNodeWithMetaData(ex.SourceObject as XmlNode, 0));
                if (node != null && node.Value != null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.SchemaValidation,
                                                          "XML validation error encountered in '{0}' near line {1}:\n   {2}",
                                                          SourcePath,
                                                          node.Value.LineNumber,
                                                          args.Message);
                }
            }
            throw new BinaryAssetBuilderException(args.Exception, ErrorCode.SchemaValidation, "XML validation error encountered in '{0}'", SourcePath);
        }

        public void Validate()
        {
            _current.XmlDocument.Schemas.Add(_current.DocumentProcessor.SchemaSet.Schemas);
            _current.XmlDocument.Validate(new ValidationEventHandler(HandleValidationEvents));
            _current.NodeSourceInfoSet.Clear();
            _current.NodeSourceInfoSet = null;
            ValidateInstances();
            UpdateDocumentHashes();
        }

        // TODO: public void EvaluateDefinitions()..

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            _last = new LastState();
            _last.ReadXml(reader);
        }

        public void WriteXml(XmlWriter writer)
        {
            if (_last is null)
            {
                return;
            }
            _last.WriteXml(writer);
        }

        public override string ToString()
        {
            return $"{Path.GetFileName(SourcePath)} {State}";
        }
    }
}