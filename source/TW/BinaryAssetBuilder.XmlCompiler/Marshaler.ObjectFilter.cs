using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ObjectFilter* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ObjectFilter.id), null), &objT->id, state);
        Marshal(node.GetAttributeValue(nameof(ObjectFilter.Rule), "NONE"), &objT->Rule, state);
        Marshal(node.GetAttributeValue(nameof(ObjectFilter.Relationship), ""), &objT->Relationship, state);
        Marshal(node.GetAttributeValue(nameof(ObjectFilter.Alignment), "NONE"), &objT->Alignment, state);
        Marshal(node.GetAttributeValue(nameof(ObjectFilter.Include), null), &objT->Include, state);
        Marshal(node.GetAttributeValue(nameof(ObjectFilter.Exclude), null), &objT->Exclude, state);
        Marshal(node.GetChildNodes(nameof(ObjectFilter.IncludeThing)), &objT->IncludeThing, state);
        Marshal(node.GetChildNodes(nameof(ObjectFilter.ExcludeThing)), &objT->ExcludeThing, state);
    }

    public static unsafe void Marshal(Node node, ObjectFilter** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ObjectFilter), 1u);
        Marshal(node, *objT, state);
    }
}
