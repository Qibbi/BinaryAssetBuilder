using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CloneStoredObjectsSpecialPowerUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CloneStoredObjectsSpecialPowerUpdateModuleData.MinDestinationRadius), "0"), &objT->MinDestinationRadius, state);
        Marshal(node.GetAttributeValue(nameof(CloneStoredObjectsSpecialPowerUpdateModuleData.MaxDestinationRadius), "0"), &objT->MaxDestinationRadius, state);
        Marshal(node.GetAttributeValue(nameof(CloneStoredObjectsSpecialPowerUpdateModuleData.TriggerAttributeModifierOnClones), null), &objT->TriggerAttributeModifierOnClones, state);
        Marshal(node.GetAttributeValue(nameof(CloneStoredObjectsSpecialPowerUpdateModuleData.TriggerFX), null), &objT->TriggerFX, state);
        Marshal(node.GetAttributeValue(nameof(CloneStoredObjectsSpecialPowerUpdateModuleData.TargetFX), null), &objT->TargetFX, state);
        Marshal(node.GetAttributeValue(nameof(CloneStoredObjectsSpecialPowerUpdateModuleData.ClonedObjectLifetime), "0s"), &objT->ClonedObjectLifetime, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
