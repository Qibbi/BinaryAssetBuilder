using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace BinaryAssetBuilder.Core.Hashing
{
    internal sealed class StringHashBin
    {
        private const string _stringTableEntryName = "StringAndHash";

        private readonly SortedDictionary<uint, string> _stringTable = new SortedDictionary<uint, string>();
        private readonly string _name;

        public bool IsCaseSensitive { get; }

        public StringHashBin(string name, bool isCaseSensitive)
        {
            _name = name;
            IsCaseSensitive = isCaseSensitive;
        }

        public void RecordStringHash(uint hashCode, string text)
        {
            if (_stringTable.TryGetValue(hashCode, out string b))
            {
                if (!string.Equals(text, b, StringComparison.OrdinalIgnoreCase))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.HashCollision,
                                                          "Hash collision detected: '{0}' and '{1}' share the same hash value 0x{2:x}. If you believe this collision to be an error, please delete the string hash files from the session cache and rebuild.",
                                                          text,
                                                          b,
                                                          hashCode);
                }
            }
            else
            {
                _stringTable.Add(hashCode, text);
            }
        }

        public void WriteStringHashTableElements(XmlWriter writer)
        {
            foreach (KeyValuePair<uint, string> stringAndHash in _stringTable)
            {
                writer.WriteStartElement(_stringTableEntryName);
                writer.WriteAttributeString("Hash", stringAndHash.Key.ToString(CultureInfo.InvariantCulture));
                writer.WriteAttributeString("Text", stringAndHash.Value);
                writer.WriteEndElement();
            }
        }

        public void WriteStringHashTable(XmlWriter writer)
        {
            writer.WriteAttributeString("id", "StringHashBin_" + _name);
            writer.WriteAttributeString(HashProvider.StringBinEnumAttribute, _name);
            WriteStringHashTableElements(writer);
        }

        public void ReadStringHashTable(XmlElement table)
        {
            foreach (XmlNode childNode in table.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element && childNode.Name.Equals(_stringTableEntryName, StringComparison.Ordinal))
                {
                    XmlElement element = (XmlElement)childNode;
                    RecordStringHash(Convert.ToUInt32(element.Attributes["Hash"].Value, CultureInfo.InvariantCulture), element.Attributes["Text"].Value);
                }
            }
        }
    }
}
