using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BodyModuleData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x6F0F9F52u:
                MarshalPolymorphicType<HighlanderBodyModuleData, BodyModuleData>(node, objT, state);
                break;
            case 0x72256CF3u:
                MarshalPolymorphicType<RespawnBodyModuleData, BodyModuleData>(node, objT, state);
                break;
            case 0x9B1506DEu:
                MarshalPolymorphicType<DelayedDeathBodyModuleData, BodyModuleData>(node, objT, state);
                break;
            case 0x88E94F7Au:
                MarshalPolymorphicType<ImmortalBodyModuleData, BodyModuleData>(node, objT, state);
                break;
            case 0xD3565857u:
                MarshalPolymorphicType<ShieldBodyModuleData, BodyModuleData>(node, objT, state);
                break;
            case 0x5A0E3D9Bu:
                MarshalPolymorphicType<ActiveBodyModuleData, BodyModuleData>(node, objT, state);
                break;
            default:
                break;
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Body module {0:X08} is not implemented.", typeId);
        }
    }
}
