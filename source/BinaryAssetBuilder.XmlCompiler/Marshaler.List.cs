using BinaryAssetBuilder;
using Relo;
using System;
using System.Reflection;

public static partial class Marshaler
{
    private static readonly System.Collections.Generic.Dictionary<Type, MethodInfo> _marshalListItemMethods = new System.Collections.Generic.Dictionary<Type, MethodInfo>();

    public static unsafe void Marshal<T>(List list, List<T>* objT, Tracker tracker) where T : unmanaged
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        if (tracker.IsBigEndian)
        {
            tracker.ByteSwap32(&listCount);
        }
        objT->Count = listCount;
        if (count != 0u)
        {
            if (!_marshalListItemMethods.TryGetValue(typeof(T), out MethodInfo marshal))
            {
                marshal = typeof(Marshaler).GetMethod("Marshal", new[] { typeof(Node), typeof(T*), typeof(Tracker) });
                if (marshal is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot find marshal method for type '{0}'", typeof(T*).Name);
                }
                _marshalListItemMethods.Add(typeof(T), marshal);
            }
            tracker.Push((void**)&objT->Target, (uint)sizeof(T), count);
            for (uint idx = 0; idx < count; ++idx)
            {
                marshal.Invoke(null, new object[] { list.GetNextNode(), (IntPtr)(&objT->Target[idx]), tracker });
            }
            tracker.Pop();
        }
    }

    public static unsafe void Marshal<T>(List list, List<AssetReference<T>>* objT, Tracker tracker) where T : unmanaged
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        if (tracker.IsBigEndian)
        {
            tracker.ByteSwap32(&listCount);
        }
        objT->Count = listCount;
        if (count != 0u)
        {
            tracker.Push((void**)&objT->Target, (uint)sizeof(AssetReference<T>), count);
            for (uint idx = 0; idx < count; ++idx)
            {
                Marshal(list.GetNextNode(), &objT->Target[idx], tracker);
            }
            tracker.Pop();
        }
    }
}