using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TeleportToCasterSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.MinDestinationRadius), "0"), &objT->MinDestinationRadius, state);
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.MaxDestinationRadius), "0"), &objT->MaxDestinationRadius, state);
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.MaxRangeFromCasterSP), "0"), &objT->MaxRangeFromCasterSP, state);
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.MaxRangeFromCasterMP), "0"), &objT->MaxRangeFromCasterMP, state);
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.TriggerFX), null), &objT->TriggerFX, state);
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.TargetFX), null), &objT->TargetFX, state);
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.RequireStoredObjects), "false"), &objT->RequireStoredObjects, state);
        Marshal(node.GetAttributeValue(nameof(TeleportToCasterSpecialPowerModuleData.KillObjectsIfPlacedInBadSpot), "false"), &objT->KillObjectsIfPlacedInBadSpot, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
