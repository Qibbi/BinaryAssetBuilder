using BinaryAssetBuilder.Utility;
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

        private LastState _last;
        [NonSerialized] private CurrentState _current;

        public List<InstanceHandle> ValidatedReferencedInstances { get => _current.ValidatedReferencedInstances; set => _current.ValidatedReferencedInstances = value; }
        public InstanceHandleSet AllDependentInstances { get => _current.AllDependentInstances; set => _current.AllDependentInstances = value; }
        public List<InstanceHandle> ReferencedInstances => _current.ReferencedInstances;
        public List<InstanceHandle> WeakReferencedInstances => _current.WeakReferencedInstances;
        public List<string> ReferencedFiles => _current.ReferencedFiles;
        public AssetDeclarationDocument Document => _current.Document;
        public InstanceHandle Handle => _current.Handle;
        public uint ProcessingHash { get => _current.ProcessingHash; set => _current.ProcessingHash = value; }
        public XmlNode Node => _current.XmlNode;
        public XmlNode XmlNode
        {
            get => _current.XmlNode;
            set
            {
                _current.XmlNode = value;
                if (value is null)
                {
                    return;
                }
                XmlAttribute id = value.Attributes["id"];
                if (id != null)
                {
                    _current.Handle = new InstanceHandle(value.Name, id.Value);
                    XmlAttribute inheritFrom = value.Attributes["inheritFrom"];
                    if (inheritFrom != null && inheritFrom.Value != string.Empty)
                    {
                        _current.InheritFromHandle = inheritFrom.Value.Contains(':') ? new InstanceHandle(inheritFrom.Value) : new InstanceHandle(value.Name, inheritFrom.Value);
                    }
                    value.Attributes.Remove(inheritFrom);
                }
                else
                {
                    throw new BinaryAssetBuilderException(ErrorCode.NoIdAttributeForAsset,
                                                          "Node of type {0} in file://{1} has no id attribute",
                                                          value.Name,
                                                          _current.Document.SourcePath);
                }
            }
        }
        public bool IsInheritable { get => _current.IsInheritable; set => _current.IsInheritable = value; }
        public bool HasCustomData { get => _current.HasCustomData; set => _current.HasCustomData = value; }
        public string CustomDataPath { get => _current.CustomDataPath; set => _current.CustomDataPath = value; }
        public InstanceHandle InheritFromHandle => _current.InheritFromHandle;
        public uint InheritFromXmlHash { get => _current.InheritFromXmlHash; set => _current.InheritFromXmlHash = value; }
        public uint PrevalidationXmlHash { get => _current.PrevalidationXmlHash; set => _current.PrevalidationXmlHash = value; }

        public InstanceDeclaration()
        {
        }

        public InstanceDeclaration(AssetDeclarationDocument document)
        {
            Initialize(document);
        }

        public void Initialize(AssetDeclarationDocument document)
        {
            if (_current != null)
            {
                return;
            }
            _current = new CurrentState(document);
            if (_last != null)
            {
                _current.FromLast(_last);
            }
            else
            {
                _current.FromScratch();
            }
        }

        public void InitializePrecompiled(Asset asset)
        {
            _current = new CurrentState(null);
            _current.FromScratch();
            _current.Handle = new InstanceHandle(asset.TypeName, asset.InstanceName)
            {
                TypeHash = asset.TypeHash,
                InstanceHash = asset.InstanceHash
            };
            _current.IsInheritable = false;
            _current.HasCustomData = false;
        }

        public void MakeComplete()
        {
            _last = null;
        }

        public void MakeCacheable()
        {
            if (_last != null)
            {
                return;
            }
            _last = new LastState(_current);
        }

        public void CacheFromInstance(InstanceDeclaration current)
        {
            _last = new LastState(current._current);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            _last = new LastState(reader);
        }

        public void WriteXml(XmlWriter writer)
        {
            if (_last is null)
            {
                MakeCacheable();
            }
            _last.WriteXml(writer);
        }

        public override bool Equals(object obj)
        {
            return ((InstanceDeclaration)obj).Handle == Handle;
        }

        public override int GetHashCode()
        {
            return _current.Handle.GetHashCode();
        }

        public override string ToString()
        {
            return _current.Handle.ToString();
        }
    }
}