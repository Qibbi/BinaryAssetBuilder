using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ClickReactionBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ClickReactionBehaviorModuleData.ClickReactionLifeTimer), "0"), &objT->ClickReactionLifeTimer, state);
        Marshal(node.GetAttributeValue(nameof(ClickReactionBehaviorModuleData.ReactionFrames1), "0"), &objT->ReactionFrames1, state);
        Marshal(node.GetAttributeValue(nameof(ClickReactionBehaviorModuleData.ReactionFrames2), "0"), &objT->ReactionFrames2, state);
        Marshal(node.GetAttributeValue(nameof(ClickReactionBehaviorModuleData.ReactionFrames3), "0"), &objT->ReactionFrames3, state);
        Marshal(node.GetAttributeValue(nameof(ClickReactionBehaviorModuleData.ReactionFrames4), "0"), &objT->ReactionFrames4, state);
        Marshal(node.GetAttributeValue(nameof(ClickReactionBehaviorModuleData.ReactionFrames5), "0"), &objT->ReactionFrames5, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
