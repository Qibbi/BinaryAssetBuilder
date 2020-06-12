using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class Definition : IXmlSerializable
    {
        public string Name;
        public string EvaluatedValue;
        public bool IsOverride;
        [NonSerialized] public string OriginalValue;
        [NonSerialized] public AssetDeclarationDocument Document;

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
            IsOverride = Convert.ToBoolean(values[2]);
            reader.MoveToElement();
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("ud");
            writer.WriteAttributeString("d", $"{Name};{EvaluatedValue};{IsOverride}");
            writer.WriteEndElement();
        }

        public override string ToString()
        {
            return $"{Name} = {EvaluatedValue ?? OriginalValue}";
        }
    }
}