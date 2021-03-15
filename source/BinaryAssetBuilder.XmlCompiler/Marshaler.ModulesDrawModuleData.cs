using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DrawModuleData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x6F3323A5u:
                MarshalPolymorphicType<FXParticleDrawTrail, DrawModuleData>(node, objT, state);
                break;
            default:
                break;
                // throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Draw module {0:X08} is not implemented.", typeId);
        }
    }
}
