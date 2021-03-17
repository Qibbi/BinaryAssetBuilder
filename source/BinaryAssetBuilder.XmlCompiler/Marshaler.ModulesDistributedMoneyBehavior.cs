using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DistributedMoneyBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DistributedMoneyBehaviorModuleData.Capacity), "1"), &objT->Capacity, state);
        Marshal(node.GetAttributeValue(nameof(DistributedMoneyBehaviorModuleData.OnDieSpawnPercentage), "1.0"), &objT->OnDieSpawnPercentage, state);
        Marshal(node.GetAttributeValue(nameof(DistributedMoneyBehaviorModuleData.RedistributeMoneyOnDeathType), "SUICIDED"), &objT->RedistributeMoneyOnDeathType, state);
        Marshal(node, (CreateModuleData*)objT, state);
    }
}
