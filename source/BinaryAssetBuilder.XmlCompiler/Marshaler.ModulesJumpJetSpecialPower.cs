using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, JumpJetSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(JumpJetSpecialPowerModuleData.JumpRange), "0.0"), &objT->JumpRange, state);
        Marshal(node.GetChildNode(nameof(JumpJetSpecialPowerModuleData.ValidDecal), null), &objT->ValidDecal, state);
        Marshal(node.GetChildNode(nameof(JumpJetSpecialPowerModuleData.InvalidDecal), null), &objT->InvalidDecal, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
