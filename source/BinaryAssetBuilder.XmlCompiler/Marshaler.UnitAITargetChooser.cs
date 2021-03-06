using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TargetingBaseCompare* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetingDistanceCompare* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TargetingDistanceCompare.Tolerance), "30.0"), &objT->Tolerance, state);
        Marshal(node, (TargetingBaseCompare*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetingCombatChainCompare* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (TargetingBaseCompare*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetingInTurretArcCompare* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (TargetingBaseCompare*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetingCompareList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(TargetingCompareList.Compare)), &objT->Compare, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}