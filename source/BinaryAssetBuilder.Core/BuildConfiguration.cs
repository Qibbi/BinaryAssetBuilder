using System.Xml.Serialization;

namespace BinaryAssetBuilder
{
    [XmlType("buildConfiguration")]
    public class BuildConfiguration
    {
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("postfix")] public string Postfix { get; set; }
        [XmlAttribute("streamPostfix")] public string StreamPostfix { get; set; }
        [XmlAttribute("appendPostfixToStream")] public bool AppendPostfixToStream { get; set; } = true;
        [XmlAttribute("artPaths")] public string ArtPaths { get; set; }
        [XmlAttribute("audioPaths")] public string AudioPaths { get; set; }
        [XmlAttribute("dataPaths")] public string DataPaths { get; set; }
    }
}
