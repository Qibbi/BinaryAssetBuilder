using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum ShadowType
    {
        NONE,
        DECAL,
        VOLUME,
        ALPHA_DECAL,
        ADDITIVE_DECAL,
        ALPHA_DECAL_DYNAMIC,
        ADDITIVE_DECAL_DYNAMIC,
        MERGE_DECAL,
        VOLUME_OR_DECAL,
        TIBERIUM_ROOT
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ShadowInfo
    {
        public ShadowType Type;
        public AssetReference<Texture> Texture;
        public AssetReference<Texture> AdditionalTexture;
        public float SizeX;
        public float SizeY;
        public float OffsetX;
        public float OffsetY;
        public float OpacityStart;
        public Time OpacityFadeInTime;
        public float OpacityPeak;
        public Time OpacityFadeOutTime;
        public float OpacityEnd;
        public float MaxHeight;
        public float SunAngle;
        public SageBool OverrideLODVisibility;
        public SageBool UseHouseColor;
        public SageBool IsRotatingWithObject;
        public SageBool LocalPlayerOnly;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RadiusDecalTemplate
    {
        public AssetReference<Texture> Texture;
        public AssetReference<Texture> Texture2;
        public ShadowType Style;
        public Percentage OpacityMin;
        public Percentage OpacityMax;
        public float OpacityThrobTime;
        public float RotationsPerMinute;
        public float MaxRadius;
        public float MinRadius;
        public uint MaxSelectedUnits;
        public float SpiralAcceleration;
        public Color Color;
        public SageBool OnlyVisibleToOwningPlayer;
    }
}
