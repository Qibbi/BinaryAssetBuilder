using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DPropDrawModuleData
    {
        public DrawModuleData Base;
        public AssetReference<W3DMesh> Model;
        public SageBool DistanceFog;
    }
}
