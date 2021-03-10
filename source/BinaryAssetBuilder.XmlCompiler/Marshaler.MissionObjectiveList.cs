using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MissionObjectivePresentationSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MissionObjectivePresentationSettings.ID), null), &objT->ID, state);
        Marshal(node.GetAttributeValue(nameof(MissionObjectivePresentationSettings.Dialog), null), &objT->Dialog, state);
        Marshal(node.GetAttributeValue(nameof(MissionObjectivePresentationSettings.CameraFieldOfViewVariance), null), &objT->CameraFieldOfViewVariance, state);
        Marshal(node.GetAttributeValue(nameof(MissionObjectivePresentationSettings.UseDynamicZoom), "true"), &objT->UseDynamicZoom, state);
        Marshal(node.GetChildNode(nameof(MissionObjectivePresentationSettings.Duration), null), &objT->Duration, state);
        Marshal(node.GetChildNode(nameof(MissionObjectivePresentationSettings.CameraStartAngle), null), &objT->CameraStartAngle, state);
        Marshal(node.GetChildNode(nameof(MissionObjectivePresentationSettings.CameraEndAngle), null), &objT->CameraEndAngle, state);
        Marshal(node.GetChildNode(nameof(MissionObjectivePresentationSettings.CameraFieldOfView), null), &objT->CameraFieldOfView, state);
    }

    public static unsafe void Marshal(Node node, MissionObjectiveTag* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MissionObjectiveTag.Script), null), &objT->Script, state);
        Marshal(node.GetAttributeValue(nameof(MissionObjectiveTag.Description), null), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(MissionObjectiveTag.IsBonusObjective), "false"), &objT->IsBonusObjective, state);
        Marshal(node.GetChildNodes(nameof(MissionObjectiveTag.PresentationSettings)), &objT->PresentationSettings, state);
    }

    public static unsafe void Marshal(Node node, MissionObjectiveList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MissionObjectiveList.MissionObjectiveTag)), &objT->MissionObjectiveTag, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
