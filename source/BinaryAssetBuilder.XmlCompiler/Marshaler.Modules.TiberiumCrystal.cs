using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TiberiumCrystalBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TiberiumCrystalBehaviorModuleData.NumBoxes), "0"), &objT->NumBoxes, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumCrystalBehaviorModuleData.ValuePerBox), "0"), &objT->ValuePerBox, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumCrystalBehaviorModuleData.GrowthStages), "1"), &objT->GrowthStages, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumCrystalBehaviorModuleData.TimeBetweenGrowthStages), "5s"), &objT->TimeBetweenGrowthStages, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumCrystalBehaviorModuleData.GrowthTimePerStage), "3s"), &objT->GrowthTimePerStage, state);
        Marshal(node.GetChildNode(nameof(TiberiumCrystalBehaviorModuleData.RadarColor), null), &objT->RadarColor, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
