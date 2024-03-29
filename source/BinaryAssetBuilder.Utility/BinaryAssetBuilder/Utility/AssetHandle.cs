﻿namespace BinaryAssetBuilder.Utility
{
    internal sealed class AssetHandle
    {
        private readonly uint _instanceId;
        private readonly uint _typeId;

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
