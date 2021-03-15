using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum ObjectFilterRule
    {
        UNPARSED,
        ALL,
        ANY,
        NONE
    }

    public enum ObjectFilterRelationship
    {
        ALLIES,
        ENEMIES,
        NEUTRAL,
        SAME_PLAYER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectFilterRelationshipBitMask
    {
        public const int Count = 4;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum ObjectFilterAlignment
    {
        NONE,
        EVIL,
        GOOD
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectFilter
    {
#pragma warning disable IDE1006 // Naming Styles
        public TypedAssetId<BaseAssetType> id; // should be TypedAssetId<ObjectFilter> but .net thinks it might be a circular reference
#pragma warning restore IDE1006 // Naming Styles
        public ObjectFilterRule Rule;
        public ObjectFilterRelationshipBitMask Relationship;
        public ObjectFilterAlignment Alignment;
        public KindOfBitFlags Include;
        public KindOfBitFlags Exclude;
        public List<TypedAssetId<BaseAssetType>> IncludeThing; // should be TypedAssetId<GameObject> but .net thinks it might be a circular reference
        public List<TypedAssetId<BaseAssetType>> ExcludeThing; // should be TypedAssetId<GameObject> but .net thinks it might be a circular reference

        public unsafe bool TestObject([In] Object* @object, [In] Player* playerOwningFilter = null)
        {
            throw new System.NotImplementedException();
        }

        public unsafe bool TestTemplate([In] ThingTemplate* objectTemplate, [In] Player* objectPlayer = null, [In] Player* playerOwningFilter = null, bool ignoreRelationships = false)
        {
            throw new System.NotImplementedException();
        }

        public unsafe bool TestKindOf([In] KindOfBitFlags* kindOfFlag)
        {
            throw new System.NotImplementedException();
        }

        public bool Any()
        {
            throw new System.NotImplementedException();
        }
    }
}
