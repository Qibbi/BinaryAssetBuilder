using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Project
{
    [DebuggerStepThrough, XmlType(Namespace = "urn:xmlns:ea.com:babproject"), Serializable]
    public class BinaryStream
    {
        [XmlElement] public StreamConfiguration[] Configuration { get; set; }
        [XmlAttribute] public string Source { get; set; }
    }
}
