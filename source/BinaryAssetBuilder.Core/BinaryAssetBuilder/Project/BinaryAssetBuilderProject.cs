using BinaryAssetBuilder.Core.Xml;
using System.Xml;

namespace BinaryAssetBuilder.Project
{
    public class BinaryAssetBuilderProject : ISerializable
    {
        private BinaryStream[] _streams;

        public BinaryStream[] Streams { get => _streams; set => _streams = value; }

        public void ReadXml(Node node)
        {
            Marshaler.Marshal(node.GetChildNodes("Stream"), ref _streams);
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (BinaryStream stream in _streams)
            {
                writer.WriteStartElement("Stream");
                stream.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
}
