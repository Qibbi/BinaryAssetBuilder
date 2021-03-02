using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.SageXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace BinaryAssetBuilder.Core.Hashing
{
    public static class HashProvider
    {
        private const string _instanceIdTableName = "INSTANCEID";
        private const string _typeIdTableName = "TYPEID";

        public const string StringHashesFileDefault = "StringHashes.xml";
        public const string StringTableAssetName = "StringHashTable";
        public const string StringBinEnumAttribute = "StringHashBin";

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(HashProvider), "Centralized facility to produce hashes from strings");
        private static Dictionary<string, string> _schemaNameToBinName;
        private static Dictionary<string, StringHashBin> _stringHashBins;
        private static readonly uint _hashProviderVersion = GetTextHash(StringTableAssetName) ^ 2u;
        private static string _outputDirectory;

        public static string StringHashesFile = StringHashesFileDefault;

        public static string OutputDirectory => _outputDirectory;

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
                                _tracer.TraceInfo("Old string hash file is out of date. If you encounter missing strings in the game (such as missing ids), please delete the session cache file and rebuild.");
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
                path = Path.Combine(_outputDirectory, StringHashesFileDefault);
                if (!File.Exists(path))
                {
                    return;
                }
            }
            LoadPreviousStringHashes(path);
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

        public static void InitializeStringHashes(string outputDir)
        {
            _outputDirectory = outputDir;
            _schemaNameToBinName = new Dictionary<string, string>();
            _stringHashBins = new Dictionary<string, StringHashBin>
            {
                { _instanceIdTableName, new StringHashBin(_instanceIdTableName, false) },
                { _typeIdTableName, new StringHashBin(_typeIdTableName, true) }
            };
            StringHashesFile = StringHashesFileDefault;
            foreach (StringHashBinDescriptor stringHashBin in Settings.Current.StringHashBinDescriptors)
            {
                _schemaNameToBinName.Add(stringHashBin.SchemaTypeName, stringHashBin.BinName);
                _stringHashBins.Add(stringHashBin.BinName, new StringHashBin(stringHashBin.BinName, stringHashBin.IsCaseSensitive));
            }
#if !VERSION5
            LoadPreviousStringHashes();
#endif
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
#if VERSION5
            xmlWriter.WriteStartElement(StringTableAssetName);
            xmlWriter.WriteAttributeString("id", "TheStringTable");
            foreach (StringHashBin bin in _stringHashBins.Values)
            {
                bin.WriteStringHashTableElements(xmlWriter);
            }
            xmlWriter.WriteEndElement();
#else
            foreach (KeyValuePair<string, StringHashBin> stringHashBin in _stringHashBins)
            {
                xmlWriter.WriteStartElement(StringTableAssetName);
                xmlWriter.WriteAttributeString("Version", _hashProviderVersion.ToString());
                stringHashBin.Value.WriteStringHashTable(xmlWriter);
                xmlWriter.WriteEndElement();
            }
#endif
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
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

        public static uint GetXmlHash(ref XmlNode node)
        {
            return GetXmlHash(0u, ref node);
        }

        public static uint GetXmlHash(uint hash, ref XmlNode node)
        {
            HashingWriter writer = new HashingWriter(hash);
            XmlWriter xmlWriter = XmlWriter.Create(writer);
            node.WriteTo(xmlWriter);
            xmlWriter.Flush();
            writer.Flush();
            return writer.GetFinalHash();
        }
    }
}
