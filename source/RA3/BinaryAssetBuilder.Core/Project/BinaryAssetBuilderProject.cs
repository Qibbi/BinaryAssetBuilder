using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Project
{
    [DebuggerStepThrough, XmlRoot(IsNullable = false, Namespace = "urn:xmlns:ea.com:babproject"), XmlType(AnonymousType = true, Namespace = "urn:xmlns:ea.com:babproject"), Serializable]
    public class BinaryAssetBuilderProject
    {
        [XmlElement] public BinaryStream[] Stream { get; set; }
    }
}
