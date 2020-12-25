using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace BinaryAssetBuilder.Core
{
    public static class HashProvider
    {
        public const string StringHashesFile = "StringHashes.xml";

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(HashProvider), "Centralized facility to produce hashes from strings");
        private static IDictionary<string, string> _schemaNameToBinName;
        private static IDictionary<string, StringHashBin> _stringHashBins;
        private static readonly string _instanceIdTableName = "INSTANCEID";
        private static readonly string _typeIdTableName = "TYPEID";
        private static readonly uint _hashProviderVersion = GetTextHash("StringHashTable") ^ 2u;
        private static string _outputDirectory;

        public static readonly string StringBinEnumAttribute = "StringHashBin";
        public static readonly string StringTableAssetName = "StringHashTable";
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
                            if (Convert.ToUInt32(table.Attributes["Version"].Value) == _hashProviderVersion)
                            {
                                bin.ReadStringHashTable(table);
                            }
                            else
                            {
                                _tracer.TraceInfo("Old string hash file is out of date. If you encounter missing strings in the game (such as misisng ids), please delete the session cache file in {0} and rebuild", Settings.Current.SessionCacheDirectory);
                            }
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
            string path = Path.Combine(_outputDirectory, StringHashesFile);
            if (!File.Exists(path))
            {
                return;
            }
            LoadPreviousStringHashes(path);
        }

        public static string GetOutputDirectory()
        {
            return _outputDirectory;
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

        public static uint GetXmlHash(uint hash, XmlNode node)
        {
            HashingWriter writer = new HashingWriter(hash);
            XmlWriter xmlWriter = XmlWriter.Create(writer);
            node.WriteTo(xmlWriter);
            xmlWriter.Flush();
            writer.Flush();
            return writer.GetFinalHash();
        }

        public static uint GetXmlHash(XmlNode node)
        {
            return GetXmlHash(0u, node);
        }

        public static void InitializeStringHashes(string outputDir)
        {
            _outputDirectory = outputDir;
            _schemaNameToBinName = new Dictionary<string, string>();
            _stringHashBins = new Dictionary<string, StringHashBin>
            {
                { _instanceIdTableName, new StringHashBin(_instanceIdTableName, false) },
                { _typeIdTableName, new StringHashBin(_typeIdTableName, true) }
            };
            foreach (StringHashBinDescriptor hashBinDescriptor in Settings.Current.StringHashBinDescriptors)
            {
                _schemaNameToBinName.Add(hashBinDescriptor.SchemaType, hashBinDescriptor.Bin);
                _stringHashBins.Add(hashBinDescriptor.Bin, new StringHashBin(hashBinDescriptor.Bin, hashBinDescriptor.IsCaseSensitive));
            }
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
            _stringHashBins[_instanceIdTableName].RecordStringHash(handle.InstanceId, handle.InstanceName);
            _stringHashBins[_typeIdTableName].RecordStringHash(handle.TypeId, handle.TypeName);
        }

        public static void RecordHash(string binName, string str)
        {
            StringHashBin bin = _stringHashBins[binName];
            bin.RecordStringHash(GetTextHash(bin.IsCaseSensitive ? str : str.ToLower()), str);
        }

        public static void FinalizeStringHashes()
        {
            if (!Directory.Exists(_outputDirectory))
            {
                Directory.CreateDirectory(_outputDirectory);
            }
            XmlWriter xmlWriter = XmlWriter.Create(Path.Combine(_outputDirectory, StringHashesFile), new XmlWriterSettings
            {
                CloseOutput = true,
                Indent = true
            });
            xmlWriter.WriteStartElement("AssetDeclaration", SchemaSet.XmlNamespace);
            if (Settings.Current.OutputAssetReport)
            {
                AssetReport.WriteAssetReportInclude(xmlWriter);
            }
            foreach (KeyValuePair<string, StringHashBin> bin in _stringHashBins)
            {
                xmlWriter.WriteStartElement(StringTableAssetName);
                xmlWriter.WriteAttributeString("Version", _hashProviderVersion.ToString());
                bin.Value.WriteStringHashTable(xmlWriter);
                xmlWriter.WriteEndElement();

            }
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}
