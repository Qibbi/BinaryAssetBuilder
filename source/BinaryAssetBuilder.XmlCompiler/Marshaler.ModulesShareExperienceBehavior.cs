using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ShareExperienceBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ShareExperienceBehaviorModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(ShareExperienceBehaviorModuleData.DropOff), "0"), &objT->DropOff, state);
        Marshal(node.GetAttributeValue(nameof(ShareExperienceBehaviorModuleData.Percentage), null), &objT->Percentage, state);
        Marshal(node.GetChildNode(nameof(ShareExperienceBehaviorModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
