using BinaryAssetBuilder.Core.Xml;
using System.Xml;

namespace BinaryAssetBuilder.Core.SageXml
{
    public class DefinitionPair : ISerializable
    {
        public string Name;
        public string EvaluatedValue;

        public void ReadXml(Node node)
        {
            string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
            Name = values[0];
            EvaluatedValue = values[1];
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("d", $"{Name};{EvaluatedValue}");
        }
    }
}
