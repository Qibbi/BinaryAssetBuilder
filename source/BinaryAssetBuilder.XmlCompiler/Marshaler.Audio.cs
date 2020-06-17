using Relo;
using SageBinaryData;
using AnsiString = Relo.String<sbyte>;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SoundOrEvaEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SoundOrEvaEvent.Sound), null), &objT->Sound, state);
        Marshal(node.GetAttributeValue(nameof(SoundOrEvaEvent.EvaEvent), null), &objT->EvaEvent, state);
    }

    public static unsafe void Marshal(Node node, SoundOrEvaEvent** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AnsiString), 1u);
        Marshal(node, *objT, state);
    }
}