using System.Xml;

namespace BinaryAssetBuilder.Core.Xml
{
    public interface ISerializable
    {
        void ReadXml(Node node);

        void WriteXml(XmlWriter writer);
    }
}
