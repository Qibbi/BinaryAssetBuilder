using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace BinaryAssetBuilder.Core
{
    public static class HashProvider
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(HashProvider), "Centralized facility to produce hashes from strings");
        private static Dictionary<uint, string> _stringHashes = null;

        public static string StringHashesFile = "StringHashes.xml";

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
            _stringHashes = new Dictionary<uint, string>();
        }

        public static void RecordStringHash(string text, uint hashCode)
        {
            if (_stringHashes is null)
            {
                return;
            }
            if (_stringHashes.TryGetValue(hashCode, out string b))
            {
                if (!string.Equals(text, b, StringComparison.OrdinalIgnoreCase))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.HashCollision, $"Hash collision detected: '{text}' and '{b}' share the same hash value 0x{hashCode:x}");
                }
            }
            else
            {
                _stringHashes.Add(hashCode, text);
            }
        }

        public static void RecordHash(InstanceHandle handle)
        {
            RecordStringHash(handle.InstanceName, handle.InstanceId);
            RecordStringHash(handle.TypeName, handle.TypeId);
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
            xmlWriter.WriteStartElement("StringHashTable");
            xmlWriter.WriteAttributeString("id", "TheStringTable");
            if (_stringHashes != null)
            {
                foreach (KeyValuePair<uint, string> stringHash in _stringHashes)
                {
                    xmlWriter.WriteStartElement("StringAndHash");
                    xmlWriter.WriteAttributeString("Hash", stringHash.Key.ToString());
                    xmlWriter.WriteAttributeString("Text", stringHash.Value);
                    xmlWriter.WriteEndElement();
                }
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}
