using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, VeterancyCrateCollideModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(VeterancyCrateCollideModuleData.RangeOfEffect), "0"), &objT->RangeOfEffect, state);
        Marshal(node.GetAttributeValue(nameof(VeterancyCrateCollideModuleData.AddsOwnerVeterancy), "false"), &objT->AddsOwnerVeterancy, state);
        Marshal(node.GetAttributeValue(nameof(VeterancyCrateCollideModuleData.IsPilot), "false"), &objT->IsPilot, state);
        Marshal(node.GetAttributeValue(nameof(VeterancyCrateCollideModuleData.AffectsUpToLevel), "0"), &objT->AffectsUpToLevel, state);
        Marshal(node, (CrateCollideModuleData*)objT, state);
    }
}
