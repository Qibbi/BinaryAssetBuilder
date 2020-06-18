using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SnowType
    {
        public AssetReference<Texture> SnowTexture;
        public float SnowFrequencyScaleX;
        public float SnowFrequencyScaleY;
        public float SnowAmplitude;
        public float SnowPointSize;
        public float SnowMaxPointSize;
        public float SnowMinPointSize;
        public float SnowQuadSize;
        public float SnowBoxHeight;
        public float SnowSpacing;
        public float SnowSpeed;
        public int NumberTiles;
        public Coord2D SnowXYSpeed;
        public SageBool SnowPointSprites;
        public SageBool SnowEnabled;
        public SageBool IsSnowing;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RainType
    {
        public AssetReference<Texture> RainTexture;
        public int NumRaindropsPerBox;
        public float RainBoxWidth;
        public float RainBoxLength;
        public float RainBoxHeight;
        public float MinWidth;
        public float MaxWidth;
        public float MinHeight;
        public float MaxHeight;
        public float MinSpeed;
        public float MaxSpeed;
        public float MinAlpha;
        public float MaxAlpha;
        public float WindStrength;
        public SageBool IsRaining;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LightningType
    {
        public int LightningDuration;
        public float LightningChance;
        public unsafe ClientRandomVariable* LightningFactor;
        public SageBool LightningEnabled;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellType
    {
        public int SpellDuration;
        public SageBool SpellEnabled;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RampType
    {
        public Coord2D RampControl;
        public Coord2D RampSpacing;
        public Coord2D RampSpeed;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CloudType
    {
        public unsafe Coord2D* CloudTextureSize;
        public unsafe Coord2D* CloudOffsetPerSecond;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeatherData
    {
        public WeatherType id;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> Sound;
        public SageBool HasLightning;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Weather
    {
        public BaseInheritableAsset Base;
        public unsafe SnowType* Snow;
        public unsafe RainType* Rain;
        public unsafe LightningType* Lightning;
        public unsafe SpellType* Spell;
        public unsafe RampType* Ramp;
        public unsafe CloudType* Cloud;
        public List<WeatherData> WeatherData;
    }
}
