using BinaryAssetBuilder;
using Relo;
using SageBinaryData;
using System;
using System.Reflection;

public static partial class Marshaler
{
    private static readonly System.Collections.Generic.Dictionary<Type, Delegate> _marshalListItemMethods = new System.Collections.Generic.Dictionary<Type, Delegate>();

    private unsafe delegate void MarshalListItemDelegate<T>(Node node, T* objT, Tracker state) where T : unmanaged;

    public static unsafe void Marshal<T>(List list, List<T>* objT, Tracker state) where T : unmanaged
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform(&listCount);
        }
        objT->Count = listCount;
        if (count != 0u)
        {
            if (!_marshalListItemMethods.TryGetValue(typeof(T), out Delegate marshalDelegate))
            {
                MethodInfo method = typeof(Marshaler).GetMethod(nameof(Marshal), new[] { typeof(Node), typeof(T*), typeof(Tracker) });
                if (method is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot find marshal method for type '{0}'", typeof(T*).Name);
                }
                marshalDelegate = Delegate.CreateDelegate(typeof(MarshalListItemDelegate<T>), method);
                if (marshalDelegate is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot convert marshal method to delegate for type '{0}'", typeof(T*).Name);
                }
                _marshalListItemMethods.Add(typeof(T), marshalDelegate);
            }
            MarshalListItemDelegate<T> marshal = marshalDelegate as MarshalListItemDelegate<T>;
            using Tracker.Context context = state.Push((void**)&objT->Target, (uint)sizeof(T), count);
            for (uint idx = 0; idx < count; ++idx)
            {
                marshal(list.GetNextNode(), &objT->Target[idx], state);
            }
        }
    }

    public static unsafe void Marshal<T>(List list, List<AssetReference<T>>* objT, Tracker state) where T : unmanaged
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform(&listCount);
        }
        objT->Count = listCount;
        if (count != 0u)
        {
            using Tracker.Context context = state.Push((void**)&objT->Target, 4u, count);
            for (uint idx = 0; idx < count; ++idx)
            {
                Marshal(list.GetNextNode(), &objT->Target[idx], state);
            }
        }
    }
}