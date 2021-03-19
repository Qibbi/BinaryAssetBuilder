using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ScriptedModelDrawTexture
    {
        public AssetReference<Texture> Texture;
        public AnsiString Object;
        public TimeOfDayType TimeOfDay;
        public int TexturePass;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Animation
    {
        public AnsiString Flags;
        public AssetReference<W3DAnimation> AnimationName;
        public AnsiString AnimationMode;
        public AnsiString AnimNickName;
        public float Distance;
        public float AnimationBlendTime;
        public float AnimationSpeedFactorMin;
        public float AnimationSpeedFactorMax;
        public WeaponSlotType WeaponTimingOrdering;
        public int WeaponTimingSlotID;
        public int AnimationPriority;
        public float FadeBeginFrame;
        public float FadeEndFrame;
        public SageBool AnimationMustCompleteBlend;
        public SageBool UseWeaponTiming;
        public SageBool FadingIn;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationState
    {
        public ParseCondStateType ParseCondStateType;
        public AnsiString AnimNickName;
        public AnsiString ConditionsYes;
        public AnsiString Name;
        public AnsiString StateName;
        public AnsiString Flags;
        public AssetReference<FXList> EnteringStateFX;
        public int FrameForPristineBonePositions;
        public List<Animation> Animation;
        public unsafe AnsiString* Script;
        public List<FXEvent> FXEvent;
        public List<LuaEvent> LuaEvent;
        public List<ParticleSysBone> ParticleSysBone;
        public SageBool ShareAnimation;
        public SageBool AllowRepeatInRandomPick;
        public SageBool SimilarRestart;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DScriptedModelDrawModuleData
    {
        public DrawModuleData Base;
        public AnsiString Name;
        public Velocity InitialRecoilSpeed;
        public float MaxRecoilDistance;
        public float RecoilDamping;
        public Velocity RecoilSettleSpeed;
        public ModelLODType MinLODRequired;
        public WeaponSlotBitFlags ProjectileBoneFeedbackEnabledSlots;
        public AssetReference<Texture> TrackMarks;
        public List<AnsiString> ExtraPublicBone;
        public AnsiString AttachToBoneInAnotherModule;
        public ModelConditionBitFlags DependencySharedModelFlags;
        public AnsiString TrackMarksLeftBone;
        public AnsiString TrackMarksRightBone;
        public AnsiString RampMesh1;
        public AnsiString RampMesh2;
        public AnsiString WallBoundsMesh;
        public AnsiString RaisedWallMesh;
        public float HighDetailLODThreshold;
        public float LowDetailLODThreshold;
        public AssetReference<FXParticleSystemTemplate> WadingParticleSys;
        public float AlphaCameraFadeOuterRadius;
        public float AlphaCameraFadeInnerRadius;
        public Percentage AlphaCameraAtInnerRadius;
        public int StaticSortLevelWhileFading;
        public int BirthFadeTime;
        public List<ModelConditionState> ModelConditionState;
        public List<AnimationState> AnimationState;
        public List<ScriptedModelDrawTexture> TimeOfDayTexture;
        public List<ScriptedModelDrawTexture> RandomTexture;
        public unsafe ScriptedModelDrawTexture* BurntTexture;
        public List<ScriptedModelDrawAttachModel> AttachModel;
        public List<ScriptedModelDrawEmbedPortal> EmbedPortal;
        public SageBool OkToChangeModelColor;
        public SageBool AnimationsRequirePower;
        public SageBool UseYAxisForTurretRotation;
        public SageBool TrackMarksOnlyWhenCorneringQuickly;
        public SageBool UseProducerTexture;
        public SageBool NoRotate;
        public SageBool UseFiringArcRotation;
        public SageBool Selectable;
        public SageBool RandomTextureFixedRandomIndex;
        public SageBool ParticlesAttachedToAnimatedBones;
        public SageBool ParticleBonesCheckDrawable;
        public SageBool ShadowForceDisable;
        public SageBool SwitchModelLODMode;
        public SageBool StaticModelLODMode;
        public SageBool ShowShadowWhileContained;
        public SageBool UseStandardModelNames;
        public SageBool UseDefaultAnimation;
        public SageBool BirthFadeAdditive;
        public SageBool ZWriteDisableOverride;
        public SageBool MultiPlayerOnly;
        public SageBool AffectedByStealth;
        public SageBool InvertStealthOpacity;
        public SageBool HighDetailOnly;
    }
}
