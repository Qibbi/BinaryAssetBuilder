using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WaterTransparency
    {
        public BaseAssetType Base;
        public float TransparentWaterDepth;
        public float TransparentWaterMinOpacity;
        public AssetReference<Texture> StandingWaterTexture;
        public float RiverTransparencyMultiplier;
        public unsafe Color StandingWaterColor;
        public unsafe Color RadarWaterColor;
        public unsafe Coord2D* ReflectionGuard;
        public SageBool AdditiveBlending;
    }
}
