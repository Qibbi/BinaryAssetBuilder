using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DBuffDrawModuleData
    {
        public DrawModuleData Base;
        public AssetReference<BaseRenderAssetType> Model;
        public SageBool PreDraw;
    }
}
