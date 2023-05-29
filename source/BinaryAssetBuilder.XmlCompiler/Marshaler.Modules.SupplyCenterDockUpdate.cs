using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SupplyCenterDockUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SupplyCenterDockUpdateModuleData.ValueMultiplier), "1.0"), &objT->ValueMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(SupplyCenterDockUpdateModuleData.BonusScience), null), &objT->BonusScience, state);
        Marshal(node.GetAttributeValue(nameof(SupplyCenterDockUpdateModuleData.BonusScienceMultiplier), null), &objT->BonusScienceMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(SupplyCenterDockUpdateModuleData.DistributedDeposit), null), &objT->DistributedDeposit, state);
        Marshal(node, (DockUpdateModuleData*)objT, state);
    }
}
