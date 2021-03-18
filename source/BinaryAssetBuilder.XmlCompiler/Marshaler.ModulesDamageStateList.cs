using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DamageState* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DamageState.MinHealth), "0"), &objT->MinHealth, state);
        Marshal(node.GetAttributeValue(nameof(DamageState.MaxHealth), "0"), &objT->MaxHealth, state);
        Marshal(node.GetAttributeValue(nameof(DamageState.ObjectStatus), null), &objT->ObjectStatus, state);
        Marshal(node.GetAttributeValue(nameof(DamageState.ModelConditions), null), &objT->ModelConditions, state);
    }

    public static unsafe void Marshal(Node node, DamageStateListModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(DamageStateListModuleData.Data)), &objT->Data, state);
        Marshal(node, (DamageModuleData*)objT, state);
    }
}
