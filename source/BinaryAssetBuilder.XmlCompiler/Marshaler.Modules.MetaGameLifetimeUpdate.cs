#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaGameLifetimeUpdate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaGameLifetimeUpdate.LifeTimeTurns), "1"), &objT->LifeTimeTurns, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
#endif
