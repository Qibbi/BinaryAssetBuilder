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
    public struct FXShaderConstant : IPolymophic
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
}
