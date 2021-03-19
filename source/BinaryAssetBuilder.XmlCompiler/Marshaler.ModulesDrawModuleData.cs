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
            case 0x42D7103Du:
                MarshalPolymorphicType<W3DSpotlightDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0x54018E60u:
                MarshalPolymorphicType<W3DTracerDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0xEC238C51u:
                MarshalPolymorphicType<W3DHordeModelDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0xAC9BEE91u:
                MarshalPolymorphicType<W3DStreakDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0xFD9C638Eu:
                MarshalPolymorphicType<W3DQuadrupedDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0x60020441u:
                MarshalPolymorphicType<W3DStreamDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0x2FDDEC4Du:
                MarshalPolymorphicType<W3DLaserDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0xC579B39Bu:
                MarshalPolymorphicType<W3DBuffDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0xE42ABE5Cu:
                MarshalPolymorphicType<W3DTreeDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0x1BA02D89u:
                MarshalPolymorphicType<W3DDebrisDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0x148AA464u:
                MarshalPolymorphicType<W3DPropDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0xA44C2999u:
                MarshalPolymorphicType<W3DTruckDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0x8A811D3Eu:
                MarshalPolymorphicType<W3DTankDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0x4ECF2A4Bu:
                MarshalPolymorphicType<W3DScriptedModelDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            case 0x35205BCBu:
                MarshalPolymorphicType<W3DFloorDrawModuleData, DrawModuleData>(node, objT, state);
                break;
            default:
                break;
                // throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Draw module {0:X08} is not implemented.", typeId);
        }
    }
}
