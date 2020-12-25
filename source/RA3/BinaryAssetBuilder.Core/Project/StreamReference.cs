using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Project
{

    [DebuggerStepThrough, XmlType(Namespace = "urn:xmlns:ea.com:babproject"), Serializable]
    public class StreamReference
    {
        [XmlAttribute] public string ReferenceName { get; set; }
        [XmlAttribute] public string ReferenceConfiguration { get; set; }
        [XmlAttribute] public string ReferenceManifest { get; set; }
    }
}
