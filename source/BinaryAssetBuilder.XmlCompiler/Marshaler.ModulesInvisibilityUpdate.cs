using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InvisibilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InvisibilityUpdateModuleData.Options), ""), &objT->Options, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityUpdateModuleData.UpdatePeriod), "1s"), &objT->UpdatePeriod, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityUpdateModuleData.BroadcastRange), "0"), &objT->BroadcastRange, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityUpdateModuleData.OpacityMin), "40%"), &objT->OpacityMin, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityUpdateModuleData.OpacityMax), "100%"), &objT->OpacityMax, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityUpdateModuleData.NamedVoiceNameToUseAsVoiceMoveToStealthyArea), null), &objT->NamedVoiceNameToUseAsVoiceMoveToStealthyArea, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityUpdateModuleData.NamedVoiceNameToUseAsVoiceEnterStateMoveToStealthyArea), null), &objT->NamedVoiceNameToUseAsVoiceEnterStateMoveToStealthyArea, state);
        Marshal(node.GetChildNode(nameof(InvisibilityUpdateModuleData.InvisibilityNugget), null), &objT->InvisibilityNugget, state);
        Marshal(node.GetChildNode(nameof(InvisibilityUpdateModuleData.BroadcastObjectFilter), null), &objT->BroadcastObjectFilter, state);
        Marshal(node.GetChildNode(nameof(InvisibilityUpdateModuleData.RequiresUpgrade), null), &objT->RequiresUpgrade, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
