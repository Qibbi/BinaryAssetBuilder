using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StoreObjectsSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StoreObjectsSpecialPowerModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
