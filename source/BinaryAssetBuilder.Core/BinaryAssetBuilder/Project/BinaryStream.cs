using BinaryAssetBuilder.Core.Xml;
using System.Xml;

namespace BinaryAssetBuilder.Project
{
    public class BinaryStream : ISerializable
    {
        private StreamConfiguration[] _configurations;
        private string _source;

        public StreamConfiguration[] Configurations { get => _configurations; set => _configurations = value; }
        public string Source { get => _source; set => _source = value; }

        public void ReadXml(Node node)
        {
            Marshaler.Marshal(node.GetChildNodes("Configuration"), ref _configurations);
            Marshaler.Marshal(node.GetAttributeValue(nameof(Source), null), ref _source);
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (StreamConfiguration configuration in _configurations)
            {
                writer.WriteStartElement("Configuration");
                configuration.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteAttributeString(nameof(Source), _source);
        }
    }
}
