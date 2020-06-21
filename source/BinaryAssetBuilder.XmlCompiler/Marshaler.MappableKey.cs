using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MappableKey* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MappableKey.KeyDef), null), &objT->KeyDef, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}