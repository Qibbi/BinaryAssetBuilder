using Relo;
using SageBinaryData;
using SageBinaryData.Shell;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentMovieArchive* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentMovieArchive.MissionSpec), null), &objT->MissionSpec, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}