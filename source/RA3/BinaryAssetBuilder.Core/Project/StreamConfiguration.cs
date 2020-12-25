using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Project
{

    [DebuggerStepThrough, XmlType(Namespace = "urn:xmlns:ea.com:babproject"), Serializable]
    public class StreamConfiguration
    {
        [XmlElement] public string[] BaseStreamSearchPath { get; set; }
        [XmlElement] public StreamReference[] StreamReference { get; set; }
        [DefaultValue(""), XmlAttribute] public string Name { get; set; }
        [DefaultValue(false), XmlAttribute] public bool IsDefault { get; set; }
        [XmlAttribute] public string PatchStream { get; set; }
        [XmlAttribute] public string RelativeBasePath { get; set; }

        public StreamConfiguration()
        {
            Name = string.Empty;
            IsDefault = false;
        }
    }
}
