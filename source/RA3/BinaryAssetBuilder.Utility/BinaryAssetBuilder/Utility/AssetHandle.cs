using System;

namespace BinaryAssetBuilder.Utility
{
    internal class AssetHandle : IComparable<AssetHandle>
    {
        private uint _instanceId;
        private uint _typeId;

        public uint InstanceId => _instanceId;
        public uint TypeId => _typeId;

        public AssetHandle()
        {
        }

        public AssetHandle(uint typeId, uint instanceId)
        {
            _typeId = typeId;
            _instanceId = instanceId;
        }

        public AssetHandle(AssetHandle src)
        {
            _instanceId = src._instanceId;
            _typeId = src._typeId;
        }

        public virtual int CompareTo(AssetHandle other)
        {
            if (_typeId != other._typeId)
            {
                return _typeId > other._typeId ? 1 : -1;
            }
            if (_instanceId == other._instanceId)
            {
                return 0;
            }
            return _instanceId > other._instanceId ? 1 : -1;
        }

        public override bool Equals(object obj)
        {
            return obj is AssetHandle objT && _instanceId == objT._instanceId && _typeId == objT._typeId;
        }

        public override int GetHashCode()
        {
            return (int)_instanceId ^ (int)_typeId;
        }
    }
}