using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MinefieldBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MinefieldBehaviorModuleData.DetonationWeapon), null), &objT->DetonationWeapon, state);
        Marshal(node.GetAttributeValue(nameof(MinefieldBehaviorModuleData.DetonatedBy), null), &objT->DetonatedBy, state);
        Marshal(node.GetAttributeValue(nameof(MinefieldBehaviorModuleData.DetonationFX), null), &objT->DetonationFX, state);
        Marshal(node.GetAttributeValue(nameof(MinefieldBehaviorModuleData.NumVirtualMines), null), &objT->NumVirtualMines, state);
        Marshal(node.GetAttributeValue(nameof(MinefieldBehaviorModuleData.RepeatDetonateMoveThresh), "5.0"), &objT->RepeatDetonateMoveThresh, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
