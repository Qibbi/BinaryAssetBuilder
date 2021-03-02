using BinaryAssetBuilder.Core.SageXml;
using BinaryAssetBuilder.Core.Xml;
using System.Xml;

namespace BinaryAssetBuilder.Core.Session
{
    public class FileItem : ISerializable
    {
        public FileHashItem HashItem { get; set; }
        public AssetDeclarationDocument Document { get; set; }

        public void ReadXml(Node node)
        {
            HashItem = new FileHashItem();
            HashItem.ReadXml(node.GetChildNode(nameof(FileHashItem), null));
            Node ad = node.GetChildNode(nameof(Document), null);
            if (ad is not null)
            {
                Document = new AssetDeclarationDocument();
                Document.ReadXml(ad);
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(nameof(FileHashItem));
            HashItem.WriteXml(writer);
            writer.WriteEndElement();
            if (Document is not null)
            {
                writer.WriteStartElement(nameof(Document));
                Document.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
}
