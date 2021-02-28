using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InGameUIVoiceChatCommandSlots* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIVoiceChatCommandSlots.ToggleVoiceChatMode), null), &objT->ToggleVoiceChatMode, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIVoiceChatCommandSlots.VoiceChat), null), &objT->VoiceChat, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
