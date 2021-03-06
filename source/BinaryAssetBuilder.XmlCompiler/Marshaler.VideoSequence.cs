using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FadeData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FadeData.FrameCount), null), &objT->FrameCount, state);
        Marshal(node.GetChildNode(nameof(FadeData.StartColor), null), &objT->StartColor, state);
        Marshal(node.GetChildNode(nameof(FadeData.EndColor), null), &objT->EndColor, state);
    }

    public static unsafe void Marshal(Node node, FadeData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(FadeData), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, VideoEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(VideoEvent.FadeIn), null), &objT->FadeIn, state);
        Marshal(node.GetChildNode(nameof(VideoEvent.FadeOut), null), &objT->FadeOut, state);
    }

    public static unsafe void Marshal(Node node, MovieEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MovieEvent.MovieName), null), &objT->MovieName, state);
        Marshal(node, (VideoEvent*)objT, state);
    }

    public static unsafe void Marshal(Node node, TextInstance* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TextInstance.TextId), null), &objT->TextId, state);
        Marshal(node.GetAttributeValue(nameof(TextInstance.Justification), "LEFT"), &objT->Justification, state);
        Marshal(node.GetAttributeValue(nameof(TextInstance.XOffset), "0.0"), &objT->XOffset, state);
        Marshal(node.GetAttributeValue(nameof(TextInstance.YOffset), "0.0"), &objT->YOffset, state);
        Marshal(node.GetAttributeValue(nameof(TextInstance.Font), null), &objT->Font, state);
        Marshal(node.GetAttributeValue(nameof(TextInstance.PointSize), null), &objT->PointSize, state);
        Marshal(node.GetChildNode(nameof(TextInstance.TextColor), null), &objT->TextColor, state);
    }

    public static unsafe void Marshal(Node node, TitleCardEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TitleCardEvent.DisplayTime), null), &objT->DisplayTime, state);
        Marshal(node.GetChildNodes(nameof(TitleCardEvent.TextInstance)), &objT->TextInstance, state);
        Marshal(node, (VideoEvent*)objT, state);
    }

    public static unsafe void Marshal(Node node, VideoEvent** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0xB74490CAu:
                MarshalPolymorphicType<MovieEvent, VideoEvent>(node, objT, state);
                break;
            case 0x33A73683u:
                MarshalPolymorphicType<TitleCardEvent, VideoEvent>(node, objT, state);
                break;
            default:
                MarshalUnknownPolymorphicType(node, objT, state);
                break;
        }
    }

    public static unsafe void Marshal(Node node, VideoEventList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(VideoEventList.EventList), null), &objT->EventList, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
