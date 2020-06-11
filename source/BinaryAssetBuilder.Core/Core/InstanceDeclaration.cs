using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    // TODO:
    [Serializable]
    public class InstanceDeclaration : IXmlSerializable
    {
        [Serializable]
        private class LastState
        {
            public InstanceHandle Handle;
            public uint ProcessingHash;
            public List<InstanceHandle> ReferencedInstances;
            public List<InstanceHandle> WeakReferencedInstances;
            public List<string> ReferencedFiles;
            public InstanceHandle InheritFromHandle;
            public uint InheritFromXmlHash;
            public uint PrevalidationXmlHash;
            public bool IsInheritable;
            public bool HasCustomData;

            public LastState(CurrentState current)
            {
                Handle = current.Handle;
                ProcessingHash = current.ProcessingHash;
                ReferencedInstances = current.ReferencedInstances?.Count > 0 ? new List<InstanceHandle>(current.ReferencedInstances) : null;
                WeakReferencedInstances = current.WeakReferencedInstances?.Count > 0 ? new List<InstanceHandle>(current.WeakReferencedInstances) : null;
                ReferencedFiles = current.ReferencedFiles?.Count > 0 ? new List<string>(current.ReferencedFiles) : null;
                IsInheritable = current.IsInheritable;
                HasCustomData = current.HasCustomData;
                InheritFromHandle = current.InheritFromHandle;
                InheritFromXmlHash = current.InheritFromXmlHash;
                PrevalidationXmlHash = current.PrevalidationXmlHash;
            }

            public LastState(XmlReader reader)
            {
                reader.MoveToAttribute("d");
                string[] values = reader.Value.Split(';');
                ProcessingHash = Convert.ToUInt32(values[0]);
                InheritFromXmlHash = Convert.ToUInt32(values[1]);
                PrevalidationXmlHash = Convert.ToUInt32(values[2]);
                IsInheritable = Convert.ToBoolean(values[3]);
                HasCustomData = Convert.ToBoolean(values[4]);
                reader.MoveToElement();
                reader.Read();
                Handle = new InstanceHandle();
                Handle.ReadXml(reader);
                if (reader.Name == "ih")
                {
                    InheritFromHandle = new InstanceHandle();
                    InheritFromHandle.ReadXml(reader);
                }
                object obj = XmlHelper.ReadStringArrayElement(reader, "rf");
                ReferencedFiles = obj is null ? null : new List<string>(obj as string[]);
                obj = XmlHelper.ReadCollection(reader, "ri", typeof(InstanceHandle));
                ReferencedInstances = obj is null ? null : new List<InstanceHandle>(obj as InstanceHandle[]);
                obj = XmlHelper.ReadCollection(reader, "wri", typeof(InstanceHandle));
                WeakReferencedInstances = obj is null ? null : new List<InstanceHandle>(obj as InstanceHandle[]);
            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("id");
                writer.WriteAttributeString("d", $"{ProcessingHash};{InheritFromXmlHash};{PrevalidationXmlHash};{IsInheritable};{HasCustomData}");
                Handle?.WriteXml(writer);
                if (InheritFromHandle != null)
                {
                    InheritFromHandle.WriteXml(writer);
                }
                XmlHelper.WriteStringArrayElement(writer, "rf", ReferencedFiles?.ToArray());
                XmlHelper.WriteCollection(writer, "ri", ReferencedInstances);
                XmlHelper.WriteCollection(writer, "wri", WeakReferencedInstances);
                writer.WriteEndElement();
            }
        }

        private class CurrentState
        {
            public AssetDeclarationDocument Document;
            public InstanceHandle Handle;
            public uint ProcessingHash;
            public XmlNode XmlNode;
            public List<InstanceHandle> ReferencedInstances;
            public List<InstanceHandle> WeakReferencedInstances;
            public List<string> ReferencedFiles;
            public bool IsInheritable;
            public bool HasCustomData;
            public string CustomDataPath;
            public InstanceHandle InheritFromHandle;
            public uint InheritFromXmlHash;
            public uint PrevalidationXmlHash;
            public List<InstanceHandle> ValidatedReferencedInstances;
            public InstanceHandleSet AllDependentInstances;

            public CurrentState(AssetDeclarationDocument document)
            {
                Document = document;
            }

            public void FromLast(LastState last)
            {
                Handle = last.Handle;
                ProcessingHash = last.ProcessingHash;
                ReferencedInstances = last.ReferencedInstances != null ? new List<InstanceHandle>(last.ReferencedInstances) : new List<InstanceHandle>();
                WeakReferencedInstances = last.WeakReferencedInstances != null ? new List<InstanceHandle>(last.WeakReferencedInstances) : new List<InstanceHandle>();
                ReferencedFiles = last.ReferencedFiles != null ? new List<string>(last.ReferencedFiles) : new List<string>();
                IsInheritable = last.IsInheritable;
                HasCustomData = last.HasCustomData;
                InheritFromHandle = last.InheritFromHandle;
                InheritFromXmlHash = last.InheritFromXmlHash;
                PrevalidationXmlHash = last.PrevalidationXmlHash;
            }

            public void FromScratch()
            {
                ReferencedInstances = new List<InstanceHandle>();
                WeakReferencedInstances = new List<InstanceHandle>();
                ReferencedFiles = new List<string>();
            }
        }

        private CurrentState _current;

        public InstanceHandle Handle => _current.Handle;

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}