using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CloudEffectType
    {
        public AssetReference<Texture> CloudTexture;
        public AssetReference<Texture> DarkCloudTexture;
        public AssetReference<Texture> AlphaTexture;
        public float PropagateSpeed;
        public int Angle;
        public int DarkeningRate;
        public int LighteningRate;
        public float CloudScrollSpeed;
        public AssetReference<Texture> DissipateTexture;
        public float DissipateStartLevel;
        public float DissipateSpeed;
        public float DissipateRateScale;
        public float LightningChance;
        public float LightningFrequency;
        public float LightningShadowIntensity;
        public TypedAssetId<FXList> LightningFX;
        public RGBColor DarkeningFactor;
        public RGBColor DarkeningFactorRain;
        public RGBColor LightningShadowColor;
        public Coord2D LightningLightPosition1;
        public Coord2D LightningLightPosition2;
        public Coord2D LightningLightPosition3;
        public ClientRandomVariable LightningIntensity;
        public ClientRandomVariable LightningDuration;
        public SageBool LightningShadows;
        public SageBool JitterLightningLightIntensity;
        public SageBool JitterLightningLightPosition;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Environment
    {
        public BaseAssetType Base;
        public CloudEffectType CloudEffect;
    }
}
