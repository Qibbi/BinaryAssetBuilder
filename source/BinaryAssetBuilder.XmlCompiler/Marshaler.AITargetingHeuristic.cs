using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AITargetingHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AITargetingHeuristic.HeuristicType), null), &objT->HeuristicType, state);
        Marshal(node.GetAttributeValue(nameof(AITargetingHeuristic.ReturnTargetType), null), &objT->ReturnTargetType, state);
        Marshal(node.GetAttributeValue(nameof(AITargetingHeuristic.SortType), "Distance"), &objT->SortType, state);
        Marshal(node.GetAttributeValue(nameof(AITargetingHeuristic.VitalKindOf), null), &objT->VitalKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AITargetingHeuristic.ForbiddenKindOf), null), &objT->ForbiddenKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AITargetingHeuristic.Destroyed), "false"), &objT->Destroyed, state);
        Marshal(node.GetAttributeValue(nameof(AITargetingHeuristic.ThreatFinderRange), null), &objT->ThreatFinderRange, state);
        Marshal(node.GetAttributeValue(nameof(AITargetingHeuristic.SearchRange), "1500.0"), &objT->SearchRange, state);
        Marshal(node.GetChildNodes(nameof(AITargetingHeuristic.PrioritizedKindOf)), &objT->PrioritizedKindOf, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
