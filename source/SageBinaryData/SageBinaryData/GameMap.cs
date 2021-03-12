using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum MapObjectFlagType
    {
        DRAWS_IN_MIRROR,
        ROAD_POINT1,
        ROAD_POINT2,
        OBSOLETE_BRIDGE_POINT1,
        OBSOLETE_BRIDGE_POINT2,
        ROAD_CORNER_TIGHT,
        ROAD_JOIN,
        DONT_RENDER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MapObjectBitFlags
    {
        public const int Count = 0x00000008;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StringPropertyPair
    {
        public AnsiString Key;
        public AnsiString Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BoolPropertyPair
    {
        public AnsiString Key;
        public SageBool Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IntPropertyPair
    {
        public AnsiString Key;
        public int Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RealPropertyPair
    {
        public AnsiString Key;
        public float Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AssetIdPropertyPair
    {
        public AnsiString Key;
        public AssetReference<BaseAssetType> Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AssetIdListPropertyPair
    {
        public AnsiString Key;
        public AnsiString Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Dictionary
    {
        public List<BoolPropertyPair> BoolProperty;
        public List<IntPropertyPair> IntProperty;
        public List<RealPropertyPair> RealProperty;
        public List<StringPropertyPair> StringProperty;
        public List<StringPropertyPair> UnicodeStringProperty;
        public List<AssetIdPropertyPair> AssetIdProperty;
        public List<AssetIdListPropertyPair> AssetIdListProperty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MapObject
    {
#pragma warning disable IDE1006 // Naming Styles
        public TypedAssetId<BaseAssetType> id; // should be TypedAssetId<MapObject> but .net thinks it might be a circular reference
#pragma warning restore IDE1006 // Naming Styles
        public AssetReference<GameObject> ThingTemplate;
        public MapObjectBitFlags Flags;
        public float Angle;
        public Coord3D Position;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MapObjectUSP
    {
        public MapObject Base;
        public AnsiString Faction;
        public AnsiString Team;
        public float Health;
        public AnsiString EventList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EnvironmentObject
    {
        public AssetReference<Texture> Cloud;
        public AssetReference<Texture> Macro;
        public AssetReference<Texture> Environment;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RoadObject
    {
#pragma warning disable IDE1006 // Naming Styles
        public AssetReference<Road> id;
#pragma warning restore IDE1006 // Naming Styles
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PostEffectObject
    {
        public AssetReference<Texture> Effect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameMap
    {
        public BaseAssetType Base;
        public List<MapObject> Waypoint;
        public List<MapObjectUSP> Structure;
        public List<MapObjectUSP> Unit;
        public List<MapObjectUSP> Prop;
        public List<MapObject> Audio;
        public List<MapObject> Unknown;
        public List<RoadObject> Road;
        public unsafe EnvironmentObject* EnvironmentData;
        public unsafe Dictionary* WorldDict;
        public List<PostEffectObject> PostEffect;
    }
}
