using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentCampaign* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentCampaign.TowToken), null), &objT->TowToken, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCampaign.MissionToken), null), &objT->MissionToken, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCampaign.MissionBriefingToken), null), &objT->MissionBriefingToken, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentCampaign.LoadMusic), null), &objT->LoadMusic, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}