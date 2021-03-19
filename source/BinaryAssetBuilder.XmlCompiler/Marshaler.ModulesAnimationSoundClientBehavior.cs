using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AnimationSoundInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AnimationSoundInfo.Sound), null), &objT->Sound, state);
        Marshal(node.GetAttributeValue(nameof(AnimationSoundInfo.RequiredMC), null), &objT->RequiredMC, state);
        Marshal(node.GetAttributeValue(nameof(AnimationSoundInfo.ExcludedMC), null), &objT->ExcludedMC, state);
        Marshal(node.GetAttributeValue(nameof(AnimationSoundInfo.Animation), null), &objT->Animation, state);
        Marshal(node.GetAttributeValue(nameof(AnimationSoundInfo.Frame), null), &objT->Frame, state);
    }

    public static unsafe void Marshal(Node node, AnimationSoundClientBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AnimationSoundClientBehaviorModuleData.MaxUpdateRangeCap), null), &objT->MaxUpdateRangeCap, state);
        Marshal(node.GetChildNodes(nameof(AnimationSoundClientBehaviorModuleData.Sound)), &objT->Sound, state);
        Marshal(node, (ClientBehaviorModuleData*)objT, state);
    }
}
