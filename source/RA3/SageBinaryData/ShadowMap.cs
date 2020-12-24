using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ShadowMap
    {
        public BaseInheritableAsset Base;
        public int MapSize;
        public float MaxViewDistance;
        public float MinShadowedTerrainHeight;
    }
}
