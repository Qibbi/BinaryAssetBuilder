using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class FileItem : IXmlSerializable
    {
        public FileHashItem HashItem { get; set; }
        public AssetDeclarationDocument Document { get; set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            HashItem = new FileHashItem();
            HashItem.ReadXml(reader);
            if (reader.Name == "ad")
            {
                Document = new AssetDeclarationDocument();
                Document.ReadXml(reader);
            }
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("fi");
            HashItem.WriteXml(writer);
            Document.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}
