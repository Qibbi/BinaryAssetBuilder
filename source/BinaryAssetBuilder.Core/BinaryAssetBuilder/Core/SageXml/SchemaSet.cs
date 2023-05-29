using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;

namespace BinaryAssetBuilder.Core.SageXml
{
    public class SchemaSet
    {
        private sealed class SchemaHashTable : SortedDictionary<XmlSchema, uint>
        {
        }

        private sealed class DependencyList
        {
            public string TypeName;
            public readonly List<uint> Children = new List<uint>();
            public List<DependencyList> FixedUpChildren;
            public Set<uint> GrandChildren;

            public DependencyList(string typeName)
            {
                TypeName = typeName;
            }
        }

        public const string XmlNamespace = "uri:ea.com:eala:asset";
        public const string XmlSchemaNamespace = "uri:ea.com:eala:asset:schema";

        private readonly Dictionary<XmlSchemaType, bool> _hashableTypes = new Dictionary<XmlSchemaType, bool>();
        private readonly SortedDictionary<string, DateTime> _schemaPaths = new SortedDictionary<string, DateTime>();
        private string _currentSchema = "<unknown>";
        private readonly SortedDictionary<string, StringCollection> _inheritanceMap = new SortedDictionary<string, StringCollection>();
        private SortedDictionary<uint, DependencyList> _dependencyTree = new SortedDictionary<uint, DependencyList>();
        private readonly Set<uint> _circularCheck = new Set<uint>();

        public XmlSchemaSet Schemas { get; } = new XmlSchemaSet();
        public XmlSchemaType XmlBaseAssetType { get; private set; }
        public XmlSchemaType XmlBaseInheritableAsset { get; private set; }
        public XmlSchemaType XmlAssetReferenceType { get; private set; }
        public XmlSchemaType XmlWeakReferenceType { get; private set; }
        public XmlSchemaType XmlFileReferenceType { get; private set; }
        public SortedDictionary<uint, int> AssetDependencies { get; private set; }

        public SchemaSet(bool countDependencies)
        {
            LoadSchemas(countDependencies);
        }

        private void ReadSchema(string baseDirectory, string schemaFile)
        {
            schemaFile = Path.IsPathRooted(schemaFile) ? Path.GetFullPath(schemaFile) : Path.GetFullPath(Path.Combine(baseDirectory, schemaFile));
            _currentSchema = schemaFile;
            string lower = schemaFile.ToLowerInvariant();
            if (_schemaPaths.ContainsKey(lower))
            {
                return;
            }
            if (File.Exists(lower))
            {
                _schemaPaths.Add(lower, File.GetLastWriteTime(lower));
            }
            string schema = null;
            using (StreamReader streamReader = new StreamReader(schemaFile))
            {
                schema = streamReader.ReadToEnd();
            }
            using StringReader stringReader = new(schema);
            XmlReader reader = XmlReader.Create(stringReader);
            XmlSchema xmlSchema = XmlSchema.Read(reader, null);
            foreach (XmlSchemaInclude include in xmlSchema.Includes.Cast<XmlSchemaInclude>())
            {
                ReadSchema(Path.GetDirectoryName(schemaFile), include.SchemaLocation);
            }
            xmlSchema.Includes.Clear();
            Schemas.Add(xmlSchema);
        }

        private void BuildGrandchildren(DependencyList list)
        {
            if (list.FixedUpChildren is not null)
            {
                return;
            }
            list.FixedUpChildren = new List<DependencyList>();
            list.GrandChildren = new Set<uint>();
            foreach (uint child in list.Children)
            {
                if (_dependencyTree.TryGetValue(child, out DependencyList value))
                {
                    list.FixedUpChildren.Add(value);
                }
                list.GrandChildren.Add(child);
            }
            foreach (DependencyList fixedUpChild in list.FixedUpChildren)
            {
                BuildGrandchildren(fixedUpChild);
                if (fixedUpChild != list)
                {
                    foreach (uint grandChild in fixedUpChild.GrandChildren)
                    {
                        list.GrandChildren.Add(grandChild);
                    }
                }
            }
        }

        private void CountReference(uint typeId, XmlAttribute[] unhandled)
        {
            foreach (XmlAttribute xmlAttribute in unhandled)
            {
                if (xmlAttribute.LocalName == "refType")
                {
                    _dependencyTree[typeId].Children.Add(InstanceHandle.GetTypeId(xmlAttribute.Value));
                    break;
                }
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaSimpleType simple)
        {
            if (XmlSchemaType.IsDerivedFrom(simple, XmlAssetReferenceType, XmlSchemaDerivationMethod.None) && simple.UnhandledAttributes is not null)
            {
                CountReference(typeId, simple.UnhandledAttributes);
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaAttribute simple)
        {
            bool isAssetReference = false;
            if (simple.AttributeSchemaType is not null)
            {
                BuildAssetDependencies(typeId, simple.AttributeSchemaType);
                isAssetReference = XmlSchemaType.IsDerivedFrom(simple.AttributeSchemaType, XmlAssetReferenceType, XmlSchemaDerivationMethod.None);
            }
            if (isAssetReference && simple.UnhandledAttributes is not null)
            {
                CountReference(typeId, simple.UnhandledAttributes);
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaElement element)
        {
            bool isAssetReference = false;
            if (element.ElementSchemaType is not null)
            {
                BuildAssetDependencies(typeId, element.ElementSchemaType);
                isAssetReference = XmlSchemaType.IsDerivedFrom(element.ElementSchemaType, XmlAssetReferenceType, XmlSchemaDerivationMethod.None);
            }
            if (isAssetReference && element.UnhandledAttributes is not null)
            {
                CountReference(typeId, element.UnhandledAttributes);
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaObjectCollection items)
        {
            foreach (XmlSchemaObject xmlSchemaObject in items)
            {
                if (xmlSchemaObject is XmlSchemaElement element)
                {
                    BuildAssetDependencies(typeId, element);
                }
                if (xmlSchemaObject is XmlSchemaAttribute simple)
                {
                    BuildAssetDependencies(typeId, simple);
                }
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaParticle particle)
        {
            if (particle is XmlSchemaChoice xmlSchemaChoice)
            {
                BuildAssetDependencies(typeId, xmlSchemaChoice.Items);
            }
            if (particle is XmlSchemaSequence xmlSchemaSequence)
            {
                BuildAssetDependencies(typeId, xmlSchemaSequence.Items);
            }
            if (particle is XmlSchemaAll xmlSchemaAll)
            {
                BuildAssetDependencies(typeId, xmlSchemaAll.Items);
            }
            if (particle is XmlSchemaElement element)
            {
                BuildAssetDependencies(typeId, element);
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaComplexContentExtension complex)
        {
            if (complex.Attributes is not null)
            {
                BuildAssetDependencies(typeId, complex.Attributes);
            }
            if (complex.Particle is not null)
            {
                BuildAssetDependencies(typeId, complex.Particle);
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaSimpleContentExtension simple)
        {
            if (simple.Attributes is not null)
            {
                BuildAssetDependencies(typeId, simple.Attributes);
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaContentModel contentModel)
        {
            if (contentModel.Content is XmlSchemaComplexContentExtension complex)
            {
                BuildAssetDependencies(typeId, complex);
            }
            if (contentModel.Content is XmlSchemaSimpleContentExtension simple)
            {
                BuildAssetDependencies(typeId, simple);
            }
        }

        private void BuildAssetDependencies(uint typeId, XmlSchemaComplexType complex)
        {
            if (complex.Attributes is not null)
            {
                BuildAssetDependencies(typeId, complex.Attributes);
            }
            if (complex.Particle is not null)
            {
                BuildAssetDependencies(typeId, complex.Particle);
            }
            if (complex.ContentModel is not null)
            {
                BuildAssetDependencies(typeId, complex.ContentModel);
            }
        }
        private void BuildAssetDependencies(uint typeId, XmlSchemaType type)
        {
            uint id = 0;
            if (type.Name is not null)
            {
                id = InstanceHandle.GetTypeId(type.Name);
                if (_circularCheck.Contains(id))
                {
                    return;
                }
                _circularCheck.Add(id);
            }
            if (type.BaseXmlSchemaType is not null)
            {
                BuildAssetDependencies(typeId, type.BaseXmlSchemaType);
            }
            if (type is XmlSchemaComplexType complex)
            {
                BuildAssetDependencies(typeId, complex);
            }
            else if (type is XmlSchemaSimpleType simple)
            {
                BuildAssetDependencies(typeId, simple);
            }
            else
            {
                if (id == 0u)
                {
                    return;
                }
                _circularCheck.Remove(id);
            }
        }

        private void SetupHashableTypes()
        {
            foreach (StringHashBinDescriptor hashBinDescriptor in Settings.Current.StringHashBinDescriptors)
            {
                _hashableTypes.Add(Schemas.GlobalTypes[new XmlQualifiedName(hashBinDescriptor.SchemaTypeName, XmlNamespace)] as XmlSchemaType, true);
            }
        }

        private void SetupHelperSchemaTypes()
        {
            XmlBaseAssetType = Schemas.GlobalTypes[new XmlQualifiedName("BaseAssetType", XmlNamespace)] as XmlSchemaType;
            XmlBaseInheritableAsset = Schemas.GlobalTypes[new XmlQualifiedName("BaseInheritableAsset", XmlNamespace)] as XmlSchemaType;
            XmlAssetReferenceType = Schemas.GlobalTypes[new XmlQualifiedName("AssetReference", XmlNamespace)] as XmlSchemaType;
            XmlWeakReferenceType = Schemas.GlobalTypes[new XmlQualifiedName("WeakReference", XmlNamespace)] as XmlSchemaType;
            XmlFileReferenceType = Schemas.GlobalTypes[new XmlQualifiedName("FileReference", XmlNamespace)] as XmlSchemaType;
            SetupHashableTypes();
        }

        private bool FlattenInheritanceTree(string typeName, SortedDictionary<string, StringCollection> dictionary)
        {
            if (_inheritanceMap.ContainsKey(typeName))
            {
                return true;
            }
            if (!dictionary.TryGetValue(typeName, out StringCollection collection))
            {
                return false;
            }
            StringCollection nCollection = new StringCollection();
            foreach (string index in collection)
            {
                nCollection.Add(index);
                bool flag = true;
                if (!_inheritanceMap.ContainsKey(index))
                {
                    flag = FlattenInheritanceTree(index, dictionary);
                }
                if (flag)
                {
                    foreach (string str in _inheritanceMap[index])
                    {
                        nCollection.Add(str);
                    }
                }
            }
            _inheritanceMap.Add(typeName, nCollection);
            return true;
        }

        private void LoadSchemas(bool countDependencies)
        {
            try
            {
                ReadSchema(Directory.GetCurrentDirectory(), Settings.Current.SchemaPath);
            }
            catch (Exception ex)
            {
                throw new BinaryAssetBuilderException(ex, ErrorCode.ReadingSchema, "Error encountered in schema '{0}'", _currentSchema);
            }
            Schemas.Compile();
            SetupHelperSchemaTypes();
            SortedDictionary<string, StringCollection> dictionary = new SortedDictionary<string, StringCollection>
            {
                { "BaseAssetType", new StringCollection() }
            };
            foreach (XmlSchemaType xmlSchemaType in Schemas.GlobalTypes.Values)
            {
                if (XmlSchemaType.IsDerivedFrom(xmlSchemaType, XmlBaseAssetType, XmlSchemaDerivationMethod.None))
                {
                    if (countDependencies)
                    {
                        uint typeId = InstanceHandle.GetTypeId(xmlSchemaType.Name);
                        _dependencyTree[typeId] = new DependencyList(xmlSchemaType.Name);
                        BuildAssetDependencies(typeId, xmlSchemaType);
                    }
                    if (xmlSchemaType.BaseXmlSchemaType is not null && !string.IsNullOrEmpty(xmlSchemaType.BaseXmlSchemaType.Name))
                    {
                        if (!dictionary.TryGetValue(xmlSchemaType.BaseXmlSchemaType.Name, out StringCollection collection))
                        {
                            collection = new StringCollection();
                            dictionary.Add(xmlSchemaType.BaseXmlSchemaType.Name, collection);
                        }
                        collection.Add(xmlSchemaType.Name);
                    }
                }
            }
            if (countDependencies)
            {
                AssetDependencies = new SortedDictionary<uint, int>();
                foreach (KeyValuePair<uint, DependencyList> dependencies in _dependencyTree)
                {
                    BuildGrandchildren(dependencies.Value);
                    AssetDependencies[dependencies.Key] = dependencies.Value.GrandChildren.Count;
                }
                _dependencyTree.Clear();
                _dependencyTree = null;
            }
            foreach (string key in dictionary.Keys)
            {
                FlattenInheritanceTree(key, dictionary);
            }
        }

        public bool IsHashableType(XmlSchemaType type)
        {
            return _hashableTypes.ContainsKey(type);
        }

        public XmlSchemaType GetXmlType(string typeName)
        {
            try
            {
                return Schemas.GlobalTypes[new XmlQualifiedName(typeName, XmlNamespace)] as XmlSchemaType;
            }
            catch
            {
                return null;
            }
        }

        public void ReloadIfchanged(bool countDependencies)
        {
            bool reload = false;
            if (countDependencies && AssetDependencies is null)
            {
                reload = true;
            }
            if (_schemaPaths is not null)
            {
                string lower = Settings.Current.SchemaPath.ToLowerInvariant();
                if (_schemaPaths.TryGetValue(lower, out DateTime dateTime))
                {
                    if (!File.Exists(lower) || File.GetLastWriteTime(lower) != dateTime)
                    {
                        reload = true;
                    }
                    else
                    {
                        foreach (KeyValuePair<string, DateTime> schemaPath in _schemaPaths)
                        {
                            if (!File.Exists(schemaPath.Key) || File.GetLastWriteTime(schemaPath.Key) != schemaPath.Value)
                            {
                                reload = true;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                reload = true;
            }
            if (reload)
            {
                LoadSchemas(countDependencies);
            }
        }

        public StringCollection GetDerivedTypes(string typeName)
        {
            _inheritanceMap.TryGetValue(typeName, out StringCollection result);
            return result;
        }
    }
}
