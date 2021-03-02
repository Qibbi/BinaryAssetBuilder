using BinaryAssetBuilder.Core.Xml;
using System.Xml;

namespace BinaryAssetBuilder.Project
{
    public class StreamReference : ISerializable
    {
        private string _name;
        private string _configuration;
        private string _manifest;

        public string Name { get => _name; set => _name = value; }
        public string Configuration { get => _configuration; set => _configuration = value; }
        public string Manifest { get => _manifest; set => _manifest = value; }

        public void ReadXml(Node node)
        {
            Marshaler.Marshal(node.GetAttributeValue(nameof(Name), null), ref _name);
            Marshaler.Marshal(node.GetAttributeValue(nameof(Configuration), null), ref _configuration);
            Marshaler.Marshal(node.GetAttributeValue(nameof(Manifest), null), ref _manifest);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(Name), _name);
            writer.WriteAttributeString(nameof(Configuration), _configuration);
            writer.WriteAttributeString(nameof(Manifest), _manifest);
        }
    }
}
