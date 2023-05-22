using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, EmotionTrackerUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(EmotionTrackerUpdateModuleData.TauntAndPointDistance), "0.0"), &objT->TauntAndPointDistance, state);
        Marshal(node.GetAttributeValue(nameof(EmotionTrackerUpdateModuleData.HeroScanDistance), "0.0"), &objT->HeroScanDistance, state);
        Marshal(node.GetAttributeValue(nameof(EmotionTrackerUpdateModuleData.TauntAndPointUpdateDelay), "2s"), &objT->TauntAndPointUpdateDelay, state);
        Marshal(node.GetAttributeValue(nameof(EmotionTrackerUpdateModuleData.FearScanDistance), "0.0"), &objT->FearScanDistance, state);
        Marshal(node.GetAttributeValue(nameof(EmotionTrackerUpdateModuleData.QuarrelProbability), "0"), &objT->QuarrelProbability, state);
        Marshal(node.GetAttributeValue(nameof(EmotionTrackerUpdateModuleData.IgnoreVeterancy), "false"), &objT->IgnoreVeterancy, state);
        Marshal(node.GetAttributeValue(nameof(EmotionTrackerUpdateModuleData.ImmuneToFearLevel), "5"), &objT->ImmuneToFearLevel, state);
        Marshal(node.GetChildNode(nameof(EmotionTrackerUpdateModuleData.TauntAndPointExcluded), null), &objT->TauntAndPointExcluded, state);
        Marshal(node.GetChildNode(nameof(EmotionTrackerUpdateModuleData.AfraidOf), null), &objT->AfraidOf, state);
        Marshal(node.GetChildNode(nameof(EmotionTrackerUpdateModuleData.AlwaysAfraidOf), null), &objT->AlwaysAfraidOf, state);
        Marshal(node.GetChildNode(nameof(EmotionTrackerUpdateModuleData.PointAt), null), &objT->PointAt, state);
        Marshal(node.GetChildNodes(nameof(EmotionTrackerUpdateModuleData.AddEmotion)), &objT->AddEmotion, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
