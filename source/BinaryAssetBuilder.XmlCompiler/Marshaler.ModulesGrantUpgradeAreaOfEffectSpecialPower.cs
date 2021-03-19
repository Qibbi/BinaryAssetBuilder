using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GrantUpgradeAreaOfEffectSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GrantUpgradeAreaOfEffectSpecialPowerModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetChildNode(nameof(GrantUpgradeAreaOfEffectSpecialPowerModuleData.AcceptObjectFilter), null), &objT->AcceptObjectFilter, state);
        Marshal(node.GetChildNodes(nameof(GrantUpgradeAreaOfEffectSpecialPowerModuleData.UpgradeTemplate)), &objT->UpgradeTemplate, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
