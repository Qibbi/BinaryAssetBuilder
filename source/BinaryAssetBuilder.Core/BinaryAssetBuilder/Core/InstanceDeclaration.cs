using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using BinaryAssetBuilder.Core.SageXml;
using BinaryAssetBuilder.Core.Xml;
using BinaryAssetBuilder.Utility;

namespace BinaryAssetBuilder.Core
{
    public class InstanceDeclaration : ISerializable
    {
        private sealed class LastState : ISerializable
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

            public LastState()
            {
            }

            public LastState(CurrentState current)
            {
                Handle = current.Handle;
                ProcessingHash = current.ProcessingHash;
                ReferencedInstances = current.ReferencedInstances.Count > 0 ? new List<InstanceHandle>(current.ReferencedInstances) : null;
                WeakReferencedInstances = current.WeakReferencedInstances.Count > 0 ? new List<InstanceHandle>(current.WeakReferencedInstances) : null;
                ReferencedFiles = current.ReferencedFiles.Count > 0 ? new List<string>(current.ReferencedFiles) : null;
                IsInheritable = current.IsInheritable;
                HasCustomData = current.HasCustomData;
                InheritFromHandle = current.InheritFromHandle;
                InheritFromXmlHash = current.InheritFromXmlHash;
                PrevalidationXmlHash = current.PrevalidationXmlHash;
            }

            public void ReadXml(Node node)
            {
                string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
                ProcessingHash = Convert.ToUInt32(values[0], CultureInfo.InvariantCulture);
                InheritFromXmlHash = Convert.ToUInt32(values[1], CultureInfo.InvariantCulture);
                PrevalidationXmlHash = Convert.ToUInt32(values[2], CultureInfo.InvariantCulture);
                IsInheritable = Convert.ToBoolean(values[3], CultureInfo.InvariantCulture);
                HasCustomData = Convert.ToBoolean(values[4], CultureInfo.InvariantCulture);
                Handle = new InstanceHandle();
                Handle.ReadXml(node.GetChildNode(nameof(Handle), null));
                Node inheritFromHandle = node.GetChildNode(nameof(InheritFromHandle), null);
                if (inheritFromHandle is not null)
                {
                    InheritFromHandle = new InstanceHandle();
                    InheritFromHandle.ReadXml(inheritFromHandle);
                }
                Marshaler.Marshal(node.GetChildNodes("ReferencedFile"), ref ReferencedFiles);
                Marshaler.Marshal(node.GetChildNodes("ReferencedInstance"), ref ReferencedInstances);
                Marshaler.Marshal(node.GetChildNodes("WeakReferencedInstance"), ref WeakReferencedInstances);
            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteAttributeString("d", $"{ProcessingHash};{InheritFromXmlHash};{PrevalidationXmlHash};{IsInheritable};{HasCustomData}");
                writer.WriteStartElement(nameof(Handle));
                Handle.WriteXml(writer);
                writer.WriteEndElement();
                if (InheritFromHandle is not null)
                {
                    writer.WriteStartElement(nameof(InheritFromHandle));
                    InheritFromHandle.WriteXml(writer);
                    writer.WriteEndElement();
                }
                if (ReferencedFiles is not null)
                {
                    foreach (string referencedFile in ReferencedFiles)
                    {
                        writer.WriteElementString("ReferencedFile", referencedFile);
                    }
                }
                if (ReferencedInstances is not null)
                {
                    foreach (InstanceHandle referencedInstance in ReferencedInstances)
                    {
                        writer.WriteStartElement("ReferencedInstance");
                        referencedInstance.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
                if (WeakReferencedInstances is not null)
                {
                    foreach (InstanceHandle weakReferencedInstance in WeakReferencedInstances)
                    {
                        writer.WriteStartElement("WeakReferencedInstance");
                        weakReferencedInstance.WriteXml(writer);
                        writer.WriteEndElement();
                    }
                }
            }
        }

        private sealed class CurrentState
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
                ReferencedInstances = last.ReferencedInstances is not null ? new List<InstanceHandle>(last.ReferencedInstances) : new List<InstanceHandle>();
                WeakReferencedInstances = last.WeakReferencedInstances is not null ? new List<InstanceHandle>(last.WeakReferencedInstances) : new List<InstanceHandle>();
                ReferencedFiles = last.ReferencedFiles is not null ? new List<string>(last.ReferencedFiles) : new List<string>();
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
        private CurrentState _current;

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
                _current.Handle = new InstanceHandle(value.Name,
                                                     (value.Attributes["id"] ?? throw new BinaryAssetBuilderException(ErrorCode.NoIdAttributeForAsset,
                                                                                                                      "Node of type {0} in 'file://{1}' has no id attribute",
                                                                                                                      value.Name,
                                                                                                                      _current.Document.SourcePath)).Value);
                XmlAttribute attribute = value.Attributes["inheritFrom"];
                if (attribute is not null && attribute.Value != string.Empty)
                {
                    _current.InheritFromHandle = attribute.Value.Contains(':') ? new InstanceHandle(attribute.Value) : new InstanceHandle(value.Name, attribute.Value);
                }
                value.Attributes.Remove(attribute);
            }
        }
        public bool IsInheritAble { get => _current.IsInheritable; set => _current.IsInheritable = value; }
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
            if (_current is not null)
            {
                return;
            }
            _current = new CurrentState(document);
            if (_last is not null)
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
            if (_last is null)
            {
                _last = new LastState(_current);
            }
        }

        public void CacheFromInstance(InstanceDeclaration current)
        {
            _last = new LastState(current._current);
        }

        public void ReadXml(Node node)
        {
            _last = new LastState();
            _last.ReadXml(node);
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
            return (obj as InstanceDeclaration)?.Handle == Handle;
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
