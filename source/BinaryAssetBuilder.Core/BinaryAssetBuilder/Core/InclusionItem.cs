using BinaryAssetBuilder.Core.SageXml;
using BinaryAssetBuilder.Core.Xml;
using System;
using System.Xml;

namespace BinaryAssetBuilder.Core
{
    public class InclusionItem : ISerializable
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

        public void ReadXml(Node node)
        {
            string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
            LogicalPath = values[0];
            PhysicalPath = values[1];
            Type = Enum.Parse<InclusionType>(values[2]);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("d", $"{LogicalPath};{PhysicalPath};{Type}");
        }
    }
}
