using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OCLUpdateModuleData
    {
        public UpdateModuleData Base;
        public AssetReference<ObjectCreationList> OCL;
        public uint MinDelay;
        public uint MaxDelay;
        public int Amount;
        public SageBool CreateAtEdge;
    }
}
