using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class OutputAsset : IXmlSerializable
    {
        public InstanceHandle Handle;
        public int InstanceFileSize;
        public int RelocationFileSize;
        public int ImportsFileSize;

        public OutputAsset()
        {
        }

        public OutputAsset(BinaryAsset asset)
        {
            Handle = new InstanceHandle(asset.Instance.Handle);
            InstanceFileSize = asset.InstanceFileSize;
            RelocationFileSize = asset.RelocationFileSize;
            ImportsFileSize = asset.ImportsFileSize;
        }
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToAttribute("d");
            string[] values = reader.Value.Split(';');
            InstanceFileSize = Convert.ToInt32(values[0]);
            RelocationFileSize = Convert.ToInt32(values[1]);
            ImportsFileSize = Convert.ToInt32(values[2]);
            reader.MoveToElement();
            reader.Read();
            Handle = new InstanceHandle();
            Handle.ReadXml(reader);
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("oa");
            writer.WriteAttributeString("d", $"{InstanceFileSize};{RelocationFileSize};{ImportsFileSize}");
            Handle.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}