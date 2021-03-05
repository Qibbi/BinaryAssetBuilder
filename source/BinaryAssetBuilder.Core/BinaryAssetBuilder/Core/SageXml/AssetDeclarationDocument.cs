using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.Hashing;
using BinaryAssetBuilder.Core.IO;
using BinaryAssetBuilder.Core.Xml;
using BinaryAssetBuilder.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace BinaryAssetBuilder.Core.SageXml
{
    public enum FindLocation
    {
        None,
        Self,
        All,
        Tentative,
        External
    }

    public enum DocumentState
    {
        None,
        Shallow,
        Loaded,
        Validated,
        Complete
    }

    public class AssetDeclarationDocument : ISerializable
    {
        private enum LoadType
        {
            InplaceLoad,
            FromScratch
        }

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
            public int Compare(InstanceDeclaration x, InstanceDeclaration y)
            {
                if (x is null || y is null)
                {
                    throw new ArgumentNullException();
                }
                if (x.AllDependentInstances.Count != y.AllDependentInstances.Count)
                {
                    return x.AllDependentInstances.Count.CompareTo(y.AllDependentInstances.Count);
                }
                bool yContainsX = y.AllDependentInstances is not null && y.AllDependentInstances.Contains(x.Handle);
                bool xContainsY = x.AllDependentInstances is not null && x.AllDependentInstances.Contains(y.Handle);
                if (yContainsX)
                {
                    if (xContainsY)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.CircularDependency,
                                                              "Illegal circular dependency found between {0} and {1}. This should have been caught during parsing.",
                                                              x,
                                                              y);
                    }
                    return -1;
                }
                return xContainsY ? 1 : string.Compare(x.Handle.TypeName, y.Handle.TypeName);
            }
        }

        private class TypeDepCompare : IComparer<InstanceDeclaration>
        {
            private readonly IDictionary<uint, int> _typeDependencies;

            public TypeDepCompare(IDictionary<uint, int> typeDependencies)
            {
                _typeDependencies = typeDependencies;
            }

            public int Compare(InstanceDeclaration x, InstanceDeclaration y)
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

        private class LastState : ISerializable
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
                List<DefinitionPair> definitions = new List<DefinitionPair>();
                foreach (KeyValuePair<string, string> usedDefines in current.UsedDefines)
                {
                    definitions.Add(new DefinitionPair { Name = usedDefines.Key, EvaluatedValue = usedDefines.Value });
                }
                UsedDefines = definitions.Count > 0 ? new List<DefinitionPair>(definitions) : null;
                StreamHints = current.StreamHints.Count > 0 ? new List<string>(current.StreamHints) : null;
            }

            private static void ReadOldStrings(Node node)
            {
                string[] values = null;
                Marshaler.Marshal(node.GetChildNodes("s"), ref values);
                if (values is not null)
                {
                    foreach (string str in values)
                    {
                        HashProvider.RecordHash("STRINGHASH", str);
                    }
                }
                Marshaler.Marshal(node.GetChildNodes("p"), ref values);
                if (values is not null)
                {
                    foreach (string str in values)
                    {
                        HashProvider.RecordHash("POID", str);
                    }
                }
            }

            public void ReadXml(Node node)
            {
                string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
                DocumentHash = Convert.ToUInt32(values[0]);
                DependentFileHash = Convert.ToUInt32(values[1]);
                IncludePathHash = Convert.ToUInt32(values[2]);
                ReadOldStrings(node);
                Marshaler.Marshal(node.GetChildNodes("DependentFile"), ref DependentFiles);
                Marshaler.Marshal(node.GetChildNodes("StreamHint"), ref StreamHints);
                Marshaler.Marshal(node.GetChildNodes(nameof(InclusionItem)), ref InclusionItems);
                Marshaler.Marshal(node.GetChildNodes(nameof(OutputAsset)), ref OutputAssets);
                Marshaler.Marshal(node.GetChildNodes(nameof(Definition)), ref SelfDefines);
                Marshaler.Marshal(node.GetChildNodes(nameof(InstanceDeclaration)), ref SelfInstances);
                Marshaler.Marshal(node.GetChildNodes(nameof(DefinitionPair)), ref UsedDefines);
            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteAttributeString("d", $"{DocumentHash};{DependentFileHash};{IncludePathHash}");
                if (DependentFiles is not null)
                {
                    foreach (string dependentFile in DependentFiles)
                    {
                        writer.WriteElementString("DependentFile", dependentFile);
                    }
                }
                if (StreamHints is not null)
                {
                    foreach (string streamHint in StreamHints)
                    {
                        writer.WriteElementString("StreamHint", streamHint);
                    }
                }
                if (InclusionItems is not null)
                {
                    foreach (InclusionItem item in InclusionItems)
                    {
                        writer.WriteStartElement(nameof(InclusionItem));
                        item.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
                if (OutputAssets is not null)
                {
                    foreach (OutputAsset item in OutputAssets)
                    {
                        writer.WriteStartElement(nameof(OutputAsset));
                        item.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
                if (SelfDefines is not null)
                {
                    foreach (Definition item in SelfDefines)
                    {
                        writer.WriteStartElement(nameof(Definition));
                        item.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
                if (SelfInstances is not null)
                {
                    foreach (InstanceDeclaration item in SelfInstances)
                    {
                        writer.WriteStartElement(nameof(InstanceDeclaration));
                        item.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
                if (UsedDefines is not null)
                {
                    foreach (DefinitionPair item in UsedDefines)
                    {
                        writer.WriteStartElement(nameof(DefinitionPair));
                        item.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
            }
        }

        private class CurrentState
        {
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
            public SortedDictionary<string, string> UsedDefines;
            public bool VerificationErrors;
            public FileHashItem HashItem;
            public List<InstanceDeclaration> OutputInstances = new List<InstanceDeclaration>();
            public DefinitionSet AllDefines = new DefinitionSet();
            public InstanceSet Instances = new InstanceSet();
            public InstanceSet AllInstances = new InstanceSet();
            public InstanceSet TentativeInstances = new InstanceSet();
            public InstanceSet ReferenceInstances = new InstanceSet();
            public StringDictionary Tags = new StringDictionary();
            public XmlDocument XmlDocument;
            public XmlNamespaceManager NamespaceManager;
            public DocumentProcessor DocumentProcessor;
            public List<OutputAsset> OutputAssets = new List<OutputAsset>();
            public List<string> StreamHints;
            public LinkedList<XmlNodeWithMetaData> NodeSourceInfoSet;
            public SortedDictionary<InstanceHandle, InstanceDeclaration> OutputInstanceSet;
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
                    string path = SourcePath[(dataRoot.Length + 1)..];
                    SourcePathFromRoot = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(SourcePath));
                    LogicalSourcePath = "DATA:" + path.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                }
                else
                {
                    SourcePathFromRoot = Path.GetFileNameWithoutExtension(SourcePath);
                }
            }

            public void FromLast(AssetDeclarationDocument document, LastState last)
            {
                InclusionItems = last.InclusionItems is null ? new List<InclusionItem>() : new List<InclusionItem>(last.InclusionItems);
                DependentFiles = last.DependentFiles is null ? new List<string>() : new List<string>(last.DependentFiles);
                StreamHints = last.StreamHints is null ? new List<string>() : new List<string>(last.StreamHints);
                UsedDefines = new SortedDictionary<string, string>();
                if (last.UsedDefines is not null)
                {
                    foreach (DefinitionPair usedDefine in last.UsedDefines)
                    {
                        UsedDefines[usedDefine.Name] = usedDefine.EvaluatedValue;
                    }
                }
                SelfDefines = last.SelfDefines is null ? new List<Definition>() : new List<Definition>(last.SelfDefines);
                foreach (Definition selfDefine in SelfDefines)
                {
                    selfDefine.Document = document;
                }
                SelfInstances = last.SelfInstances is null ? new InstanceSet() : new InstanceSet(document, last.SelfInstances);
                Changed = last.DocumentHash != DocumentHash;
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
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(DocumentProcessor), "Provides XML processing functionality");

        private LastState _last;
        private CurrentState _current;

        public bool ReloadedForInheritance { get; set; }
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
        public bool Processing
        {
            get => _current?.Processing == true;
            set => _current.Processing = value;
        }
        public DefinitionSet AllDefines => _current.AllDefines;
        public SortedDictionary<string, string> UsedDefines => _current.UsedDefines;
        public List<InstanceDeclaration> OutputInstances => _current.OutputInstances;
        public InstanceSet Instances => _current.Instances;
        public InstanceSet AllInstances => _current.AllInstances;
        public InstanceSet TentativeInstances => _current.TentativeInstances;
        public InstanceSet ReferenceInstances => _current.ReferenceInstances;
        public DocumentState State
        {
            get => _current is null ? DocumentState.None : _current.State;
            set => _current.State = value;
        }
        public StringDictionary Tags => _current.Tags;
        public XmlDocument XmlDocument => _current.XmlDocument;
        public XmlNamespaceManager NamespaceManager => _current.NamespaceManager;
        public string SourceDirectory => _current.SourceDirectory;
        public bool VerificationErrors => _current.VerificationErrors;
        public List<string> StreamHints => _last.StreamHints;

        public AssetDeclarationDocument()
        {
        }

        public AssetDeclarationDocument(DocumentProcessor documentProcessor, FileHashItem hashItem, string logicalPath, string configuration)
        {
            Open(documentProcessor, hashItem, logicalPath, configuration);
        }

        private static InstanceDeclaration FindInstance(Asset baseAsset, List<InstanceDeclaration> instances)
        {
            foreach (InstanceDeclaration instance in instances)
            {
                if (baseAsset.TypeId == instance.Handle.TypeId && baseAsset.InstanceId == instance.Handle.InstanceId)
                {
                    return instance;
                }
            }
            return null;
        }

        private static string GetRefTypeName(XmlAttribute[] unhandledAttributes)
        {
            if (unhandledAttributes is not null)
            {
                foreach (XmlAttribute attribute in unhandledAttributes)
                {
                    if (attribute.NamespaceURI == SchemaSet.XmlSchemaNamespace)
                    {
                        switch (attribute.LocalName)
                        {
                            case "refType":
                                return attribute.Value;
                            default:
                                continue;
                        }
                    }
                }
            }
            return null;
        }

        private static void CountCommitSource(AssetLocation commitSource, ref int instancesCompiledCount, ref int instancesCopiedFromCacheCount)
        {
            switch (commitSource)
            {
                case AssetLocation.Memory:
                    ++instancesCompiledCount;
                    break;
                case AssetLocation.Local:
                    ++instancesCopiedFromCacheCount;
                    break;
                case AssetLocation.Cache:
                    ++instancesCopiedFromCacheCount;
                    break;
            }
        }

        private static void StableSort_InitializeFromBaseManifest(OutputManager outputManager, List<InstanceDeclaration> outputInstances, List<InstanceDeclaration> finalList)
        {
            foreach (Asset asset in outputManager.BasePatchStreamManifest.Assets)
            {
                InstanceDeclaration instance = FindInstance(asset, outputInstances);
                if (instance is not null)
                {
                    if (outputManager.GetBinaryAsset(instance, false).GetLocation(AssetLocation.BasePatchStream, AssetLocationOption.None) == AssetLocation.BasePatchStream)
                    {
                        _tracer.TraceInfo("Using base stream instance {0}:{1}", instance.Handle.TypeName, instance.Handle.InstanceName);
                        finalList.Add(instance);
                        outputInstances.Remove(instance);
                    }
                    else
                    {
                        _tracer.TraceInfo("Using patched instance {0}:{1}", instance.Handle.TypeName, instance.Handle.InstanceName);
                    }
                }
            }
        }

        private static int StableSort_CalcInsertPosition(List<InstanceDeclaration> finalList, InstanceDeclaration instance, TypeDepCompare depCompare)
        {
            int index = 0;
            int a = 0;
            int b = 0;
            int c = 0;
            uint typeId = 0;
            uint lastTypeId = 0;
            bool flag = false;
            foreach (InstanceDeclaration x in finalList)
            {
                if (x.Handle.TypeId != lastTypeId)
                {
                    b = a;
                    lastTypeId = x.Handle.TypeId;
                }
                if (instance.AllDependentInstances is not null && instance.AllDependentInstances.Contains(x.Handle))
                {
                    index = a + 1;
                    c = index;
                    if (instance.Handle.TypeId != x.Handle.TypeId)
                    {
                        flag = false;
                        typeId = x.Handle.TypeId;
                    }
                }
                else
                {
                    if (x.AllDependentInstances is not null && x.AllDependentInstances.Contains(instance.Handle))
                    {
                        if (b > c)
                        {
                            if (instance.Handle.TypeId != x.Handle.TypeId)
                            {
                                index = b;
                                break;
                            }
                            break;
                        }
                        break;
                    }
                    if (instance.Handle.TypeId == x.Handle.TypeId)
                    {
                        if (!flag)
                        {
                            index = a;
                            flag = true;
                        }
                        if (string.Compare(instance.Handle.InstanceName, x.Handle.InstanceName) > 0)
                        {
                            index = a + 1;
                        }
                    }
                    else if (x.Handle.TypeId == typeId)
                    {
                        index = a + 1;
                    }
                    else
                    {
                        typeId = 0u;
                        if (depCompare.Compare(instance, x) > 0)
                        {
                            index = a + 1;
                        }
                    }
                }
                ++a;
            }
            return index;
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
                using MemoryStream stream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(stream);
                foreach (string dependentFile in _current.DependentFiles)
                {
                    if (TryGetFileHashItem(dependentFile, out FileHashItem hashItem))
                    {
                        writer.Write(HashProvider.GetTextHash(hashItem.Path.ToLower()));
                        writer.Write(hashItem.Hash);
                    }
                }
                byte[] data = stream.ToArray();
                _current.DependentFileHash = data.Length <= 0 ? 0u : FastHash.GetHashCode(data);
            }
            if (_current.InclusionItems.Count == 0)
            {
                _current.IncludePathHash = 0u;
            }
            else
            {
                _current.IncludePathHash = (uint)_current.InclusionItems.Count;
                foreach (InclusionItem item in _current.InclusionItems)
                {
                    if (TryGetFileHashItem(item.LogicalPath, out FileHashItem hashItem))
                    {
                        _current.IncludePathHash = FastHash.GetHashCode(_current.IncludePathHash, hashItem.Path.ToLower());
                    }
                }
            }
        }

        private void GatherUnvalidatedTags()
        {
            Tags.Clear();
            foreach (XPathNavigator xPathNavigator in _current.XmlDocument.CreateNavigator().Evaluate("/ea:AssetDeclaration/ea:Tags/child::*", _current.NamespaceManager) as XPathNodeIterator)
            {
                _current.Tags.Add(xPathNavigator.GetAttribute("name", string.Empty), xPathNavigator.GetAttribute("value", string.Empty));
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
                    OriginalValue = xPathNavigator.GetAttribute("value", string.Empty),
                    Name = xPathNavigator.GetAttribute("name", string.Empty),
                    IsOverride = xPathNavigator.GetAttribute("override", string.Empty) == "true"
                });
            }
        }

        private void GatherUnvalidatedIncludes()
        {
            InclusionItems.Clear();
            foreach (XPathNavigator xPathNavigator in _current.XmlDocument.CreateNavigator().Evaluate("/ea:AssetDeclaration/ea:Includes/child::*", _current.NamespaceManager) as XPathNodeIterator)
            {
                string lowerSource = xPathNavigator.GetAttribute("source", string.Empty).Trim().ToLower();
                string lowerPath = FileNameResolver.ResolvePath(SourceDirectory, lowerSource).ToLower();
                InclusionItem item = new InclusionItem(lowerSource, lowerPath, Enum.Parse<InclusionType>(xPathNavigator.GetAttribute("type", string.Empty), true));
                _current.InclusionItems.Add(item);
                if (item.Type == InclusionType.Instance)
                {
                    _current.DependentFiles.Add(lowerSource);
                }
            }
        }

        private void GatherUnvalidatedInstances()
        {
            SelfInstances.Clear();
            foreach (XmlNode node in _current.XmlDocument.SelectNodes("/ea:AssetDeclaration/child::*", _current.NamespaceManager))
            {
                if (node.Name != "Includes" && node.Name != "Tags" && node.Name != "Defines")
                {
                    InstanceDeclaration instance = new InstanceDeclaration(this)
                    {
                        XmlNode = node
                    };
                    if (!SelfInstances.TryAdd(instance))
                    {
                        InstanceDeclaration other = SelfInstances[instance.Handle];
                        if (instance.Handle.InstanceName == other.Handle.InstanceName)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.DuplicateInstance,
                                                                  "Duplicate instance: {0}, in {1} and {2}",
                                                                  instance,
                                                                  instance.Document.SourcePath,
                                                                  other.Document.SourcePath);
                        }
                        throw new BinaryAssetBuilderException(ErrorCode.DuplicateInstance,
                                                              "Duplicate instance: {0} (other is {1})",
                                                              instance,
                                                              other);
                    }
                }
            }
        }

        private void InternalLoad(string reason, LoadType type)
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
            LoadXml(type == LoadType.FromScratch);
            GatherUnvalidatedTags();
            GatherDefines();
            if (type != LoadType.InplaceLoad)
            {
                GatherUnvalidatedIncludes();
            }
            GatherUnvalidatedInstances();
            _current.State = DocumentState.Loaded;
            _current.IsLoaded = true;
        }

        private void Load(string reason)
        {
            _current.FromScratch();
            InternalLoad(reason, LoadType.FromScratch);
        }

        private void PrevalidatedLoad(string reason)
        {
            if (_current.State != DocumentState.Complete)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                      "Prevalidation load for {0} was called because of '{1}' when document has not been previously validated",
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
            ReloadedForInheritance = true;
        }

        private void NodeInsertedHandler(object sender, XmlNodeChangedEventArgs args)
        {
            IXmlLineInfo lineInfo = _current.XmlReader as IXmlLineInfo;
            if (!lineInfo.HasLineInfo())
            {
                return;
            }
            _current.NodeSourceInfoSet.AddFirst(new XmlNodeWithMetaData(args.Node, lineInfo.LineNumber));
        }

        private void ProcessExpressionsInNode(IExpressionEvaluator evaluator, XmlNode node)
        {
            if (node.Attributes is not null)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    if (attribute.Value.Length > 0 && attribute.Value[0] == '=')
                    {
                        attribute.Value = evaluator.Evaluate(attribute.Value);
                    }
                }
            }
            if (node.Value is not null && node.Value.Length > 0 && node.Value[0] == '=')
            {
                node.Value = evaluator.Evaluate(node.Value);
            }
            if (node.ChildNodes is not null)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    ProcessExpressionsInNode(evaluator, childNode);
                }
            }
        }

        private void OverrideInstance(InstanceDeclaration instance)
        {
            if (instance.InheritFromHandle is not null)
            {
                XmlNode baseNode = null;
                InstanceDeclaration inheritInstance = FindInstance(instance.InheritFromHandle,
                                                                   instance.InheritFromHandle == instance.Handle ? FindLocation.Self : FindLocation.None,
                                                                   out FindLocation location);
                if (inheritInstance is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                          "Instance {0} attempts to inherit from or override non-existing instance {1}",
                                                          instance.Handle,
                                                          instance.InheritFromHandle);
                }
                if (!inheritInstance.IsInheritAble && location != FindLocation.Self)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                          "Instance {1} cannot be overriden because it is not of type BaseInheritableAsset",
                                                          instance.Handle,
                                                          instance.InheritFromHandle);
                }
                switch (location)
                {
                    case FindLocation.None:
                        throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                              "Instance {0} attempts to inherit from an instance {1} which could not be found",
                                                              instance.Handle,
                                                              instance.InheritFromHandle);
                    case FindLocation.Self:
                        if (inheritInstance.PrevalidationXmlHash == 0u)
                        {
                            OverrideInstance(inheritInstance);
                        }
                        baseNode = inheritInstance.XmlNode;
                        break;
                    case FindLocation.Tentative:
                        using (List<InclusionItem>.Enumerator enumerator = _current.InclusionItems.GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                if (enumerator.Current.Document == inheritInstance.Document)
                                {
                                    baseNode = inheritInstance.XmlNode;
                                    break;
                                }
                            }
                        }
                        break;
                    default:
                        throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                              "Instance {0}\n  in document '{1}'\n  attempts to inherit from instance {2}\n  from document '{3}'\n  which does not appear to be included by 'instance'",
                                                              instance.Handle,
                                                              instance.Document.SourcePath,
                                                              inheritInstance,
                                                              inheritInstance.Document.SourcePath);
                }
                if (baseNode is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                          "Instance {0} attempts to inherit from instance {1} but source XML is missing.",
                                                          instance.Handle,
                                                          instance.InheritFromHandle);
                }
                XmlNode child = NodeJoiner.Override(_current.DocumentProcessor.SchemaSet.Schemas, XmlDocument, baseNode, instance.XmlNode);
                XmlNode parent = instance.XmlNode.ParentNode;
                parent.RemoveChild(instance.XmlNode);
                parent.AppendChild(child);
                instance.XmlNode = child;
                instance.InheritFromXmlHash = inheritInstance.PrevalidationXmlHash;
            }
            XmlNode xmlNode = instance.XmlNode;
            instance.PrevalidationXmlHash = HashProvider.GetXmlHash(ref xmlNode);
        }

        private void VerifyInstance(BinaryAsset asset, InstanceDeclaration declaration)
        {
            if (_current.IsLoaded && !_current.DocumentProcessor.VerifierPlugins.GetPlugin(asset.Instance.Handle.TypeId).VerifyInstance(declaration))
            {
                _current.VerificationErrors = true;
                throw new BinaryAssetBuilderException(ErrorCode.GameDataVerification, "FATAL: An asset failed the Game Data verification step.");
            }
        }

        private void CompileInstance(BinaryAsset asset, InstanceDeclaration declaration)
        {
            _tracer.Message("{0}: Compiling {1}", Path.GetFileName(_current.SourcePath), asset.Instance.ToString());
            if (asset.Instance.XmlNode is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.DependencyCacheFailure, "Need to compile instance {0} but XML is not laoded. This is a bug.", asset.Instance);
            }
            if (declaration.HasCustomData)
            {
                declaration.CustomDataPath = Path.Combine(asset.CustomDataOutputDirectory, asset.FileBase + ".cdata");
                if (!Directory.Exists(asset.CustomDataOutputDirectory))
                {
                    Directory.CreateDirectory(asset.CustomDataOutputDirectory);
                }
            }
            DateTime now = DateTime.Now;
            IAssetBuilderPlugin plugin = _current.DocumentProcessor.Plugins.GetPlugin(asset.Instance.Handle.TypeId);
            asset.Buffer = plugin.ProcessInstance(asset.Instance);
            _current.DocumentProcessor.AddCompileTime(asset.Instance.Handle, DateTime.Now - now);
        }

        private XmlElement ReconstructAssetDeclaration(InstanceDeclaration instance)
        {
            XmlElement assetDeclaration = XmlDocument.CreateElement("AssetDeclaration", Settings.Current.AssetNamespace);
            XmlElement tags = XmlDocument.CreateElement("Tags", Settings.Current.AssetNamespace);
            XmlElement tag = XmlDocument.CreateElement("Tag", Settings.Current.AssetNamespace);
            XmlAttribute attribute = XmlDocument.CreateAttribute("name");
            attribute.Value = "SourceXml";
            tag.Attributes.Append(attribute);
            attribute = XmlDocument.CreateAttribute("tag");
            attribute.Value = LogicalSourcePath;
            tag.Attributes.Append(attribute);
            tags.AppendChild(tag);
            assetDeclaration.AppendChild(tags);
            assetDeclaration.AppendChild(instance.XmlNode);
            return assetDeclaration;
        }

        private void OutputIntermediateXml(InstanceDeclaration instance)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                NewLineOnAttributes = true,
                Encoding = Encoding.UTF8,
                Indent = true,
                IndentChars = "    "
            };
            string directory = Path.Combine(Settings.Current.IntermediateOutputDirectory, "FinalXml_" + Settings.Current.TargetPlatform.ToString());
            string instanceDirectory = Path.Combine(instance.Handle.TypeName, instance.Handle.InstanceName);
            Directory.CreateDirectory(directory);
            Directory.CreateDirectory(Path.Combine(directory, instance.Handle.TypeName));
            string fileName = Path.Combine(directory, instanceDirectory + Path.GetExtension(LogicalSourcePath));
            try
            {
                XmlWriter writer = XmlWriter.Create(fileName, settings);
                ReconstructAssetDeclaration(instance).WriteTo(writer);
                writer.Close();
            }
            catch (Exception ex)
            {
                _tracer.TraceWarning("Unable to output {0}, reason: {1}", instanceDirectory, ex.Message);
            }
        }

        private void HandleAssetReferenceType(XPathNavigator navigator, ref InstanceDeclaration instance, BinaryWriter refTypeIds, bool isAssetReference)
        {
            string instanceName = navigator.Value.Trim().Split('\\')[0];
            if (string.IsNullOrEmpty(instanceName))
            {
                return;
            }
            InstanceHandle other = new InstanceHandle(instanceName);
            string typeName = null;
            if (navigator.SchemaInfo.SchemaElement is not null)
            {
                typeName = GetRefTypeName(navigator.SchemaInfo.SchemaElement.UnhandledAttributes);
            }
            else if (navigator.SchemaInfo.SchemaAttribute is not null)
            {
                typeName = GetRefTypeName(navigator.SchemaInfo.SchemaAttribute.UnhandledAttributes);
            }
            if (typeName is null && navigator.SchemaInfo.SchemaType is not null)
            {
                typeName = GetRefTypeName(navigator.SchemaInfo.SchemaType.UnhandledAttributes);
                if (typeName is null && navigator.SchemaInfo.SchemaType.DerivedBy == XmlSchemaDerivationMethod.Extension)
                {
                    typeName = GetRefTypeName(navigator.SchemaInfo.SchemaType.BaseXmlSchemaType.UnhandledAttributes);
                }
            }
            if (typeName is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                      "Asset reference to '{0}' in '{1}' does not have type (xas:refType missing in schema).",
                                                      instanceName,
                                                      instance);
            }
            refTypeIds.Write(HashProvider.GetCaseSenstitiveSymbolHash(typeName));
            if (other.TypeId == 0u)
            {
                other.TypeName = typeName;
            }
            else if (isAssetReference)
            {
                XmlSchemaType instanceType = _current.DocumentProcessor.SchemaSet.GetXmlType(other.TypeName);
                XmlSchemaType referenceType = _current.DocumentProcessor.SchemaSet.GetXmlType(typeName);
                if (referenceType is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                          "Unable to establish schema type of underlying reference type '{0}'. Make sure it is defined and included in the schema set.",
                                                          typeName);
                }
                if (instanceType is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                          "Unable to establish schema type of referenced instance '{0}'. Make sure it is defined and included in the schema set.",
                                                          other.Name);
                }
                if (!XmlSchemaType.IsDerivedFrom(instanceType, referenceType, XmlSchemaDerivationMethod.None))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                          "Type of instance '{0}' referenced from '{1}' does not appear to be equal to or derived from required reference type '{2}'.",
                                                          other.Name,
                                                          instance.Handle.Name,
                                                          typeName);
                }
            }
            if (isAssetReference)
            {
                instance.ReferencedInstances.Add(other);
                navigator.SetValue($"{instanceName}\\{instance.ReferencedInstances.Count - 1}");
            }
            else
            {
                instance.WeakReferencedInstances.Add(other);
            }
        }

        private void HandleFileReferenceType(XPathNavigator navigator, ref InstanceDeclaration instance)
        {
            string path = navigator.Value.Trim().ToLower();
            TryGetFileHashItem(path, out FileHashItem hashItem);
            string referencePath = hashItem.Path.ToLower();
            _current.DependentFiles.Add(path);
            navigator.SetValue(referencePath);
            instance.ReferencedFiles.Add(path);
        }

        private void HandleReferenceType(InstanceDeclaration instance, XPathNavigator navigator, BinaryWriter refTypeIds)
        {
            if (navigator.SchemaInfo?.SchemaType is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Element {0} in instance {1} doesn't have a schema type", navigator.Name, instance);
            }
            bool isWeakReference = XmlSchemaType.IsDerivedFrom(navigator.SchemaInfo.SchemaType, _current.DocumentProcessor.SchemaSet.XmlWeakReferenceType, XmlSchemaDerivationMethod.None);
            bool isAssetReference = !isWeakReference && XmlSchemaType.IsDerivedFrom(navigator.SchemaInfo.SchemaType, _current.DocumentProcessor.SchemaSet.XmlAssetReferenceType, XmlSchemaDerivationMethod.None);
            if (isWeakReference || isAssetReference)
            {
                HandleAssetReferenceType(navigator, ref instance, refTypeIds, isAssetReference);
            }
            else if (XmlSchemaType.IsDerivedFrom(navigator.SchemaInfo.SchemaType, _current.DocumentProcessor.SchemaSet.XmlFileReferenceType, XmlSchemaDerivationMethod.None))
            {
                HandleFileReferenceType(navigator, ref instance);
            }
            else
            {
                if (_current.DocumentProcessor.SchemaSet.IsHashableType(navigator.SchemaInfo.SchemaType))
                {
                    HashProvider.RecordHash(navigator.SchemaInfo.SchemaType, navigator.Value);
                }
            }
        }

        private void ValidateInstances()
        {
            StringCollection derivedTypes = _current.DocumentProcessor.SchemaSet.GetDerivedTypes("BaseInheritableAsset");
            foreach (InstanceDeclaration instance in _current.SelfInstances)
            {
                ExtendedTypeInformation extendedTypeInformation = _current.DocumentProcessor.Plugins.GetExtendedTypeInformation(instance.Handle.TypeId);
                uint textHash = HashProvider.GetTextHash(extendedTypeInformation.ProcessingHash, DocumentProcessor.Version.ToString());
                instance.Handle.TypeHash = extendedTypeInformation.TypeHash;
                XmlNode node = instance.XmlNode;
                instance.Handle.InstanceHash = HashProvider.GetXmlHash(textHash, ref node);
                instance.ProcessingHash = extendedTypeInformation.ProcessingHash;
                if (derivedTypes is not null)
                {
                    instance.IsInheritAble = derivedTypes.Contains(instance.XmlNode.SchemaInfo.SchemaType.Name);
                }
                if (instance.Handle.TypeName != instance.XmlNode.SchemaInfo.SchemaType.Name)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.SchemaValidation, "Type name and element name do not match for {0}", instance.Handle);
                }
                if (instance.Handle.TypeHash == 0u)
                {
                    _tracer.TraceWarning("No type hash found for type {0}.", instance.Handle.TypeName);
                }
                if (Settings.Current.OutputIntermediateXml)
                {
                    OutputIntermediateXml(instance);
                }
                XPathNodeIterator pathNodeIterator = instance.XmlNode.CreateNavigator().SelectDescendants(string.Empty, SchemaSet.XmlNamespace, true);
                MemoryStream stream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(stream);
                foreach (XPathNavigator navigator in pathNodeIterator)
                {
                    HandleReferenceType(instance, navigator, writer);
                    if (navigator.HasAttributes)
                    {
                        navigator.MoveToFirstAttribute();
                        do
                        {
                            HandleReferenceType(instance, navigator, writer);
                        }
                        while (navigator.MoveToNextAttribute());
                        navigator.MoveToParent();
                    }
                    if (navigator.SchemaInfo?.SchemaType?.Name is not null)
                    {
                        navigator.CreateAttribute(string.Empty, "TypeId", string.Empty, HashProvider.GetCaseSenstitiveSymbolHash(navigator.SchemaInfo.SchemaType.Name).ToString());
                    }
                }
                foreach (string referencedFile in instance.ReferencedFiles)
                {
                    TryGetFileHashItem(referencedFile, out FileHashItem hashItem);
                    writer.Write(hashItem.Hash);
                }
                if (stream.Length > 0L)
                {
                    instance.Handle.InstanceHash ^= FastHash.GetHashCode(stream.GetBuffer());
                }
            }
        }

        private InstanceDeclaration ResolveReference(InstanceDeclaration parent, InstanceHandle referenceHandle, out FindLocation location)
        {
            InstanceDeclaration instance = FindInstance(referenceHandle, FindLocation.None, out location);
            if (instance is null)
            {
                InstanceHandle handle = new InstanceHandle(referenceHandle.TypeName, referenceHandle.InstanceName);
                StringCollection derivedTypes = _current.DocumentProcessor.SchemaSet.GetDerivedTypes(referenceHandle.TypeName);
                if (derivedTypes is not null)
                {
                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (string str in derivedTypes)
                    {
                        handle.TypeName = str;
                        InstanceDeclaration other = FindInstance(handle, FindLocation.None, out FindLocation otherLocation);
                        if (other is not null)
                        {
                            instance = other;
                            location = otherLocation;
                            if (count > 0)
                            {
                                sb.Append(", ");
                            }
                            sb.AppendFormat("'{0}'", handle.Name);
                            ++count;
                        }
                    }
                    if (count > 1)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                              "Reference to instance '{0}' from '{1}' in 'file://{2}' is ambiguous. Possible matches: {3}.",
                                                              referenceHandle.Name,
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
            if (instance.ValidatedReferencedInstances is not null)
            {
                foreach (InstanceHandle referencedInstance in instance.ValidatedReferencedInstances)
                {
                    InstanceDeclaration other = ResolveReference(instance, referencedInstance, out FindLocation location);
                    if (other is not null && location != FindLocation.External)
                    {
                        AddOutputInstance(other);
                    }
                }
            }
            else
            {
                instance.ValidatedReferencedInstances = new List<InstanceHandle>();
                instance.AllDependentInstances = new InstanceHandleSet();
                foreach (InstanceHandle referencedInstance in instance.ReferencedInstances)
                {
                    InstanceDeclaration other = ResolveReference(instance, referencedInstance, out FindLocation location);
                    if (other is not null)
                    {
                        if (location != FindLocation.External)
                        {
                            instance.AllDependentInstances.TryAdd(other.Handle);
                            AddOutputInstance(other);
                            if (other.AllDependentInstances is not null)
                            {
                                foreach (InstanceHandle dependentInstance in other.AllDependentInstances)
                                {
                                    instance.AllDependentInstances.TryAdd(dependentInstance);
                                }
                            }
                        }
                        instance.ValidatedReferencedInstances.Add(other.Handle);
                    }
                    else
                    {
                        if (Settings.Current.ErrorLevel > 0)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.UnknownReference, "Unknown referenced asset: {0}", referencedInstance);
                        }
                        if (_current.DocumentProcessor.MissingReferences.TryAdd(referencedInstance))
                        {
                            _tracer.TraceWarning("Unknown asset '{0}' referenced from '{1}' in 'file://{2}'", referencedInstance.Name, instance.Handle.Name, instance.Document.SourcePath);
                        }
                        instance.ValidatedReferencedInstances.Add(referencedInstance);
                    }
                }
                foreach (InstanceHandle referencedInstance in instance.WeakReferencedInstances)
                {
                    InstanceDeclaration other = ResolveReference(instance, referencedInstance, out FindLocation location);
                    if (other is not null && location == FindLocation.Tentative)
                    {
                        AddOutputInstance(other);
                        instance.ValidatedReferencedInstances.Add(other.Handle);
                    }
                }
                foreach (string referencedFile in instance.ReferencedFiles)
                {
                    if (!instance.Document.TryGetFileHashItem(referencedFile, out FileHashItem hashItem))
                    {
                        if (Settings.Current.ErrorLevel > 0)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.FileNotFound, "Referenced file not found: {0}", referencedFile);
                        }
                        _tracer.TraceWarning("Referenced file not found: {0}", referencedFile);
                    }
                }
            }
        }

        public void SetChanged(string reason)
        {
            _current.ChangeReason = reason ?? string.Empty;
            _current.Changed = true;
        }

        public void Reset()
        {
            _current.XmlDocument = null;
            if (!ReloadedForInheritance)
            {
                return;
            }
            State = DocumentState.Complete;
            ReloadedForInheritance = false;
        }

        public void ReInitialize(OutputManager outputManager)
        {
            if (_current.HashItem is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.DependencyCacheFailure, "File hashing information for cached document missing: {0}", _current.SourcePath);
            }
            string reason = null;
            if (_current.LastDocumentHash != _current.DocumentHash)
            {
                reason = "content changed";
            }
            else
            {
                UpdateDocumentHashes();
                if (_current.LastDependentFileHash != _current.DependentFileHash)
                {
                    reason = "dependent file changed";
                }
                else
                {
                    foreach (InstanceDeclaration instance in _current.SelfInstances)
                    {
                        BinaryAsset binaryAsset = outputManager.GetBinaryAsset(instance, false);
                        if (binaryAsset is not null && binaryAsset.GetLocation(AssetLocation.All, AssetLocationOption.None) == AssetLocation.None)
                        {
                            reason = "previous output missing";
                            break;
                        }
                        ExtendedTypeInformation extendedTypeInformation = _current.DocumentProcessor.Plugins.GetExtendedTypeInformation(instance.Handle.TypeId);
                        if (instance.Handle.TypeHash != extendedTypeInformation.TypeHash)
                        {
                            reason = "type hash changed";
                            break;
                        }
                        if (instance.ProcessingHash != extendedTypeInformation.ProcessingHash)
                        {
                            reason = "plugin output changed";
                            break;
                        }
                    }
                }
            }
            if (reason is not null)
            {
                Load(reason);
            }
            else if (_current.LastIncludePathHash != _current.IncludePathHash)
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
            InstanceHandleSet instanceHandles = new InstanceHandleSet();
            foreach (InstanceHandle requiredOverrideSource in requiredOverrideSources)
            {
                if (_current.SelfInstances.Contains(requiredOverrideSource))
                {
                    instanceHandles.Add(requiredOverrideSource);
                }
            }
            if (instanceHandles.Count > 0)
            {
                if (reason is null)
                {
                    reason = "inheritFrom target changed";
                }
                foreach (InstanceHandle instanceHandle in instanceHandles)
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
            if (_current.XmlDocument is not null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Document {0} attempted to load twice.", _current.SourcePath);
            }
            FileNameXmlResolver xmlResolver = FileNameResolver.GetXmlResolver(SourceDirectory);
            _current.XmlReader = File.Exists(_current.SourcePath)
                ? XmlReader.Create(_current.SourcePath)
                : XmlReader.Create(new StringReader("<?xml version='1.0' encoding='UTF-8'?>\n<AssetDeclaration xmlns=\"uri:ea.com:eala:asset\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n</AssetDeclaration>"));
            _current.XmlDocument = new XmlDocument();
            XmlReader reader = XIncludingReaderWrapper.GetReader(_current.XmlReader, xmlResolver) ?? _current.XmlReader;
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
                foreach (PathMapItem item in xmlResolver.Paths)
                {
                    _current.DependentFiles.Add(item.SourceUri.ToLower());
                }
            }
            _current.NamespaceManager = new XmlNamespaceManager(reader.NameTable);
            _current.NamespaceManager.AddNamespace("ea", "uri:ea.com:eala:asset");
            _current.NamespaceManager.AddNamespace("ms", "urn:schemas-microsoft-com:xslt");
        }

        public void InplaceLoad(string reason)
        {
            InternalLoad(reason, LoadType.InplaceLoad);
        }

        public void FromLastHack()
        {
            if (_current is not null)
            {
                return;
            }
            _current = new CurrentState();
            _current.FromLast(this, _last);
        }

        public void Open(DocumentProcessor documentProcessor, FileHashItem hashItem, string logicalPath, string configuration)
        {
            if (_current is not null && _current.State == DocumentState.Complete)
            {
                return;
            }
            _current = new CurrentState(documentProcessor, hashItem, logicalPath, configuration);
            if (_last is not null)
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
            if (_current is null || _last is not null)
            {
                return;
            }
            _last = new LastState(_current);
            foreach (InstanceDeclaration instance in _current.SelfInstances)
            {
                instance.MakeCacheable();
            }
        }

        public void MakeComplete()
        {
            _current.State = DocumentState.Complete;
            foreach (InstanceDeclaration instance in _current.SelfInstances)
            {
                instance.MakeComplete();
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
            if (args.Exception is XmlSchemaValidationException exception)
            {
                LinkedListNode<XmlNodeWithMetaData> node = _current.NodeSourceInfoSet.Find(new XmlNodeWithMetaData(exception.SourceObject as XmlNode, 0));
                if (node?.Value is not null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.SchemaValidation,
                                                          "XML validation error encountered in '{0}' near line {1}:\n    {2}",
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
            _current.XmlDocument.Validate(HandleValidationEvents);
            _current.NodeSourceInfoSet.Clear();
            _current.NodeSourceInfoSet = null;
            ValidateInstances();
            UpdateDocumentHashes();
        }

        public void EvaluateDefinitions()
        {
            IExpressionEvaluator evaluator = ExpressionEvaluatorWrapper.GetEvaluator(this);
            foreach (Definition definition in SelfDefines)
            {
                if (definition.OriginalValue is not null)
                {
                    definition.EvaluatedValue = null;
                    evaluator.EvaluateDefinition(definition);
                }
                if (AllDefines.TryGetValue(definition.Name, out Definition other) && definition.Document != other.Document && !definition.IsOverride)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.DuplicateDefine,
                                                          "Definition {0} defined in {1} is already defined in {2}",
                                                          definition.Name,
                                                          definition.Document.SourcePath,
                                                          other.Document.SourcePath);
                }
                AllDefines[definition.Name] = definition;
            }
        }

        public bool ValidateCachedDefines()
        {
            foreach (KeyValuePair<string, string> define in UsedDefines)
            {
                if (define.Value != AllDefines.GetEvaluatedValue(define.Key))
                {
                    return false;
                }
            }
            return true;
        }

        public InstanceDeclaration FindInstance(InstanceHandle handle, FindLocation skipLocation, out FindLocation location)
        {
            location = FindLocation.None;
            InstanceDeclaration result = null;
            if (_current.SelfInstances is not null && skipLocation != FindLocation.Self && _current.SelfInstances.TryGetValue(handle, out result))
            {
                location = FindLocation.Self;
                return result;
            }
            if (_current.AllInstances is not null && skipLocation != FindLocation.All && _current.AllInstances.TryGetValue(handle, out result))
            {
                location = FindLocation.All;
                return result;
            }
            if (_current.TentativeInstances is not null && skipLocation != FindLocation.Tentative && _current.TentativeInstances.TryGetValue(handle, out result))
            {
                location = FindLocation.Tentative;
                return result;
            }
            if (_current.ReferenceInstances is not null && skipLocation != FindLocation.External && _current.ReferenceInstances.TryGetValue(handle, out result))
            {
                location = FindLocation.External;
                return result;
            }
            return result;
        }

        public bool ValidateInheritFromSources()
        {
            foreach (InstanceDeclaration instance in SelfInstances)
            {
                if (instance.InheritFromHandle is not null)
                {
                    InstanceDeclaration inheritInstance = FindInstance(instance.InheritFromHandle,
                                                                       instance.InheritFromHandle == instance.Handle ? FindLocation.Self : FindLocation.None,
                                                                       out FindLocation location);
                    if (inheritInstance is null)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                              "Instance {0} attempts to inherit from non-existing instance {1}",
                                                              instance,
                                                              instance.InheritFromHandle);
                    }
                    switch (location)
                    {
                        case FindLocation.Self:
                            if (inheritInstance.PrevalidationXmlHash != instance.InheritFromXmlHash)
                            {
                                return false;
                            }
                            continue;
                        case FindLocation.Tentative:
                            bool isIncluded = false;
                            foreach (InclusionItem inclusionItem in _current.InclusionItems)
                            {
                                if (inclusionItem.Document == inheritInstance.Document)
                                {
                                    isIncluded = true;
                                    break;
                                }
                            }
                            if (!isIncluded)
                            {
                                throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                                      "Instance {0} attempts to inherit from instance {1} which is not directly included.",
                                                                      instance,
                                                                      instance.InheritFromHandle);
                            }
                            goto case FindLocation.Self;
                        default:
                            throw new BinaryAssetBuilderException(ErrorCode.InheritFromError,
                                                                  "Instance {0} attempts to inherit from instance {1} which is not included by 'instance'",
                                                                  instance,
                                                                  instance.InheritFromHandle);
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
            foreach (InstanceDeclaration instance in SelfInstances)
            {
                ProcessExpressionsInNode(evaluator, instance.XmlNode);
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
            if (ReloadedForInheritance)
            {
                return;
            }
            foreach (InstanceDeclaration instance in SelfInstances)
            {
                ExtendedTypeInformation extendedTypeInformation = _current.DocumentProcessor.Plugins.GetExtendedTypeInformation(instance.Handle.TypeId);
                instance.HasCustomData = extendedTypeInformation.HasCustomData;
                BinaryAsset binaryAsset = outputManager.GetBinaryAsset(instance, true);
                if (binaryAsset is not null)
                {
                    if (binaryAsset.GetLocation(AssetLocation.All, AssetLocationOption.None) == AssetLocation.None)
                    {
                        CompileInstance(binaryAsset, instance);
                    }
                    VerifyInstance(binaryAsset, instance);
                    AssetLocation location = binaryAsset.Commit();
                    CountCommitSource(location, ref instancesCompiledCount, ref instancesCopiedFromCacheCount);
                    if (location != AssetLocation.BasePatchStream)
                    {
                        _current.DocumentProcessor.AddLastWrittenAsset(binaryAsset);
                    }
                    if (!instance.IsInheritAble)
                    {
                        instance.XmlNode = null;
                    }
                }
            }
        }

        public void ProcessOverrides()
        {
            foreach (InstanceDeclaration instance in SelfInstances)
            {
                OverrideInstance(instance);
            }
        }

        public void RecordStringHashes()
        {
            foreach (InstanceDeclaration instance in _current.SelfInstances)
            {
                HashProvider.RecordHash(instance.Handle);
                foreach (InstanceHandle reference in instance.ReferencedInstances)
                {
                    HashProvider.RecordHash(reference);
                }
                foreach (InstanceHandle reference in instance.WeakReferencedInstances)
                {
                    HashProvider.RecordHash(reference);
                }
            }
        }

        public void StableSort(OutputManager outputManager)
        {
            _tracer.TraceInfo("Stable sorting assets");
            List<InstanceDeclaration> finalList = new List<InstanceDeclaration>();
            if (outputManager.BasePatchStreamManifest is not null)
            {
                _tracer.TraceInfo("Merging base stream assets from {0}", outputManager.BasePatchStream);
                StableSort_InitializeFromBaseManifest(outputManager, _current.OutputInstances, finalList);
            }
            _tracer.TraceInfo("Sorting by schema dependencies");
            TypeDepCompare depCompare = new TypeDepCompare(_current.DocumentProcessor.SchemaSet.AssetDependencies);
            _current.OutputInstances.Sort(depCompare);
            _tracer.TraceInfo("Sorting by asset dependencies");
            foreach (InstanceDeclaration instance in _current.OutputInstances)
            {
                int index = StableSort_CalcInsertPosition(finalList, instance, depCompare);
                finalList.Insert(index, instance);
            }
            _current.OutputInstances = finalList;
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
                if (binaryAsset is not null)
                {
                    AssetLocation location = binaryAsset.GetLocation(AssetLocation.All, AssetLocationOption.None);
                    if (location == AssetLocation.None)
                    {
                        location = binaryAsset.GetLocation(AssetLocation.Local | AssetLocation.Cache, AssetLocationOption.ForceUpdate);
                    }
                    if (location == AssetLocation.None)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Asset {0} not available", instance);
                    }
                    if ((location & AssetLocation.Output) == AssetLocation.None)
                    {
                        binaryAsset.Commit();
                    }
                    _current.OutputInstances.Add(instance);
                    if (Settings.Current.OutputAssetReport)
                    {
                        AssetReport.RecordAsset(instance, binaryAsset);
                    }
                }
            }
            if (Settings.Current.StableSort)
            {
                StableSort(outputManager);
            }
            else
            {
                _current.OutputInstances.Sort(new DependencyComparer());
            }
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            foreach (InstanceDeclaration outputInstance in _current.OutputInstances)
            {
                writer.Write(outputInstance.Handle.TypeId);
                writer.Write(outputInstance.Handle.TypeHash);
                writer.Write(outputInstance.Handle.InstanceId);
                writer.Write(outputInstance.Handle.InstanceHash);
                writer.Write(outputInstance.ReferencedInstances.Count);
            }
            _current.OutputChecksum = stream.Length <= 0L ? 0u : FastHash.GetHashCode(stream.GetBuffer());
            _current.OutputInstanceSet = null;
        }

        public void CacheFromDocument(AssetDeclarationDocument other)
        {
            if (other._last is not null)
            {
                _last = other._last;
            }
            else
            {
                if (other._current is null || _last is not null)
                {
                    return;
                }
                _last = new LastState(other._current);
                List<InstanceDeclaration> instances = new List<InstanceDeclaration>();
                foreach (InstanceDeclaration instance in other._current.SelfInstances)
                {
                    InstanceDeclaration newInstance = new InstanceDeclaration();
                    newInstance.CacheFromInstance(instance);
                    instances.Add(newInstance);
                }
                _last.SelfInstances = new List<InstanceDeclaration>(instances);
            }
        }

        public void ReadXml(Node node)
        {
            _last = new LastState();
            _last.ReadXml(node);
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
