using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace BinaryAssetBuilder.Core
{
    public static class HashProvider
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(HashProvider), "Centralized facility to produce hashes from strings");
        private static IDictionary<string, string> _schemaNameToBinName;
        private static IDictionary<string, StringHashBin> _stringHashBins;

        public static string StringHashesFile = "StringHashes.xml";
        public static readonly string StringHashesFileI = "StringHashesI.xml";
        public static readonly string StringBinEnumAttribute = "StringHashBin";
        public static readonly string StringTableAssetName = "StringHashTable";
        public static readonly string InstanceIdTableName = "INSTANCEID";
        public static readonly string TypeIdTableName = "TYPEID";
        public static readonly string StringHashTableName = "STRINGHASH";
        public static readonly string PoidTableName = "POID";

        private static void LoadPreviousStringHashes(string path)
        {
            _tracer.TraceInfo("Loading previous string hash file from {0}", path);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            try
            {
                foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Element && childNode.Name.Equals(StringTableAssetName))
                    {
                        XmlElement table = (XmlElement)childNode;
                        string key = table.Attributes[StringBinEnumAttribute].Value;
                        if (_stringHashBins.TryGetValue(key, out StringHashBin bin))
                        {
                            bin.ReadStringHashTable(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _tracer.TraceWarning("Unable to load previous string hashes: {0}", ex.Message);
            }
        }

        private static void LoadPreviousStringHashes()
        {
            string path = Path.Combine(Settings.Current.IntermediateOutputDirectory, StringHashesFileI);
            if (!File.Exists(path))
            {
                return;
            }
            LoadPreviousStringHashes(path);
        }

        public static uint GetTypeHash(Type type)
        {
            return GetTypeHash((uint)type.FullName.Length, type);
        }

        public static uint GetTypeHash(uint combine, Type type)
        {
            return FastHash.GetHashCode(FastHash.GetHashCode(combine, type.FullName), type.Module.ModuleVersionId.ToByteArray());
        }

        public static uint GetCaseInsenstitiveSymbolHash(string symbol)
        {
            return FastHash.GetHashCode(symbol.ToLower());
        }

        public static uint GetCaseSenstitiveSymbolHash(string symbol)
        {
            return FastHash.GetHashCode(symbol);
        }

        public static uint GetTextHash(string text)
        {
            return FastHash.GetHashCode(text);
        }

        public static uint GetTextHash(uint hash, string text)
        {
            return FastHash.GetHashCode(hash, text);
        }

        public static uint GetDataHash(byte[] data)
        {
            return FastHash.GetHashCode(data);
        }

        public static uint GetDataHash(uint hash, byte[] data)
        {
            return FastHash.GetHashCode(hash, data);
        }

        public static void InitializeStringHashes()
        {
            _schemaNameToBinName = new Dictionary<string, string>();
            _stringHashBins = new Dictionary<string, StringHashBin>
            {
                { InstanceIdTableName, new StringHashBin(InstanceIdTableName, false) },
                { TypeIdTableName, new StringHashBin(TypeIdTableName, true) },
                { StringHashTableName, new StringHashBin(StringHashTableName, true) },
                { PoidTableName, new StringHashBin(PoidTableName, false) }
            };
            LoadPreviousStringHashes();
        }

        public static void RecordHash(XmlSchemaType type, string str)
        {
            if (_schemaNameToBinName.TryGetValue(type.Name, out string binName))
            {
                RecordHash(binName, str);
            }
            else
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "StringHashBin does not exist for Schema type {0} but hashing was requested", type.Name);
            }
        }

        public static void RecordHash(InstanceHandle handle)
        {
            _stringHashBins[InstanceIdTableName].RecordStringHash(handle.InstanceId, handle.InstanceName);
            _stringHashBins[TypeIdTableName].RecordStringHash(handle.TypeId, handle.TypeName);
        }

        public static void RecordHash(string binName, string str)
        {
            StringHashBin bin = _stringHashBins[binName];
            bin.RecordStringHash(GetTextHash(bin.IsCaseSensitive ? str : str.ToLower()), str);
        }

        public static void FinalizeStringHashes(string dataRoot)
        {
            if (!Directory.Exists(dataRoot))
            {
                Directory.CreateDirectory(dataRoot);
            }
            XmlWriter xmlWriter = XmlWriter.Create(Path.Combine(dataRoot, StringHashesFile), new XmlWriterSettings
            {
                CloseOutput = true,
                Indent = true
            });
            xmlWriter.WriteStartElement("AssetDeclaration", SchemaSet.XmlNamespace);
            xmlWriter.WriteStartElement(StringTableAssetName);
            xmlWriter.WriteAttributeString("id", "TheStringTable");
            foreach (StringHashBin bin in _stringHashBins.Values)
            {
                bin.WriteStringHashTableElements(xmlWriter);
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
            xmlWriter = XmlWriter.Create(Path.Combine(Settings.Current.IntermediateOutputDirectory, StringHashesFileI), new XmlWriterSettings
            {
                CloseOutput = true,
                Indent = true
            });
            xmlWriter.WriteStartElement("AssetDeclaration", SchemaSet.XmlNamespace);
            foreach (StringHashBin bin in _stringHashBins.Values)
            {
                xmlWriter.WriteStartElement(StringTableAssetName);
                bin.WriteStringHashTable(xmlWriter);
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}
