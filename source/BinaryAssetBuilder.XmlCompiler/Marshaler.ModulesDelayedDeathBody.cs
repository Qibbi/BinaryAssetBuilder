using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DelayedDeathBodyModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DelayedDeathBodyModuleData.DeathDelay), "0s"), &objT->DeathDelay, state);
        Marshal(node.GetAttributeValue(nameof(DelayedDeathBodyModuleData.ImmortalUntilDeathTime), "false"), &objT->ImmortalUntilDeathTime, state);
        Marshal(node.GetAttributeValue(nameof(DelayedDeathBodyModuleData.DeathFX), null), &objT->DeathFX, state);
        Marshal(node.GetAttributeValue(nameof(DelayedDeathBodyModuleData.DoHealthCheck), "false"), &objT->DoHealthCheck, state);
        Marshal(node.GetAttributeValue(nameof(DelayedDeathBodyModuleData.DelayedDeathPrerequisiteUpgrade), null), &objT->DelayedDeathPrerequisiteUpgrade, state);
        Marshal(node, (RespawnBodyModuleData*)objT, state);
    }
}
