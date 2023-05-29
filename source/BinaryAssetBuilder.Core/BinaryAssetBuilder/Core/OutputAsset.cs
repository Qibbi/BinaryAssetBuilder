using System;
using System.Globalization;
using System.Xml;
using BinaryAssetBuilder.Core.Xml;

namespace BinaryAssetBuilder.Core
{
    public class OutputAsset : ISerializable
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

        public void ReadXml(Node node)
        {
            string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
            InstanceFileSize = Convert.ToInt32(values[0], CultureInfo.InvariantCulture);
            RelocationFileSize = Convert.ToInt32(values[1], CultureInfo.InvariantCulture);
            ImportsFileSize = Convert.ToInt32(values[2], CultureInfo.InvariantCulture);
            Handle = new InstanceHandle();
            Handle.ReadXml(node.GetChildNode(nameof(Handle), null));
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("d", $"{InstanceFileSize};{RelocationFileSize};{ImportsFileSize}");
            writer.WriteStartElement(nameof(Handle));
            Handle.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}
