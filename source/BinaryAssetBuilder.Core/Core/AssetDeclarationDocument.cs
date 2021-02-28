using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace BinaryAssetBuilder.Core
{
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
                State = DocumentState.None;
            }
        }

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(AssetDeclarationDocument), "Provides Xml processing functionality");

        private LastState _last;
        [NonSerialized] private CurrentState _current;

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
                using MemoryStream memoryStream = new MemoryStream();
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

        private void GatherUnvalidatedTags()
        {
            Tags.Clear();
            foreach (XPathNavigator xPathNavigator in _current.XmlDocument.CreateNavigator().Evaluate("/ea:AssetDeclaration/ea:Tags/child::*", _current.NamespaceManager) as XPathNodeIterator)
            {
                _current.Tags.Add(xPathNavigator.GetAttribute("name", ""), xPathNavigator.GetAttribute("value", ""));
            }
        }

        private void GatherDefines()
        {
            SelfDefines.Clear();
            foreach (XPathNavigator xPathNavigator in _current.XmlDocument.CreateNavigator().Evaluate("/ea:AssetDeclaration/ea:Defines/child::*", _current.NamespaceManager) as XPathNodeIterator)
            {
                _current.SelfDefines.Add(new Definition
                {
                    Document = this,
                    OriginalValue = xPathNavigator.GetAttribute("value", ""),
                    Name = xPathNavigator.GetAttribute("name", ""),
                    IsOverride = xPathNavigator.GetAttribute("override", "") == "true"
                });
            }
        }

        private void GatherUnvalidatedIncludes()
        {
            InclusionItems.Clear();
            foreach (XPathNavigator xPathNavigator in _current.XmlDocument.CreateNavigator().Evaluate("/ea:AssetDeclaration/ea:Includes/child::*", _current.NamespaceManager) as XPathNodeIterator)
            {
                string path = xPathNavigator.GetAttribute("source", "").Trim().ToLower();
                string resolvedPath = FileNameResolver.ResolvePath(SourceDirectory, path).ToLower();
                InclusionItem inclusionItem = new InclusionItem(path, resolvedPath, (InclusionType)Enum.Parse(typeof(InclusionType), xPathNavigator.GetAttribute("type", ""), true));
                _current.InclusionItems.Add(inclusionItem);
                if (inclusionItem.Type == InclusionType.Instance)
                {
                    _current.DependentFiles.Add(path);
                }
            }
        }

        private void GatherUnvalidatedInstances()
        {
            SelfInstances.Clear();
            foreach (XmlNode selectNode in _current.XmlDocument.SelectNodes("/ea:AssetDeclaration/child::*", _current.NamespaceManager))
            {
                if (!(selectNode.Name == "Includes") && !(selectNode.Name == "Tags") && !(selectNode.Name == "Defines"))
                {
                    InstanceDeclaration declaration = new InstanceDeclaration(this)
                    {
                        XmlNode = selectNode
                    };
                    if (!SelfInstances.TryAdd(declaration))
                    {
                        InstanceDeclaration selfInstance = SelfInstances[declaration.Handle];
                        if (declaration.Handle.InstanceName == selfInstance.Handle.InstanceName)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.DuplicateInstance,
                                                                  "Duplicate Instance: {0}, in {1} and {2}",
                                                                  declaration,
                                                                  declaration.Document.SourcePath,
                                                                  selfInstance.Document.SourcePath);
                        }
                        throw new BinaryAssetBuilderException(ErrorCode.DuplicateInstance, "Duplicate Instance: {0} (other is {1})", declaration, selfInstance);
                    }
                }
            }
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
            if (loadFromScratch)
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

        private void ProcessExpressionsInNode(IExpressionEvaluator evaluator, XmlNode node)
        {
            if (node.Attributes != null)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    if (attribute.Value.Length > 0 && attribute.Value[0] == '=')
                    {
                        attribute.Value = evaluator.Evaluate(attribute.Value);
                    }
                }
            }
            if (node.Value != null && node.Value.Length > 0 && node.Value[0] == '=')
            {
                node.Value = evaluator.Evaluate(node.Value);
            }
            if (node.ChildNodes is null)
            {
                return;
            }
            foreach (XmlNode childNode in node.ChildNodes)
            {
                ProcessExpressionsInNode(evaluator, childNode);
            }
        }

        private void OverrideInstance(InstanceDeclaration instance)
        {
            if (instance.InheritFromHandle != null)
            {
                XmlNode baseNode = null;
                InstanceDeclaration baseInstance = FindInstance(instance.InheritFromHandle,
                                                                instance.InheritFromHandle == instance.Handle ? FindLocation.Self : FindLocation.None,
                                                                out FindLocation location);
                if (baseInstance is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                          "Instance {0} attempts to inherit from or override a non-existing instance {1}",
                                                          instance.Handle,
                                                          instance.InheritFromHandle);
                }
                if (!instance.IsInheritable && location != FindLocation.Self)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                          "Instance {0} cannot be overriden because it is not of type BaseInheritableAsset",
                                                          instance.InheritFromHandle);
                }
                switch (location)
                {
                    case FindLocation.None:
                        throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                              "Instance {0} attempts to inherit from an instance {1} which could not be found.",
                                                              instance.Handle,
                                                              instance.InheritFromHandle);
                    case FindLocation.Self:
                        if (baseInstance.PrevalidationXmlHash == 0u)
                        {
                            OverrideInstance(baseInstance);
                        }
                        baseNode = baseInstance.XmlNode;
                        break;
                    case FindLocation.Tentative:
                        using (List<InclusionItem>.Enumerator enumerator = _current.InclusionItems.GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                if (enumerator.Current.Document == baseInstance.Document)
                                {
                                    baseNode = baseInstance.XmlNode;
                                    break;
                                }
                            }
                        }
                        break;
                    default:
                        throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                              "Instance {0}\n  in document '{1}'\n  attempts to inherit from instance {2}\n  from document '{3}'\n  which does not appear to be included by 'instance'.",
                                                              instance.Handle,
                                                              instance.Document.SourcePath,
                                                              baseInstance,
                                                              baseInstance.Document.SourcePath);
                }
                if (baseNode is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                          "Instance {0} attempts to inherit from instance {1} but source XML is missing.",
                                                          instance.Handle,
                                                          instance.InheritFromHandle);
                }
                XmlNode newChild = NodeJoiner.Override(_current.DocumentProcessor.SchemaSet.Schemas, XmlDocument, baseNode, instance.XmlNode);
                XmlNode parentNode = instance.XmlNode.ParentNode;
                parentNode.RemoveChild(instance.XmlNode);
                parentNode.AppendChild(newChild);
                instance.XmlNode = newChild;
                instance.InheritFromXmlHash = baseInstance.PrevalidationXmlHash;
            }
            instance.PrevalidationXmlHash = HashProvider.GetTextHash(instance.XmlNode.OuterXml);
        }

        private void ValidateInstances()
        {
            StringCollection derivedTypes = _current.DocumentProcessor.SchemaSet.GetDerivedTypes("BaseInheritableAsset");
            foreach (InstanceDeclaration selfInstance in _current.SelfInstances)
            {
                ExtendedTypeInformation extendedTypeInformation = _current.DocumentProcessor.Plugins.GetExtendedTypeInformation(selfInstance.Handle.TypeId);
                uint textHash = HashProvider.GetTextHash(extendedTypeInformation.ProcessingHash, DocumentProcessor.Version.ToString());
                selfInstance.Handle.TypeHash = extendedTypeInformation.TypeHash;
                selfInstance.Handle.InstanceHash = HashProvider.GetTextHash(textHash, selfInstance.XmlNode.OuterXml);
                selfInstance.ProcessingHash = extendedTypeInformation.ProcessingHash;
                if (derivedTypes != null)
                {
                    selfInstance.IsInheritable = derivedTypes.Contains(selfInstance.XmlNode.SchemaInfo.SchemaType.Name);
                }
                if (selfInstance.Handle.TypeName != selfInstance.XmlNode.SchemaInfo.SchemaType.Name)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.SchemaValidation, "Type name and element name do not match for {0}.", selfInstance.Handle);
                }
                if (selfInstance.Handle.TypeHash == 0u)
                {
                    _tracer.TraceWarning("No type hash found for type {0}.", selfInstance.Handle.TypeName);
                }
                if (Settings.Current.OutputIntermediateXml)
                {
                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        NewLineOnAttributes = true,
                        Encoding = Encoding.ASCII,
                        Indent = true,
                        IndentChars = "    "
                    };
                    string outputDir = Path.Combine(Settings.Current.OutputDirectory, "FinalXml");
                    string assetName = selfInstance.Handle.TypeName + "." + selfInstance.Handle.InstanceName;
                    Directory.CreateDirectory(outputDir);
                    XmlWriter writer = XmlWriter.Create(Path.Combine(outputDir, assetName + ".xml"), settings);
                    selfInstance.XmlNode.WriteTo(writer);
                    writer.Close();
                }
                XPathNodeIterator xPathNodeIterator = selfInstance.XmlNode.CreateNavigator().SelectDescendants("", "uri:ea.com:eala:asset", true);
                using MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                foreach (XPathNavigator navigator in xPathNodeIterator)
                {
                    HandleReferenceType(selfInstance, navigator, binaryWriter);
                    if (navigator.HasAttributes)
                    {
                        navigator.MoveToFirstAttribute();
                        do
                        {
                            HandleReferenceType(selfInstance, navigator, binaryWriter);
                        }
                        while (navigator.MoveToNextAttribute());
                        navigator.MoveToParent();
                    }
                    if (navigator.SchemaInfo != null && navigator.SchemaInfo.SchemaType != null && navigator.SchemaInfo.SchemaType.Name != null)
                    {
                        navigator.CreateAttribute("", "TypeId", "", HashProvider.GetCaseSenstitiveSymbolHash(navigator.SchemaInfo.SchemaType.Name).ToString());
                    }
                }
                foreach (string referencedFile in selfInstance.ReferencedFiles)
                {
                    TryGetFileHashItem(referencedFile, out FileHashItem fileItem);
                    binaryWriter.Write(fileItem.Hash);
                }
                if (memoryStream.Length > 0L)
                {
                    selfInstance.Handle.InstanceHash ^= FastHash.GetHashCode(memoryStream.GetBuffer());
                }
            }
        }

        private string GetRefTypeName(XmlAttribute[] unhandledAttributes)
        {
            if (unhandledAttributes != null)
            {
                foreach (XmlAttribute unhandledAttribute in unhandledAttributes)
                {
                    if (unhandledAttribute.NamespaceURI == "uri:ea.com:eala:asset:schema")
                    {
                        switch (unhandledAttribute.LocalName)
                        {
                            case "refType":
                                return unhandledAttribute.Value;
                            default:
                                continue;
                        }
                    }
                }
            }
            return null;
        }

        private void HandleReferenceType(InstanceDeclaration instance, XPathNavigator navigator, BinaryWriter refTypeWriter)
        {
            if (navigator.SchemaInfo is null || navigator.SchemaInfo.SchemaType is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Element {0} in instance {1} doesn't have a schema type.", navigator.Name, instance);
            }
            bool isWeakRef = XmlSchemaType.IsDerivedFrom(navigator.SchemaInfo.SchemaType, _current.DocumentProcessor.SchemaSet.XmlWeakReferenceType, XmlSchemaDerivationMethod.None);
            bool isRef = !isWeakRef
                      && XmlSchemaType.IsDerivedFrom(navigator.SchemaInfo.SchemaType, _current.DocumentProcessor.SchemaSet.XmlAssetReferenceType, XmlSchemaDerivationMethod.None);
            if (isWeakRef || isRef)
            {
                string instanceName = navigator.Value.Trim().Split('\\')[0];
                if (string.IsNullOrEmpty(instanceName))
                {
                    return;
                }
                InstanceHandle instanceHandle = new InstanceHandle(instanceName);
                string refTypeName = null;
                if (navigator.SchemaInfo.SchemaElement != null)
                {
                    refTypeName = GetRefTypeName(navigator.SchemaInfo.SchemaElement.UnhandledAttributes);
                }
                else if (navigator.SchemaInfo.SchemaAttribute != null)
                {
                    refTypeName = GetRefTypeName(navigator.SchemaInfo.SchemaAttribute.UnhandledAttributes);
                }
                if (refTypeName is null)
                {
                    refTypeName = GetRefTypeName(navigator.SchemaInfo.SchemaType.UnhandledAttributes);
                }
                if (refTypeName is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                          "Asset reference to '{0}' in '{1}' does not have type (xas:refType missing in schema).",
                                                          instanceName,
                                                          instance);
                }
                refTypeWriter.Write(HashProvider.GetCaseSenstitiveSymbolHash(refTypeName));
                if (instanceHandle.TypeId == 0u)
                {
                    instanceHandle.TypeName = refTypeName;
                }
                else if (isRef)
                {
                    XmlSchemaType xmlType = _current.DocumentProcessor.SchemaSet.GetXmlType(instanceHandle.TypeName);
                    XmlSchemaType otherType = _current.DocumentProcessor.SchemaSet.GetXmlType(refTypeName);
                    if (otherType is null)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                              "Unable to establish schema type of underlying reference type '{0}'. Make sure it's defined and included in the schema set.",
                                                              refTypeName);
                    }
                    if (xmlType is null)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                              "Unable to establish schema type of referenced instance '{0}'. Make sure it's defined and included in the schema set.",
                                                              instanceHandle.Name);
                    }
                    if (!XmlSchemaType.IsDerivedFrom(xmlType, otherType, XmlSchemaDerivationMethod.None))
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                              "Type of instance '{0}' referenced from '{1}' does not appear to be equal to or derived from required reference type '{2}'.",
                                                              instanceHandle.Name,
                                                              instance.Handle.Name,
                                                              refTypeName);
                    }
                }
                if (isRef)
                {
                    instance.ReferencedInstances.Add(instanceHandle);
                    navigator.SetValue($"{instanceName}\\{instance.ReferencedInstances.Count - 1}");
                }
                else
                {
                    instance.WeakReferencedInstances.Add(instanceHandle);
                }
            }
            else if (XmlSchemaType.IsDerivedFrom(navigator.SchemaInfo.SchemaType, _current.DocumentProcessor.SchemaSet.XmlFileReferenceType, XmlSchemaDerivationMethod.None))
            {
                string lower = navigator.Value.Trim().ToLower();
                TryGetFileHashItem(lower, out FileHashItem fileItem);
                string path = fileItem.Path.ToLower();
                _current.DependentFiles.Add(lower);
                navigator.SetValue(path);
                instance.ReferencedFiles.Add(lower);
            }
            else if (Equals(navigator.SchemaInfo.SchemaType, _current.DocumentProcessor.SchemaSet.XmlStringHashType))
            {
                HashProvider.RecordHash(HashProvider.StringHashTableName, navigator.Value.Trim());
            }
            else if (Equals(navigator.SchemaInfo.SchemaType, _current.DocumentProcessor.SchemaSet.XmlPoidType))
            {
                HashProvider.RecordHash(HashProvider.PoidTableName, navigator.Value.Trim());
            }
        }

        private InstanceDeclaration ResolveReference(InstanceDeclaration parent, InstanceHandle reference, out FindLocation location)
        {
            InstanceDeclaration instance = FindInstance(reference, FindLocation.None, out location);
            if (instance is null)
            {
                InstanceHandle handle = new InstanceHandle(reference.TypeName, reference.InstanceName);
                StringCollection derivedTypes = _current.DocumentProcessor.SchemaSet.GetDerivedTypes(reference.TypeName);
                if (derivedTypes != null)
                {
                    StringBuilder sb = new StringBuilder();
                    int num = 0;
                    foreach (string str in derivedTypes)
                    {
                        handle.TypeName = str;
                        InstanceDeclaration otherInstance = FindInstance(handle, FindLocation.None, out FindLocation otherLocation);
                        if (otherInstance != null)
                        {
                            instance = otherInstance;
                            location = otherLocation;
                            if (num > 0)
                            {
                                sb.Append(", ");
                            }
                            sb.AppendFormat("'{0}'", handle.Name);
                            ++num;
                        }
                    }
                    if (num > 1)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                              "Reference to instance '{0}' from '{1}' in 'file://{2}' is ambiguous. Possible matches: {3}",
                                                              reference.Name,
                                                              parent.Handle.Name,
                                                              parent.Document.SourcePath,
                                                              sb);
                    }
                }
            }
            return instance;
        }

        private void AddOutputInstance(InstanceDeclaration instance)
        {
            if (instance.Handle.TypeHash == 0u || _current.OutputInstanceSet.ContainsKey(instance.Handle))
            {
                return;
            }
            _current.OutputInstanceSet.Add(instance.Handle, instance);
            if (instance.ValidatedReferencedInstances != null)
            {
                foreach (InstanceHandle referenceHandle in instance.ValidatedReferencedInstances)
                {
                    InstanceDeclaration reference = ResolveReference(instance, referenceHandle, out FindLocation location);
                    if (reference != null && location != FindLocation.External)
                    {
                        AddOutputInstance(reference);
                    }
                }
            }
            else
            {
                instance.ValidatedReferencedInstances = new List<InstanceHandle>();
                instance.AllDependentInstances = new InstanceHandleSet();
                foreach (InstanceHandle referencedHandle in instance.ReferencedInstances)
                {
                    InstanceDeclaration reference = ResolveReference(instance, referencedHandle, out FindLocation location);
                    if (reference != null)
                    {
                        if (location != FindLocation.External)
                        {
                            instance.AllDependentInstances.TryAdd(reference.Handle);
                            AddOutputInstance(reference);
                            foreach (InstanceHandle dependentHandle in reference.AllDependentInstances)
                            {
                                instance.AllDependentInstances.TryAdd(dependentHandle);
                            }
                        }
                        instance.ValidatedReferencedInstances.Add(reference.Handle);
                    }
                    else
                    {
                        if (Settings.Current.ErrorLevel > 0)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.UnknownReference, "Unknown referenced asset: {0}", referencedHandle);
                        }
                        if (_current.DocumentProcessor.MissingReferences.TryAdd(referencedHandle))
                        {
                            _tracer.TraceWarning("Unknown asset '{0}' referenced from '{1}'\n   in 'file://{2}'", referencedHandle.Name, instance.Handle.Name, instance.Document.SourcePath);
                        }
                        instance.ValidatedReferencedInstances.Add(referencedHandle);
                    }
                }
                foreach (string referencedFile in instance.ReferencedFiles)
                {
                    if (!instance.Document.TryGetFileHashItem(referencedFile, out FileHashItem _))
                    {
                        _tracer.TraceWarning("Referenced file not found: {0}", referencedFile);
                    }
                }
            }
        }

        public InstanceDeclaration FindInstance(InstanceHandle handle, FindLocation skipLocation, out FindLocation location)
        {
            location = FindLocation.None;
            if (_current.SelfInstances != null && skipLocation != FindLocation.Self && _current.SelfInstances.TryGetValue(handle, out InstanceDeclaration instance))
            {
                location = FindLocation.Self;
                return instance;
            }
            if (_current.AllInstances != null && skipLocation != FindLocation.All && _current.AllInstances.TryGetValue(handle, out instance))
            {
                location = FindLocation.All;
                return instance;
            }
            if (_current.TentativeInstances != null && skipLocation != FindLocation.Tentative && _current.TentativeInstances.TryGetValue(handle, out instance))
            {
                location = FindLocation.Tentative;
                return instance;
            }
            if (_current.ReferenceInstances != null && skipLocation != FindLocation.External && _current.ReferenceInstances.TryGetValue(handle, out instance))
            {
                location = FindLocation.External;
                return instance;
            }
            return null;
        }

        public void RecordStringHashes()
        {
            foreach (InstanceDeclaration selfInstance in _current.SelfInstances)
            {
                HashProvider.RecordHash(selfInstance.Handle);
                foreach (InstanceHandle referencedInstance in selfInstance.ReferencedInstances)
                {
                    HashProvider.RecordHash(referencedInstance);
                }
                foreach (InstanceHandle referencedInstance in selfInstance.WeakReferencedInstances)
                {
                    HashProvider.RecordHash(referencedInstance);
                }
            }
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

        public void EvaluateDefinitions()
        {
            IExpressionEvaluator evaluator = ExpressionEvaluatorWrapper.GetEvaluator(this);
            foreach (Definition selfDefine in SelfDefines)
            {
                if (evaluator is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.ExpressionEvaluationError, "Expression evaluator not loaded but evaluation was requested");
                }
                if (selfDefine.OriginalValue != null)
                {
                    selfDefine.EvaluatedValue = null;
                    evaluator.EvaluateDefinition(selfDefine);
                }
                if (AllDefines.TryGetValue(selfDefine.Name, out Definition definition) && selfDefine.Document != definition.Document && !selfDefine.IsOverride)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.DuplicateDefine,
                                                          "Define {0} defined in {1} is already defined in {2}",
                                                          selfDefine.Name,
                                                          selfDefine.Document.SourcePath,
                                                          definition.Document.SourcePath);
                }
                AllDefines[selfDefine.Name] = selfDefine;
            }
        }

        public bool ValidateCachedDefines()
        {
            foreach (KeyValuePair<string, string> usedDefine in UsedDefines)
            {
                if (usedDefine.Value != AllDefines.GetEvaluatedValue(usedDefine.Key))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateInheritFromSources()
        {
            foreach (InstanceDeclaration selfInstance in SelfInstances)
            {
                if (!(selfInstance.InheritFromHandle is null))
                {
                    InstanceDeclaration instance = FindInstance(selfInstance.InheritFromHandle,
                                                                selfInstance.InheritFromHandle == selfInstance.Handle ? FindLocation.Self : FindLocation.None,
                                                                out FindLocation location);
                    if (instance is null)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                              "Instance {0} attempts to inherit from non-existing instance {1}.",
                                                              selfInstance,
                                                              selfInstance.InheritFromHandle);
                    }
                    switch (location)
                    {
                        case FindLocation.Self:
                            if ((int)instance.PrevalidationXmlHash != (int)selfInstance.InheritFromXmlHash)
                            {
                                return false;
                            }
                            continue;
                        case FindLocation.Tentative:
                            bool included = false;
                            foreach (InclusionItem inclusionItem in _current.InclusionItems)
                            {
                                if (inclusionItem.Document == instance.Document)
                                {
                                    included = true;
                                    break;
                                }
                            }
                            if (!included)
                            {
                                throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                                      "Instance {0} attempts to inherit from instance {1} which is not directly included.",
                                                                      selfInstance,
                                                                      selfInstance.InheritFromHandle);
                            }
                            goto case FindLocation.Self;
                        default:
                            throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                                  "Instance {0} attempts to inherit from instance {1} which is not included by 'instance'.",
                                                                  selfInstance,
                                                                  selfInstance.InheritFromHandle);
                    }
                }
            }
            return true;
        }

        public void ProcessExpressions()
        {
            IExpressionEvaluator evaluator = ExpressionEvaluatorWrapper.GetEvaluator(this);
            if (evaluator is null)
            {
                return;
            }
            foreach (InstanceDeclaration selfInstance in SelfInstances)
            {
                ProcessExpressionsInNode(evaluator, selfInstance.XmlNode);
            }
        }

        public void MergeInstances()
        {
            Instances.Clear();
            Instances.Add(SelfInstances);
            Instances.Add(AllInstances);
        }

        public void ProcessInstances(OutputManager outputManager, ref int instancesCompiledCount, ref int instancesCopiedFromCacheCount)
        {
            foreach (InstanceDeclaration selfInstance in SelfInstances)
            {
                ExtendedTypeInformation extendedTypeInformation = _current.DocumentProcessor.Plugins.GetExtendedTypeInformation(selfInstance.Handle.TypeId);
                selfInstance.HasCustomData = extendedTypeInformation.HasCustomData;
                BinaryAsset binaryAsset = outputManager.GetBinaryAsset(selfInstance, true);
                if (binaryAsset != null)
                {
                    if (binaryAsset.GetLocation(AssetLocation.All, AssetLocationOption.None) == AssetLocation.None)
                    {
                        _tracer.Message("{0}: Compiling {1}", Path.GetFileName(_current.SourcePath), binaryAsset.Instance.ToString());
                        if (binaryAsset.Instance.XmlNode is null)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.DependencyCacheFailure, "Need to compile instance {0} but XML is not loaded. Bug.", binaryAsset.Instance);
                        }
                        if (selfInstance.HasCustomData)
                        {
                            selfInstance.CustomDataPath = Path.Combine(binaryAsset.CustomDataOutputDirectory, binaryAsset.FileBase + ".cdata");
                            if (!Directory.Exists(binaryAsset.CustomDataOutputDirectory))
                            {
                                Directory.CreateDirectory(binaryAsset.CustomDataOutputDirectory);
                            }
                        }
                        IAssetBuilderPlugin plugin = _current.DocumentProcessor.Plugins.GetPlugin(binaryAsset.Instance.Handle.TypeId);
                        binaryAsset.Buffer = plugin.ProcessInstance(binaryAsset.Instance);
                    }
                    if (_current.IsLoaded && !_current.DocumentProcessor.VerifierPlugins.GetPlugin(binaryAsset.Instance.Handle.TypeId).VerifyInstance(selfInstance))
                    {
                        _current.VerificationErrors = true;
                    }
                    AssetLocation assetLocation = binaryAsset.Commit();
                    switch (assetLocation)
                    {
                        case AssetLocation.Memory:
                            ++instancesCompiledCount;
                            break;
                        case AssetLocation.Local:
                        case AssetLocation.Cache:
                            ++instancesCopiedFromCacheCount;
                            break;
                    }
                    if (assetLocation != AssetLocation.BasePatchStream)
                    {
                        _current.DocumentProcessor.AddLastWrittenAsset(binaryAsset);
                    }
                    if (!selfInstance.IsInheritable)
                    {
                        selfInstance.XmlNode = null;
                    }
                }
            }
        }

        public void ProcessOverrides()
        {
            foreach (InstanceDeclaration selfInstance in SelfInstances)
            {
                OverrideInstance(selfInstance);
            }
        }

        public void StableSort()
        {
            _tracer.TraceInfo("Stable sorting assets");
            TypeDepComapre compare = new TypeDepComapre(_current.DocumentProcessor.SchemaSet.AssetDependencies);
            _current.OutputInstances.Sort(compare);
            List<InstanceDeclaration> instances = new List<InstanceDeclaration>();
            foreach (InstanceDeclaration outputInstance in _current.OutputInstances)
            {
                int index = 0;
                int a = 0;
                int b = 0;
                int c = 0;
                uint typeId = 0;
                uint lastTypeId = 0;
                bool flag = false;
                foreach (InstanceDeclaration x in instances)
                {
                    if ((int)x.Handle.TypeId != (int)lastTypeId)
                    {
                        b = a;
                        lastTypeId = x.Handle.TypeId;
                    }
                    if (outputInstance.AllDependentInstances != null && outputInstance.AllDependentInstances.Contains(x.Handle))
                    {
                        index = a + 1;
                        c = index;
                        if ((int)outputInstance.Handle.TypeId != (int)x.Handle.TypeId)
                        {
                            flag = false;
                            typeId = x.Handle.TypeId;
                        }
                    }
                    else
                    {
                        if (x.AllDependentInstances != null && x.AllDependentInstances.Contains(outputInstance.Handle))
                        {
                            if (b > c)
                            {
                                if ((int)outputInstance.Handle.TypeId != (int)x.Handle.TypeId)
                                {
                                    index = b;
                                    break;
                                }
                                break;
                            }
                            break;
                        }
                        if ((int)outputInstance.Handle.TypeId == (int)x.Handle.TypeId)
                        {
                            if (!flag)
                            {
                                index = a;
                                flag = true;
                            }
                            if (string.Compare(outputInstance.Handle.InstanceName, x.Handle.InstanceName) > 0)
                            {
                                index = a + 1;
                            }
                        }
                        else if ((int)x.Handle.TypeId == (int)typeId)
                        {
                            index = a + 1;
                        }
                        else
                        {
                            typeId = 0u;
                            if (compare.Compare(outputInstance, x) > 0)
                            {
                                index = a + 1;
                            }
                        }
                    }
                    ++a;
                }
                instances.Insert(index, outputInstance);
            }
            _current.OutputInstances = instances;
        }

        public void PrepareOutputInstances(OutputManager outputManager)
        {
            _current.OutputInstanceSet = new SortedDictionary<InstanceHandle, InstanceDeclaration>();
            foreach (InstanceDeclaration instance in Instances)
            {
                AddOutputInstance(instance);
            }
            foreach (InstanceDeclaration instance in _current.OutputInstanceSet.Values)
            {
                BinaryAsset binaryAsset = outputManager.GetBinaryAsset(instance, true);
                if (binaryAsset != null)
                {
                    AssetLocation location = binaryAsset.GetLocation(AssetLocation.All, AssetLocationOption.None);
                    if (location == AssetLocation.None)
                    {
                        location = binaryAsset.GetLocation(AssetLocation.Local | AssetLocation.Cache, AssetLocationOption.ForceUpdate);
                    }
                    if (location == AssetLocation.None)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Asset {0} not available.", instance);
                    }
                    if ((location & AssetLocation.Output) == AssetLocation.None)
                    {
                        binaryAsset.Commit();
                    }
                    _current.OutputInstances.Add(instance);
                }
            }
            if (Settings.Current.StableSort)
            {
                StableSort();
            }
            else
            {
                _current.OutputInstances.Sort(new DependencyComparer());
            }
            using MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            foreach (InstanceDeclaration outputInstance in _current.OutputInstances)
            {
                writer.Write(outputInstance.Handle.TypeId);
                writer.Write(outputInstance.Handle.TypeHash);
                writer.Write(outputInstance.Handle.InstanceId);
                writer.Write(outputInstance.Handle.InstanceHash);
                writer.Write(outputInstance.ReferencedInstances.Count);
            }
            _current.OutputChecksum = memoryStream.Length <= 0L ? 0u : FastHash.GetHashCode(memoryStream.GetBuffer());
            _current.OutputInstanceSet = null;
        }

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