using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ClientUpdateModuleData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x246E3C5Fu:
                MarshalPolymorphicType<SwayClientUpdateModuleData, ClientUpdateModuleData>(node, objT, state);
                break;
            case 0xAF51C3E2u:
                MarshalPolymorphicType<RadarMarkerClientUpdateModuleData, ClientUpdateModuleData>(node, objT, state);
                break;
            case 0xCA9ED83Du:
                MarshalPolymorphicType<LaserUpdateModuleData, ClientUpdateModuleData>(node, objT, state);
                break;
            case 0xA220E7D6u:
                MarshalPolymorphicType<EvaAnnounceSpecialPowerReadyClientUpdateModuleData, ClientUpdateModuleData>(node, objT, state);
                break;
            case 0xD0EEFDDDu:
                MarshalPolymorphicType<EvaAnnounceClientCreateModuleData, ClientUpdateModuleData>(node, objT, state);
                break;
            case 0xF95B7D41u:
                MarshalPolymorphicType<BeaconClientUpdateModuleData, ClientUpdateModuleData>(node, objT, state);
                break;
            case 0x8FAF1398u:
                MarshalPolymorphicType<AnimatedParticleSysBoneClientUpdateModuleData, ClientUpdateModuleData>(node, objT, state);
                break;
            default:
                break;
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Client update module {0:X08} is not implemented.", typeId);
        }
    }
}
