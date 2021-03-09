using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum ProcessorType
    {
        UNKNOWN,
        PENTIUM_4,
        CORE_DUO,
        ATHLON,
        ATHLON_64
    }

    public enum GraphicsCardType
    {
        UNKNOWN,
        GENERIC_PIXEL_SHADER_1,
        GEFORCE_5_LOW,
        GEFORCE_3,
        RADEON_8_AND_9_LOW,
        GEFORCE_4,
        GEFORCE_5_MEDIUM,
        GEFORCE_6_LOW,
        _MINIMUM_FOR_LOW_LOD,
        GENERIC_PIXEL_SHADER_2,
        GEFORCE_5_HIGH,
        RADEON_9_MEDIUM,
        RADEON_X_LOW,
        _MINIMUM_FOR_MEDIUM_LOD,
        GEFORCE_6_MEDIUM,
        RADEON_X1_LOW,
        RADEON_9_HIGH,
        RADEON_X_MEDIUM,
        GEFORCE_7_LOW,
        RADEON_X1_MEDIUM,
        _MINIMUM_FOR_HIGH_LOD,
        RADEON_X_HIGH,
        GENERIC_PIXEL_SHADER_3,
        GEFORCE_6_HIGH,
        GEFORCE_7_MEDIUM,
        _MINIMUM_FOR_ULTRA_HIGH_LOD,
        RADEON_X1_HIGH,
        GEFORCE_7_HIGH,
        GEFORCE_8_HIGH
    }

    public enum GameLODType
    {
        UNKNOWN = -1,
        VERY_LOW,
        LOW,
        MEDIUM,
        HIGH,
        ULTRA_HIGH,
        CUSTOM
    }

    public enum ShaderLODType
    {
        LOW,
        MEDIUM,
        HIGH,
        ULTRA_HIGH
    }

    public enum AudioLODType
    {
        UNKNOWN = -1,
        LOW,
        HIGH
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessorRequirement
    {
        public ProcessorType Type;
        public int MinMHz;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameLODPreset
    {
        public BaseAssetType Base;
        public GameLODType Level;
        public int SystemMemory;
        public GraphicsCardType GraphicsCard;
        public int Xres;
        public int Yres;
        public List<ProcessorRequirement> Processor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StaticGameLOD
    {
        public BaseAssetType Base;
        public GameLODType Level;
        public ModelLODType ModelLOD;
        public EffectsLODType EffectsLOD;
        public int MaxParticleCount;
        public ShadowLODType ShadowLOD;
        public TerrainLODType TerrainLOD;
        public WaterLODType WaterLOD;
        public int MaxTankTrackEdges;
        public int MaxTankTrackOpaqueEdges;
        public int MaxTankTrackFadeDelay;
        public int TextureReductionFactor;
        public AnimationLODType AnimationLOD;
        public ShaderLODType ShaderLOD;
        public DecalLODType DecalLOD;
        public FXParticleSystem_Priority MinParticlePriority;
        public FXParticleSystem_Priority MinParticleSkipPriority;
        public int AntiAliasingQuality;
        public SageBool UseShadowDecals;
        public SageBool UseShadowMapping;
        public SageBool UseTerrainNormalMap;
        public SageBool UseDistanceDependantTerrainTextures;
        public SageBool ShowProps;
        public SageBool UseHeatEffects;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DynamicGameLOD
    {
        public BaseAssetType Base;
        public GameLODType Level;
        public int MinimumFPS;
        public int ParticleSkipMask;
        public int DebrisSkipMask;
        public float SlowDeathScale;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioLOD
    {
        public BaseAssetType Base;
        public AudioLODType Level;
        public int MaximumAmbientStreams;
        public Percentage CPULimiterLevel;
        public Percentage CPULimiterLevelDebug;
        public int MaxVoices;
        public int OutputBitRate;
        public uint MinimumLogicalProcessors;
        public List<ProcessorRequirement> Processor;
        public SageBool AllowReverb;
        public SageBool AllowCPULimiter;
        public SageBool AllowVolumeCompressor;
    }
}
