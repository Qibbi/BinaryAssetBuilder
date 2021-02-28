using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    public class XmlHelper
    {
        public static object ReadCollection(XmlReader reader, string name, Type type)
        {
            if (reader.Name != name)
            {
                return null;
            }
            reader.MoveToFirstAttribute();
            int num = reader.ReadContentAsInt();
            reader.MoveToElement();
            reader.Read();
            ArrayList result = new ArrayList();
            for (int idx = 0; idx < num; ++idx)
            {
                if (Activator.CreateInstance(type) is IXmlSerializable instance)
                {
                    instance.ReadXml(reader);
                    result.Add(instance);
                }
            }
            reader.Read();
            return result.ToArray(type);
        }

        public static void WriteCollection(XmlWriter writer, string name, ICollection collection)
        {
            if (collection is null)
            {
                return;
            }
            writer.WriteStartElement(name);
            writer.WriteAttributeString("c", collection.Count.ToString());
            foreach (object obj in collection)
            {
                if (obj is IXmlSerializable serializable)
                {
                    serializable.WriteXml(writer);
                }
            }
            writer.WriteEndElement();
        }

        public static string[] ReadStringArrayElement(XmlReader reader, string name)
        {
            if (reader.Name != name)
            {
                return null;
            }
            return reader.ReadElementString().Split(';');
        }

        public static void WriteStringArrayElement(XmlWriter writer, string name, string[] strings)
        {
            if (strings is null)
            {
                return;
            }
            writer.WriteElementString(name, string.Join(";", strings));
        }
    }
}
