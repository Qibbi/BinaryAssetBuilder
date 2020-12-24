using System;
using System.Collections.ObjectModel;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class InstanceHandleSet : KeyedCollection<int, InstanceHandle>
    {
        protected override int GetKeyForItem(InstanceHandle item)
        {
            return item.GetHashCode();
        }

        public bool TryAdd(InstanceHandle handle)
        {
            if (Contains(handle))
            {
                return false;
            }
            Add(handle);
            return true;
        }
    }
}