using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class DefinitionPair : IXmlSerializable
    {
        public string Name;
        public string EvaluatedValue;

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToAttribute("d");
            string[] values = reader.Value.Split(';');
            Name = values[0];
            EvaluatedValue = values[1];
            reader.MoveToElement();
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("dp");
            writer.WriteAttributeString("d", $"{Name};{EvaluatedValue}");
            writer.WriteEndElement();
        }
    }
}