using System;
using System.Collections.Generic;
using System.Xml;

namespace BinaryAssetBuilder.Core
{
    internal class StringHashBin
    {
        private static readonly string _stringTableEntryName = "StringAndHash";

        private readonly IDictionary<uint, string> _stringTable;
        private readonly string _name;

        public bool IsCaseSensitive { get; }

        public StringHashBin(string name, bool isCaseSensitive)
        {
            _name = name;
            _stringTable = new SortedDictionary<uint, string>();
            IsCaseSensitive = isCaseSensitive;
        }

        public void RecordStringHash(uint hashCode, string text)
        {
            if (_stringTable.TryGetValue(hashCode, out string b))
            {
                if (!string.Equals(text, b, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.HashCollision,
                                                          "Hash collision detected: '{0}' and '{1}' share the same hash value 0x{2:x}.",
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

        public void WriteStringHashTable(XmlWriter writer)
        {
            writer.WriteAttributeString("id", "StringHashBin_" + _name);
            writer.WriteAttributeString(HashProvider.StringBinEnumAttribute, _name);
            WriteStringHashTableElements(writer);
        }

        public void WriteStringHashTableElements(XmlWriter writer)
        {
            foreach (KeyValuePair<uint, string> stringAndHash in _stringTable)
            {
                writer.WriteStartElement(_stringTableEntryName);
                writer.WriteAttributeString("Hash", stringAndHash.Key.ToString());
                writer.WriteAttributeString("Text", stringAndHash.Value);
                writer.WriteEndElement();
            }
        }

        public void ReadStringHashTable(XmlElement table)
        {
            foreach (XmlNode childNode in table.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element && childNode.Name.Equals(_stringTableEntryName))
                {
                    XmlElement element = (XmlElement)childNode;
                    RecordStringHash(Convert.ToUInt32(element.Attributes["Hash"].Value), element.Attributes["Text"].Value);
                }
            }
        }
    }
}
