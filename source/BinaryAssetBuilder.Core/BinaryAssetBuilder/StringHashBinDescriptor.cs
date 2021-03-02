using BinaryAssetBuilder.Core.Xml;
using System.Xml;

namespace BinaryAssetBuilder
{
    public class StringHashBinDescriptor : ISerializable
    {
        private string _schemaTypeName;
        private string _binName;
        private bool _isCaseSensitive;

        public string SchemaTypeName { get => _schemaTypeName; set => _schemaTypeName = value; }
        public string BinName { get => _binName; set => _binName = value; }
        public bool IsCaseSensitive { get => _isCaseSensitive; set => _isCaseSensitive = value; }

        public void ReadXml(Node node)
        {
            Marshaler.Marshal(node.GetAttributeValue(nameof(SchemaTypeName), null), ref _schemaTypeName);
            Marshaler.Marshal(node.GetAttributeValue(nameof(BinName), null), ref _binName);
            Marshaler.Marshal(node.GetAttributeValue(nameof(IsCaseSensitive), null), ref _isCaseSensitive);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(SchemaTypeName), _schemaTypeName);
            writer.WriteAttributeString(nameof(BinName), _binName);
            writer.WriteAttributeString(nameof(IsCaseSensitive), _isCaseSensitive.ToString());
        }
    }
}
