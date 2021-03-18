using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TunnelContainModuleData
    {
        public HordeGarrisonContainModuleData Base;
        public TypedAssetId<GameObject> TunnelMasterObject;
        public SageBool DeleteRemoved;
    }
}
