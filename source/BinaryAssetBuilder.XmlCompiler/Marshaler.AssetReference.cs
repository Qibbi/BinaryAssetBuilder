using Relo;

public static partial class Marshaler
{
    private static unsafe void Marshal<T>(string text, AssetReference<T>* objT, Tracker state) where T : unmanaged
    {
        int index = text.IndexOf('\\');
        if (index == -1)
        {
            return;
        }
        uint value = uint.Parse(text.Substring(index + 1));
        state.AddReference((void*)objT, value);
    }

    private static unsafe void Marshal<T>(Value value, AssetReference<T>* objT, Tracker state) where T : unmanaged
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal<T>(Node node, AssetReference<T>* objT, Tracker state) where T : unmanaged
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal<T>(Value value, AssetReference<T>** objT, Tracker state) where T : unmanaged
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AssetReference<T>), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal<T>(Node node, AssetReference<T>** objT, Tracker state) where T : unmanaged
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AssetReference<T>), 1u);
        Marshal(node, *objT, state);
    }

    private static unsafe void Marshal<T, U>(string text, AssetReference<T, U>* objT, Tracker state) where T : unmanaged where U : unmanaged
    {
        int index = text.IndexOf('\\');
        if (index == -1)
        {
            return;
        }
        uint value = uint.Parse(text.Substring(index + 1));
        state.AddReference((void*)objT, value);
    }

    private static unsafe void Marshal<T, U>(Value value, AssetReference<T, U>* objT, Tracker state) where T : unmanaged where U : unmanaged
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal<T, U>(Node node, AssetReference<T, U>* objT, Tracker state) where T : unmanaged where U : unmanaged
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal<T, U>(Value value, AssetReference<T, U>** objT, Tracker state) where T : unmanaged where U : unmanaged
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AssetReference<T, U>), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal<T, U>(Node node, AssetReference<T, U>** objT, Tracker state) where T : unmanaged where U : unmanaged
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }
}