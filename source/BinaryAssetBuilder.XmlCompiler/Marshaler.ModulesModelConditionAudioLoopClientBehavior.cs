using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ModelConditionAudioLoopClientBehaviorModuleDataModelConditionSound* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ModelConditionAudioLoopClientBehaviorModuleDataModelConditionSound.Sound), null), &objT->Sound, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionAudioLoopClientBehaviorModuleDataModelConditionSound.RequiredFlags), ""), &objT->RequiredFlags, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionAudioLoopClientBehaviorModuleDataModelConditionSound.ExcludedFlags), ""), &objT->ExcludedFlags, state);
    }

    public static unsafe void Marshal(Node node, ModelConditionAudioLoopClientBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(ModelConditionAudioLoopClientBehaviorModuleData.ModelConditionSound)), &objT->ModelConditionSound, state);
        Marshal(node, (ClientBehaviorModuleData*)objT, state);
    }
}
