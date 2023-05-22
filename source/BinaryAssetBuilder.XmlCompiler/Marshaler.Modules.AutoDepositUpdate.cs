using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AutoDepositUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AutoDepositUpdateModuleData.DepositInterval), "0.0"), &objT->DepositInterval, state);
        Marshal(node.GetAttributeValue(nameof(AutoDepositUpdateModuleData.DepositAmount), "0"), &objT->DepositAmount, state);
        Marshal(node.GetAttributeValue(nameof(AutoDepositUpdateModuleData.InitialCaptureBonus), "0"), &objT->InitialCaptureBonus, state);
        Marshal(node.GetAttributeValue(nameof(AutoDepositUpdateModuleData.Upgrade), null), &objT->Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(AutoDepositUpdateModuleData.UpgradeBonusScalar), "1.0"), &objT->UpgradeBonusScalar, state);
        Marshal(node.GetAttributeValue(nameof(AutoDepositUpdateModuleData.GiveNoXP), "false"), &objT->GiveNoXP, state);
        Marshal(node.GetAttributeValue(nameof(AutoDepositUpdateModuleData.OnlyWhenGarrisoned), "false"), &objT->OnlyWhenGarrisoned, state);
        Marshal(node.GetAttributeValue(nameof(AutoDepositUpdateModuleData.Flags), nameof(AutoDepositFlagsType.NONE)), &objT->Flags, state);
        Marshal(node.GetChildNode(nameof(AutoDepositUpdateModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
