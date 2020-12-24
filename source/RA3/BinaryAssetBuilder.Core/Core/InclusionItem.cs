using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class InclusionItem : IXmlSerializable
    {
        public string LogicalPath { get; private set; }
        public string PhysicalPath { get; set; }
        public InclusionType Type { get; private set; }
        public AssetDeclarationDocument Document { get; set; }

        public InclusionItem()
        {
        }

        public InclusionItem(string logicalPath, string physicalPath, InclusionType type)
        {
            LogicalPath = logicalPath;
            PhysicalPath = physicalPath;
            Type = type;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToAttribute("d");
            string[] values = reader.Value.Split(';');
            LogicalPath = values[0];
            PhysicalPath = values[1];
            Type = (InclusionType)Convert.ToInt32(values[2]);
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("ii");
            writer.WriteAttributeString("d", $"{LogicalPath};{PhysicalPath};{Type}");
            writer.WriteEndElement();
        }
    }
}