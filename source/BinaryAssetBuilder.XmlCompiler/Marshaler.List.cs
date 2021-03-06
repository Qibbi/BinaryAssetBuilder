using BinaryAssetBuilder.Core.Hashing;
using Relo;
using System;
using System.Reflection;

public static partial class Marshaler
{
    private unsafe delegate void MarshalListItemDelegate<T>(Node node, T* objT, Tracker state) where T : unmanaged;
    private unsafe delegate void MarshalPolymorphicListItemDelegate<T>(Node node, T** objT, Tracker state) where T : unmanaged;

    private static readonly System.Collections.Generic.Dictionary<Type, Delegate> _marshalListItemMethods = new System.Collections.Generic.Dictionary<Type, Delegate>();
    private static readonly System.Collections.Generic.Dictionary<Type, Delegate> _marshalPolymorphicListItemMethods = new System.Collections.Generic.Dictionary<Type, Delegate>();

    private static unsafe void Marshal<T>(List list, List<T>* objT, Tracker state) where T : unmanaged
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        state.InplaceEndianToPlatform(&listCount);
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
            using Tracker.Context context = state.Push((void**)&objT->Items, (uint)sizeof(T), count);
            for (uint idx = 0; idx < count; ++idx)
            {
                marshal(list.GetNextNode(), &objT->Items[idx], state);
            }
        }
    }

    private static unsafe void Marshal<T>(List list, List<TypedAssetId<T>>* objT, Tracker state) where T : unmanaged
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        state.InplaceEndianToPlatform(&listCount);
        objT->Count = listCount;
        if (count != 0u)
        {
            using Tracker.Context context = state.Push((void**)&objT->Items, (uint)sizeof(TypedAssetId<T>), count);
            for (uint idx = 0; idx < count; ++idx)
            {
                Marshal(list.GetNextNode(), &objT->Items[idx], state);
            }
        }
    }

    private static unsafe void Marshal<T>(List list, List<AssetReference<T>>* objT, Tracker state) where T : unmanaged
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        state.InplaceEndianToPlatform(&listCount);
        objT->Count = listCount;
        if (count != 0u)
        {
            using Tracker.Context context = state.Push((void**)&objT->Items, (uint)sizeof(AssetReference<T>), count);
            for (uint idx = 0; idx < count; ++idx)
            {
                Marshal(list.GetNextNode(), &objT->Items[idx], state);
            }
        }
    }

    private static unsafe void MarshalPolymorphicType<T, U>(Node node, U** objT, Tracker state) where T : unmanaged where U : unmanaged, IPolymophic
    {
        using (Tracker.Context context = state.Push((void**)objT, (uint)sizeof(T), 1u))
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
            marshal(node, (T*)*objT, state);
        }
        uint typeId = FastHash.GetHashCode(typeof(T).Name);
        state.InplaceEndianToPlatform(&typeId);
        *(uint*)*objT = typeId;
    }

    private static unsafe void MarshalUnknownPolymorphicType<T>(Node node, T** objT, Tracker state) where T : unmanaged, IPolymophic
    {
        using (Tracker.Context context = state.Push((void**)objT, (uint)sizeof(T), 1u))
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
            marshal(node, *objT, state);
        }
        uint typeId = FastHash.GetHashCode(typeof(T).Name);
        state.InplaceEndianToPlatform(&typeId);
        *(uint*)*objT = typeId;
    }

    private static unsafe void Marshal<T>(List list, PolymorphicList<T>* objT, Tracker state) where T : unmanaged
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        state.InplaceEndianToPlatform(&listCount);
        objT->Count = listCount;
        if (count != 0)
        {
            if (!_marshalPolymorphicListItemMethods.TryGetValue(typeof(T), out Delegate marshalDelegate))
            {
                MethodInfo method = typeof(Marshaler).GetMethod(nameof(Marshal), new[] { typeof(Node), typeof(T**), typeof(Tracker) });
                if (method is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot find marshal method for type '{0}'", typeof(T*).Name);
                }
                marshalDelegate = Delegate.CreateDelegate(typeof(MarshalPolymorphicListItemDelegate<T>), method);
                if (marshalDelegate is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot convert marshal method to delegate for type '{0}'", typeof(T*).Name);
                }
                _marshalPolymorphicListItemMethods.Add(typeof(T), marshalDelegate);
            }
            MarshalPolymorphicListItemDelegate<T> marshal = marshalDelegate as MarshalPolymorphicListItemDelegate<T>;
            using Tracker.Context context = state.Push((void**)&objT->Items, (uint)sizeof(T**), count);
            for (uint idx = 0; idx < count; ++idx)
            {
                marshal(list.GetNextNode(), &objT->Items[idx], state);
            }
        }
    }

    private static unsafe void Marshal<T>(Node node, PolymorphicList<T>* objT, Tracker state) where T : unmanaged
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(null), objT, state);
    }
}