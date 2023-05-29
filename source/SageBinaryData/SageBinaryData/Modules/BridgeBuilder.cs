using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct BridgeBuilderModuleData
{
    public UpdateModuleData Base;
    public AssetReference<GameObject> EndCap;
    public unsafe AssetReference<GameObject>* EndCap2;
    public float EndCapLen;
    public AssetReference<GameObject> CenterPiece;
    public float CenterPieceLen;
    public unsafe AssetReference<GameObject>* CenterPieceB;
    public unsafe float* CenterPieceBLen;
    public float Width;
    public AssetReference<GameObject> GateHouse;
    public unsafe AssetReference<GameObject>* GateHouse2;
}
