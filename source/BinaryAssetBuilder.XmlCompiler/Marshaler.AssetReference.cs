using Relo;

public static partial class Marshaler
{
    public static unsafe void Marshal<T>(string text, AssetReference<T>* objT, Tracker state) where T : unmanaged
    {
        int index = text.IndexOf('\\');
        if (index == -1)
        {
            return;
        }
        uint value = uint.Parse(text.Substring(index + 1));
        state.AddReference((void*)objT, value);
    }

    public static unsafe void Marshal<T>(Value value, AssetReference<T>* objT, Tracker state) where T : unmanaged
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal<T>(Node node, AssetReference<T>* objT, Tracker state) where T : unmanaged
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }
}