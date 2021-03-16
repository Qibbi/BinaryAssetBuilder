using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimAndDuration
    {
        public ModelConditionFlagType AnimState;
        public uint Frames;
        public uint Trigger;
    }

    public enum ParseCondStateType
    {
        PARSE_NORMAL,
        PARSE_DEFAULT,
        PARSE_TRANSITION
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ModuleData : IPolymorphic
    {
        public uint TypeId;
#pragma warning disable IDE1006 // Naming Styles
        public TypedAssetId<BaseAssetType> id; // should be TypedAssetId<ModuleData> but .net thinks it might be a circular reference
#pragma warning restore IDE1006 // Naming Styles
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ClientBehaviorModuleData : IPolymorphic
    {
        public ModuleData Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DrawModuleData : IPolymorphic
    {
        public ModuleData Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BehaviorModuleData : IPolymorphic
    {
        public ModuleData Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ContainModuleData : IPolymorphic
    {
        public BehaviorModuleData Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ClientUpdateModuleData : IPolymorphic
    {
        public BehaviorModuleData Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UpdateModuleData : IPolymorphic
    {
        public ContainModuleData Base;
    }

    public enum FXActionType
    {
        NONE,
        HOLD,
        KILL,
        SPAWN
    }

    public enum FXTriggerType
    {
        NONE,
        CATAPULT_ROCK,
        TREBUCHET_ROCK
    }

    public enum BodyDamageType
    {
        PRISTINE,
        DAMAGED,
        REALLY_DAMAGED,
        RUBBLE
    }

    public enum MaxHealthChangeType
    {
        SAME_CURRENTHEALTH,
        PRESERVE_RATIO,
        ADD_CURRENT_HEALTH_TOO
    }

    public enum BodySideDestroyedType
    {
        NONE,
        FRONT_DESTROYED,
        RIGHT_DESTROYED,
        BACK_DESTROYED,
        LEFT_DESTROYED
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DieMuxDataType
    {
        public List<AnsiString> VeterancyLevels;
        public ObjectStatusBitFlags ExemptStatus;
        public ObjectStatusBitFlags RequiredStatus;
        public float DamageAmountRequired;
        public Angle MinKillerAngle;
        public Angle MaxKillerAngle;
        public DeathBitFlags DeathTypes;
        public DeathBitFlags DeathTypesForbidden;
    }
}
