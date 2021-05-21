using BinaryAssetBuilder.Core.Hashing;
using BinaryAssetBuilder.Core.Xml;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace BinaryAssetBuilder.Core
{
    public class InstanceHandle : ISerializable, IComparable<InstanceHandle>
    {
        private string _instanceName = string.Empty;
        private string _typeName = string.Empty;
        private uint _instanceHash;
        private uint _typeHash;
        private string _name;
        private string _fullName;
        private string _fileBase;

        public uint InstanceId { get; private set; }
        public uint InstanceHash
        {
            get => _instanceHash;
            set
            {
                _instanceHash = value;
                _name = null;
                _fullName = null;
                _fileBase = null;
            }
        }
        public string InstanceName { get => _instanceName; private set => _instanceName = value; }
        public uint TypeId { get; private set; }
        public uint TypeHash
        {
            get => _typeHash;
            set
            {
                _typeHash = value;
                _name = null;
                _fullName = null;
                _fileBase = null;
            }
        }
        public string TypeName
        {
            get => _typeName;
            set
            {
                _typeName = value;
                TypeId = GetTypeId(_typeName);
            }
        }
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    _name = $"{_typeName}:{_instanceName}";
                }
                return _name;
            }
        }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(_fullName))
                {
                    _fullName = $"{_typeName}:{_instanceName} [{TypeId:x8}:{InstanceId:x8}]";
                }
                return _fullName;
            }
        }
        public string FileBase
        {
            get
            {
                if (string.IsNullOrEmpty(_fileBase))
                {
                    _fileBase = $"{TypeId:x8}.{_typeHash:x8}.{InstanceId:x8}.{_instanceHash:x8}";
                }
                return _fileBase;
            }
        }

        public InstanceHandle()
        {
        }

        public InstanceHandle(InstanceHandle src)
        {
            InstanceId = src.InstanceId;
            TypeId = src.TypeId;
            _instanceHash = src._instanceHash;
            _typeHash = src._typeHash;
            _instanceName = src._instanceName;
            _typeName = src._typeName;
        }

        public InstanceHandle(string typeName, string instanceName)
        {
            InstanceId = GetInstanceId(instanceName);
            TypeId = GetTypeId(typeName);
            _instanceName = instanceName;
            _typeName = typeName;
        }

        public InstanceHandle(string instanceName)
        {
            string[] typeAndName = instanceName.Split(':');
            if (typeAndName.Length > 2)
            {
                throw new ArgumentException($"Invalid instance name '{instanceName}'.");
            }
            _instanceName = typeAndName[^1];
            InstanceId = GetInstanceId(_instanceName);
            if (typeAndName.Length != 2)
            {
                return;
            }
            _typeName = typeAndName[0];
            TypeId = GetTypeId(_typeName);
        }

        public InstanceHandle(uint typeId, string instanceName) : this(instanceName)
        {
            TypeId = typeId;
        }

        public InstanceHandle(uint typeId, uint instanceId)
        {
            TypeId = typeId;
            InstanceId = instanceId;
        }

        public static bool operator ==(InstanceHandle x, InstanceHandle y)
        {
            return x is null || y is null ? x is null && y is null : x.InstanceId == y.InstanceId && x.TypeId == y.TypeId;
        }

        public static bool operator !=(InstanceHandle x, InstanceHandle y)
        {
            return x is null || y is null ? !(x is null) || !(y is null) : x.InstanceId != y.InstanceId || x.TypeId != y.TypeId;
        }

        public static uint GetTypeId(string typeName)
        {
            return HashProvider.GetCaseSensitiveSymbolHash(typeName);
        }

        public static uint GetInstanceId(string instanceName)
        {
            return HashProvider.GetCaseInsensitiveSymbolHash(instanceName);
        }

        public void ReadXml(Node node)
        {
            string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
            TypeId = Convert.ToUInt32(values[0]);
            TypeHash = Convert.ToUInt32(values[1]);
            InstanceId = Convert.ToUInt32(values[2]);
            InstanceHash = Convert.ToUInt32(values[3]);
            TypeName = values[4];
            InstanceName = values[5];
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("d", $"{TypeId};{TypeHash};{InstanceId};{InstanceHash};{TypeName};{InstanceName}");
        }

        [Conditional("DEBUG")]
        public void BreakOn(InstanceHandle handle)
        {
            if (!(this == handle))
            {
                return;
            }
            Debugger.Break();
        }

        public int CompareTo([AllowNull] InstanceHandle other)
        {
            if (InstanceId == other.InstanceId && TypeId == other.TypeId)
            {
                return 0;
            }
            if (TypeId < other.TypeId)
            {
                return -1;
            }
            if (TypeId > other.TypeId)
            {
                return 1;
            }
            if (InstanceId < other.InstanceId)
            {
                return -1;
            }
            return InstanceId > other.InstanceId ? 1 : 0;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            InstanceHandle other = (InstanceHandle)obj;
            return InstanceId == other.InstanceId && TypeId == other.TypeId;
        }

        public override int GetHashCode()
        {
            return (int)InstanceId ^ (int)TypeId;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
