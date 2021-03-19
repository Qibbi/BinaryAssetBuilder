using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OCLUpdateModuleData
    {
        public UpdateModuleData Base;
        public AssetReference<ObjectCreationList> OCL;
        public Duration MinDelay;
        public Duration MaxDelay;
        public int Amount;
        public SageBool CreateAtEdge;
    }
}
