using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LifetimeUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LifetimeUpdateModuleData.MinLifetime), "0s"), &objT->MinLifetime, state);
        Marshal(node.GetAttributeValue(nameof(LifetimeUpdateModuleData.MaxLifetime), "0s"), &objT->MaxLifetime, state);
        Marshal(node.GetAttributeValue(nameof(LifetimeUpdateModuleData.WaitForWakeUp), "false"), &objT->WaitForWakeUp, state);
        Marshal(node.GetAttributeValue(nameof(LifetimeUpdateModuleData.ScoreKill), "false"), &objT->ScoreKill, state);
        Marshal(node.GetAttributeValue(nameof(LifetimeUpdateModuleData.DeathType), null), &objT->DeathType, state);
        Marshal(node.GetAttributeValue(nameof(LifetimeUpdateModuleData.IgnoreProjectileState), null), &objT->IgnoreProjectileState, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
