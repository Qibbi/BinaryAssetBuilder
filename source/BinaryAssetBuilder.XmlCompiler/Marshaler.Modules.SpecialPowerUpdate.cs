using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpecialPowerUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpecialPowerUpdateModuleData.SpecialPowerTemplate), null), &objT->SpecialPowerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerUpdateModuleData.StartsPaused), "false"), &objT->StartsPaused, state);
        Marshal(node.GetChildNode(nameof(SpecialPowerUpdateModuleData.InitiateSound), null), &objT->InitiateSound, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
