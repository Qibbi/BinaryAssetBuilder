using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HeightDieUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HeightDieUpdateModuleData.TargetHeight), null), &objT->TargetHeight, state);
        Marshal(node.GetAttributeValue(nameof(HeightDieUpdateModuleData.TargetHeightIncludesStructures), "false"), &objT->TargetHeightIncludesStructures, state);
        Marshal(node.GetAttributeValue(nameof(HeightDieUpdateModuleData.OnlyWhenMovingDown), "false"), &objT->OnlyWhenMovingDown, state);
        Marshal(node.GetAttributeValue(nameof(HeightDieUpdateModuleData.DestroyAttachedParticlesAtHeight), "-1.0"), &objT->DestroyAttachedParticlesAtHeight, state);
        Marshal(node.GetAttributeValue(nameof(HeightDieUpdateModuleData.SnapToGroundOnDeath), "false"), &objT->SnapToGroundOnDeath, state);
        Marshal(node.GetAttributeValue(nameof(HeightDieUpdateModuleData.InitialDelay), "0"), &objT->InitialDelay, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
