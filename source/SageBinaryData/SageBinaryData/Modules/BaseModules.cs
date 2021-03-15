using System.Runtime.InteropServices;

namespace SageBinaryData
{

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
}
