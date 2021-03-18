using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SlaughterHordeContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SlaughterHordeContainModuleData.CashBackPercent), null), &objT->CashBackPercent, state);
        Marshal(node.GetAttributeValue(nameof(SlaughterHordeContainModuleData.CanAlwaysEnterStatus), null), &objT->CanAlwaysEnterStatus, state);
        Marshal(node.GetChildNode(nameof(SlaughterHordeContainModuleData.CanAlwaysEnterObjectFilter), null), &objT->CanAlwaysEnterObjectFilter, state);
        Marshal(node, (HordeGarrisonContainModuleData*)objT, state);
    }
}
