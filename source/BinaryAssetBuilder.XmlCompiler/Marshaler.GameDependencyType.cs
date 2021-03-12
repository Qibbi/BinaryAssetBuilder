using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GameDependencyType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameDependencyType.RequiredModelConditionsAny), null), &objT->RequiredModelConditionsAny, state);
        Marshal(node.GetAttributeValue(nameof(GameDependencyType.ForbiddenModelConditions), null), &objT->ForbiddenModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(GameDependencyType.RequiredObjectStatusAny), null), &objT->RequiredObjectStatusAny, state);
        Marshal(node.GetChildNodes(nameof(GameDependencyType.RequiredObject)), &objT->RequiredObject, state);
        Marshal(node.GetChildNodes(nameof(GameDependencyType.ForbiddenUpgrade)), &objT->ForbiddenUpgrade, state);
        Marshal(node.GetChildNodes(nameof(GameDependencyType.NeededUpgrade)), &objT->NeededUpgrade, state);
        Marshal(node.GetChildNode(nameof(GameDependencyType.ObjectFilter), null), &objT->ObjectFilter, state);
    }

    public static unsafe void Marshal(Node node, GameDependencyType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(GameDependencyType), 1u);
        Marshal(node, *objT, state);
    }
}
