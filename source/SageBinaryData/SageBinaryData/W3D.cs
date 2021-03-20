using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RenderAssetFactory
    {

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BaseRenderAssetType
    {
        public BaseAssetType Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        public float X;
        public float Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Quaternion
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
    }

    public enum MeshGeometryType
    {
        Normal,
        Skin,
        CameraAligned,
        CameraOriented
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BoneInfluence
    {
        public float Weight;
        public ushort Bone;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Triangle
    {
        public List<uint> V;
        public Vector3 Nrm;
        public float Dist;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BoxMinMax
    {
        public Vector3 Min;
        public Vector3 Max;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Sphere
    {
        public float Radius;
        public Vector3 Center;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FXShaderConstant : IPolymorphic
    {
        public uint TypeId;
        public AnsiString Name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FXShaderConstantTexture
    {
        public FXShaderConstant Base;
        public AssetReference<Texture> Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FXShaderConstantFloat
    {
        public FXShaderConstant Base;
        public List<float> Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FXShaderConstantInt
    {
        public FXShaderConstant Base;
        public int Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FXShaderConstantBool
    {
        public FXShaderConstant Base;
        public SageBool Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FXShaderMaterial
    {
        public AnsiString ShaderName;
        public AnsiString TechniqueName;
        public PolymorphicList<FXShaderConstant> Constants;
        public byte TechniqueIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AABTree
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TreePolyIndices
        {
            public List<uint> P;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TreeNode
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct NodeChild
            {
                public uint Front;
                public uint Back;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct NodePoly
            {
                public uint Begin;
                public uint Count;
            }

            public Vector3 Min;
            public Vector3 Max;
            public unsafe NodeChild* Children;
            public unsafe NodePoly* Polys;
        }

        public TreePolyIndices PolyIndices;
        public List<TreeNode> Node;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DMeshMarshalerHelper
    {
        public BaseRenderAssetType Base;
        public SageBool VertexData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DMeshPipelineVertexData
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Vertex
        {
            public List<Vector3> V;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Normal
        {
            public List<Vector3> N;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Tangent
        {
            public List<Vector3> T;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Binormal
        {
            public List<Vector3> B;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct VertexColor
        {
            public List<RGBAColor> C;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TexCoord
        {
            public List<Vector2> T;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DataBoneInfluence
        {
            public List<BoneInfluence> I;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ShadeIndex
        {
            public List<uint> I;
        }

        public List<Vertex> Vertices;
        public List<Normal> Normals;
        public unsafe Tangent* Tangents;
        public unsafe Binormal* Binormals;
        public unsafe VertexColor* VertexColors;
        public List<TexCoord> TexCoords;
        public List<DataBoneInfluence> BoneInfluences;
        public unsafe ShadeIndex* ShadeIndices;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DMesh
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MeshTriangles
        {
            public List<Triangle> T;
        }

        public W3DMeshMarshalerHelper Base;
        public MeshGeometryType GeometryType;
        public W3DMeshMarshalerHelper Base;
        public BoxMinMax BoundingBox;
        public Sphere BoundingSphere;
        public W3DMeshPipelineVertexData Data;
        public MeshTriangles Triangles;
        public FXShaderMaterial FXShader;
        public unsafe AABTree* AABTree;
        public SageBool Hidden;
        public SageBool CastShadow;
        public byte SortLevel;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SubObject
    {
        public uint BoneIndex;
        public AnsiString SubObjectID;
        public AssetReference<BaseAssetType> RenderObject;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DContainer
    {
        public BaseRenderAssetType Base;
        public AssetReference<W3DHierarchy> Hierarchy;
        public List<SubObject> SubObject;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DHierarchy
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct HierarchyPivot
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Matrix
            {
                public float M00;
                public float M10;
                public float M20;
                public float M30;
                public float M01;
                public float M11;
                public float M21;
                public float M31;
                public float M02;
                public float M12;
                public float M22;
                public float M32;
                public float M03;
                public float M13;
                public float M23;
                public float M33;
            }

            public AnsiString Name;
            public int Parent;
            public Vector3 Translation;
            public Quaternion Rotation;
            public Matrix FixupMatrix;
        }
        public BaseAssetType Base;
        public List<HierarchyPivot> Pivot;
    }

    public enum AnimationChannelType
    {
        XTranslation,
        YTranslation,
        ZTranslation,
        Orientation,
        Visibility
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationChannelBase : IPolymorphic
    {
        public uint TypeId;
        public AnimationChannelType Type;
        public uint FirstFrame;
        public ushort Pivot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationChannelScalarFrame
    {
        public float Value;
        public SageBool BinaryMove;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationChannelScalar
    {
        public AnimationChannelBase Base;
        public List<AnimationChannelScalarFrame> Frame;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationChannelQuaternionFrame
    {
        public Quaternion Value;
        public SageBool BinaryMove;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationChannelQuaternion
    {
        public AnimationChannelBase Base;
        public List<AnimationChannelQuaternionFrame> Frame;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationChannelBaseRuntime : IPolymorphic
    {
        public uint TypeId;
        public AnimationChannelType Type;
        public uint NumFrames;
        public uint VectorLen;
        public ushort Pivot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationChannelTimecoded
    {
        public AnimationChannelBaseRuntime Base;
        public List<ushort> FrameAndBinaryFlag;
        public List<float> Values;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationChannelDelta
    {
        public AnimationChannelBaseRuntime Base;
        public float Scale;
        public List<float> Init;
        public uint NumBits;
        public List<byte> CompressedValues;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DAnimationRuntime
    {
        public BaseAssetType Base;
        public AssetReference<W3DHierarchy> Hierarchy;
        public uint NumFrames;
        public uint FrameRate;
        public PolymorphicList<AnimationChannelBaseRuntime> Channels;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DAnimation
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct CompressionSetting
        {
            public float MaxTranslationError;
            public float MaxRotationError;
            public float MaxVisibilityError;
            public float MaxAdaptiveDeltaError;
            public float ForceReductionRate;
            public SageBool AllowTimeCoded;
            public SageBool AllowAdaptiveDelta;
        }

        public BaseAssetType Base;
        public AssetReference<W3DHierarchy> Hierarchy;
        public uint NumFrames;
        public uint FrameRate;
        public unsafe CompressionSetting* CompressionSettings;
        public PolymorphicList<AnimationChannelBase> Channels;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DCollisionBox
    {
        public BaseRenderAssetType Base;
        public Vector3 Center;
        public Vector3 Extent;
        public SageBool JoypadPickingOnly;
    }
}
