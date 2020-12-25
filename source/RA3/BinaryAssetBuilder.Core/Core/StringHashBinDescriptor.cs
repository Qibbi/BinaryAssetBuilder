using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    [XmlType("Type")]
    public class StringHashBinDescriptor
    {
        [XmlAttribute] public string SchemaType { get; set; }
        [XmlAttribute] public string Bin { get; set; }
        [XmlAttribute] public bool IsCaseSensitive { get; set; }
    }
}
