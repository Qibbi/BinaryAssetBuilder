using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TeleportSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TeleportSpecialAbilityUpdateModuleData.BusyDuration), "0s"), &objT->BusyDuration, state);
        Marshal(node.GetAttributeValue(nameof(TeleportSpecialAbilityUpdateModuleData.DestinationWeapon), null), &objT->DestinationWeapon, state);
        Marshal(node.GetAttributeValue(nameof(TeleportSpecialAbilityUpdateModuleData.SourceWeapon), null), &objT->SourceWeapon, state);
        Marshal(node.GetAttributeValue(nameof(TeleportSpecialAbilityUpdateModuleData.MaxDistance), "0"), &objT->MaxDistance, state);
        Marshal(node.GetAttributeValue(nameof(TeleportSpecialAbilityUpdateModuleData.HeightToTeleportTo), "0"), &objT->HeightToTeleportTo, state);
        Marshal(node.GetAttributeValue(nameof(TeleportSpecialAbilityUpdateModuleData.FadeInTime), "0s"), &objT->FadeInTime, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
