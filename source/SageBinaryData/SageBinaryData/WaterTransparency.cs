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
        public Color StandingWaterColor;
        public Color RadarWaterColor;
        public unsafe Coord2D* ReflectionGuard;
        public SageBool AdditiveBlending;
    }
}
