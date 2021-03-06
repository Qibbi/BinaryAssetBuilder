using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum ScriptEventType
    {
        ATTACK_MOVE_ISSUED,
        WAYPOINT_MODE_ENTERED,
        CONTROL_GROUP_CLEARED
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ScriptEventTypeBitFlags
    {
        public const int Count = 3;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameScriptParameterBase : IPolymophic
    {
        public uint TypeId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameScriptParameterObjectType
    {
        public GameScriptParameterBase Base;
        public AssetReference<GameObject> Object;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameScriptParameterObjectTypeList
    {
        public GameScriptParameterBase Base;
        public List<AssetReference<GameObject>> Object;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameScriptAction
    {
        public StringHash Type;
        public PolymorphicList<GameScriptParameterBase> ParameterList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameScript
    {
#pragma warning disable IDE1006 // Naming Styles
        public TypedAssetId<BaseAssetType> id; // should be TypedAssetId<GameScript> but .net thinks it might be a circular reference
#pragma warning restore IDE1006 // Naming Styles
        public List<GameScriptAction> Action;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameScriptGroup
    {
#pragma warning disable IDE1006 // Naming Styles
        public TypedAssetId<BaseAssetType> id; // should be TypedAssetId<GameScriptGroup> but .net thinks it might be a circular reference
#pragma warning restore IDE1006 // Naming Styles
        public List<GameScript> Script;
        public List<SelfType> ScriptGroup;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameScriptList
    {
        public BaseAssetType Base;
        public unsafe GameScriptGroup* ScriptSet;
    }
}
