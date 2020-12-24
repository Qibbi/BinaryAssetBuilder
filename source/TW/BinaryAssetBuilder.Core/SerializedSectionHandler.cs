using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace BinaryAssetBuilder
{
    public class SerializedSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            XmlAttribute attribute = section.Attributes["serializedType"];
            if (attribute is null)
            {
                throw new ConfigurationErrorsException("Serialized type not specified.", section);
            }
            Type type = Type.GetType(attribute.Value, false);
            if (type is null)
            {
                throw new ConfigurationErrorsException("Serialized type not found or can not be instantiated");
            }
            XmlElement element = section.OwnerDocument.CreateElement(type.Name);
            while (section.FirstChild != null)
            {
                element.AppendChild(section.FirstChild);
            }
            while (section.Attributes.Count != 0)
            {
                element.Attributes.Append(section.Attributes[0]);
            }
            section.AppendChild(element);
            object obj;
            try
            {
                XmlSerializer serializer = new XmlSerializer(type);
                XmlNodeReader reader = new XmlNodeReader(element);
                obj = serializer.Deserialize(reader);
                reader.Close();
            }
            catch (XmlException ex)
            {
                throw new ConfigurationErrorsException("XML parsing error", ex);
            }
            return obj;
        }
    }
}
