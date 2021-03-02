using BinaryAssetBuilder.Core.Xml;
using System;
using System.Xml;

namespace BinaryAssetBuilder.Core
{
    public class BuildConfiguration : ISerializable, ICloneable
    {
        private string _name;
        private string _postfix;
        private string _streamPostfix;
        private bool _appendPostfixToStream = true;
        private string _artPaths;
        private string _audioPaths;
        private string _dataPaths;

        public string Name { get => _name; set => _name = value; }
        public string Postfix { get => _postfix; set => _postfix = value; }
        public string StreamPostfix { get => _streamPostfix; set => _streamPostfix = value; }
        public bool AppendPostfixToStream { get => _appendPostfixToStream; set => _appendPostfixToStream = value; }
        public string ArtPaths { get => _artPaths; set => _artPaths = value; }
        public string AudioPaths { get => _audioPaths; set => _audioPaths = value; }
        public string DataPaths { get => _dataPaths; set => _dataPaths = value; }

        public void ReadXml(Node node)
        {
            Marshaler.Marshal(node.GetAttributeValue(nameof(Name), null), ref _name);
            Marshaler.Marshal(node.GetAttributeValue(nameof(Postfix), null), ref _postfix);
            Marshaler.Marshal(node.GetAttributeValue(nameof(StreamPostfix), null), ref _streamPostfix);
            Marshaler.Marshal(node.GetAttributeValue(nameof(AppendPostfixToStream), "true"), ref _appendPostfixToStream);
            Marshaler.Marshal(node.GetAttributeValue(nameof(ArtPaths), null), ref _artPaths);
            Marshaler.Marshal(node.GetAttributeValue(nameof(AudioPaths), null), ref _audioPaths);
            Marshaler.Marshal(node.GetAttributeValue(nameof(DataPaths), null), ref _dataPaths);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString(nameof(Name), _name);
            writer.WriteAttributeString(nameof(Postfix), _postfix);
            writer.WriteAttributeString(nameof(StreamPostfix), _streamPostfix);
            writer.WriteAttributeString(nameof(AppendPostfixToStream), _appendPostfixToStream.ToString());
            writer.WriteAttributeString(nameof(ArtPaths), _artPaths);
            writer.WriteAttributeString(nameof(AudioPaths), _audioPaths);
            writer.WriteAttributeString(nameof(DataPaths), _dataPaths);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
