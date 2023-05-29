using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LevelGrantSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LevelGrantSpecialPowerModuleData.Experience), "0"), &objT->Experience, state);
        Marshal(node.GetAttributeValue(nameof(LevelGrantSpecialPowerModuleData.RadiusEffect), "0"), &objT->RadiusEffect, state);
        Marshal(node.GetAttributeValue(nameof(LevelGrantSpecialPowerModuleData.LevelFX), null), &objT->LevelFX, state);
        Marshal(node.GetChildNode(nameof(LevelGrantSpecialPowerModuleData.AcceptanceFilter), null), &objT->AcceptanceFilter, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
