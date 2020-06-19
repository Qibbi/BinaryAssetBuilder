using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, Quaternion* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Quaternion.X), null), &objT->X, state);
        Marshal(node.GetAttributeValue(nameof(Quaternion.Y), null), &objT->Y, state);
        Marshal(node.GetAttributeValue(nameof(Quaternion.Z), null), &objT->Z, state);
        Marshal(node.GetAttributeValue(nameof(Quaternion.W), null), &objT->W, state);
    }

    public static unsafe void Marshal(Node node, W3DAnimation.CompressionSetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.CompressionSetting.AllowTimeCoded), "true"), &objT->AllowTimeCoded, state);
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.CompressionSetting.AllowAdaptiveDelta), "true"), &objT->AllowAdaptiveDelta, state);
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.CompressionSetting.MaxTranslationError), "0.001"), &objT->MaxTranslationError, state);
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.CompressionSetting.MaxRotationError), "0.01"), &objT->MaxRotationError, state);
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.CompressionSetting.MaxVisibilityError), "0.01"), &objT->MaxVisibilityError, state);
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.CompressionSetting.MaxAdaptiveDeltaError), "0.03"), &objT->MaxAdaptiveDeltaError, state);
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.CompressionSetting.ForceReductionRate), "1.0"), &objT->ForceReductionRate, state);
    }

    public static unsafe void Marshal(Node node, W3DAnimation.CompressionSetting** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(W3DAnimation.CompressionSetting), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, AnimationChannelBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AnimationChannelBase.Pivot), null), &objT->Pivot, state);
        Marshal(node.GetAttributeValue(nameof(AnimationChannelBase.Type), null), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(AnimationChannelBase.FirstFrame), null), &objT->FirstFrame, state);
    }

    public static unsafe void Marshal(Node node, AnimationChannelScalarFrame* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), &objT->Value, state);
        Marshal(node.GetAttributeValue(nameof(AnimationChannelScalarFrame.BinaryMove), "false"), &objT->BinaryMove, state);
    }

    public static unsafe void Marshal(Node node, AnimationChannelScalar* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AnimationChannelScalar.Frame), null), &objT->Frame, state);
        Marshal(node, (AnimationChannelBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, AnimationChannelQuaternionFrame* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, &objT->Value, state);
        Marshal(node.GetAttributeValue(nameof(AnimationChannelQuaternionFrame.BinaryMove), "false"), &objT->BinaryMove, state);
    }

    public static unsafe void Marshal(Node node, AnimationChannelQuaternion* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AnimationChannelQuaternion.Frame), null), &objT->Frame, state);
        Marshal(node, (AnimationChannelBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, AnimationChannelBase** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0u;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x50D28EF5u:
                MarshalPolymorphicType<AnimationChannelScalar, AnimationChannelBase>(node, objT, state);
                break;
            case 0xF642DD20u:
                MarshalPolymorphicType<AnimationChannelQuaternion, AnimationChannelBase>(node, objT, state);
                break;
            default:
                MarshalUnknownPolymorphicType(node, objT, state);
                break;
        }
    }

    public static unsafe void Marshal(Node node, W3DAnimation* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.Hierarchy), null), &objT->Hierarchy, state);
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.NumFrames), null), &objT->NumFrames, state);
        Marshal(node.GetAttributeValue(nameof(W3DAnimation.FrameRate), null), &objT->FrameRate, state);
        Marshal(node.GetChildNode(nameof(W3DAnimation.CompressionSettings), null), &objT->CompressionSettings, state);
        Marshal(node.GetChildNode(nameof(W3DAnimation.Channels), null), &objT->Channels, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}