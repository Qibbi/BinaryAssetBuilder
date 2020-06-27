using System;
using System.Runtime.InteropServices;

namespace Native.Direct3D9
{
    [Flags]
    public enum Caps
    {
        None,
        Overlay = 0x00800,
        ReadScanline = 0x20000
    }

    [Flags]
    public enum Caps2
    {
        None,
        FullSceenGamma = 0x00020000,
        CanCalibrateGamma = 0x00100000,
        CanManageResource = 0x10000000,
        DynamicTextures = 0x20000000,
        CanAutoGenerateMipMap = 0x40000000,
        CanShareResource = unchecked((int)0x80000000)
    }

    [Flags]
    public enum Caps3
    {
        None,
        AlphaFullScreenFlipOrDiscard = 0x0020,
        LinearToSrgbPresentation = 0x0080,
        CopyToVideoMemory = 0x0100,
        CopyToSystemMemory = 0x0200,
        DXVAHd = 0x0400
    }

    [Flags]
    public enum CursorCaps
    {
        Color = 1,
        LowResolution
    }

    [Flags]
    public enum DeviceCaps
    {
        ExecuteSystemMemory = 0x00000010,
        ExecuteVideoMemory = 0x00000020,
        TLVertexSystemMemory = 0x00000040,
        TLVertexVideoMemory = 0x00000080,
        TextureSystemMemory = 0x00000100,
        TextureVideoMemory = 0x00000200,
        DrawPrimTLVertex = 0x00000400,
        CanRenderAfterFlip = 0x00000800,
        TextureNonLocalVideoMemory = 0x00001000,
        DrawPrimitives2 = 0x00002000,
        SeparateTextureMemory = 0x00004000,
        DrawPrimitives2Extended = 0x00008000,
        HWTransformAndLight = 0x00010000,
        CanBlitSysToNonLocal = 0x00020000,
        HWRasterization = 0x00080000,
        PureDevice = 0x00100000,
        QuinticRTPatches = 0x00200000,
        RTPatches = 0x00400000,
        RTPatchHandleZero = 0x00800000,
        NPatches = 0x01000000
    }

    [Flags]
    public enum DeviceCaps2
    {
        StreamOffset = 0x0001,
        DMapPatch = 0x0002,
        AdaptiveTessRTPatch = 0x0004,
        AdaptiveTessNPatch = 0x0008,
        CanStretchRectFromTextures = 0x0010,
        PresampledMapNPatch = 0x0020,
        VertexElementCanShareStreamOffset = 0x0040
    }

    [Flags]
    public enum PrimitiveMiscCaps
    {
        MaskZ = 0x00000002,
        CullNone = 0x00000010,
        CullCW = 0x00000020,
        CullCCW = 0x00000040,
        ColorWriteEnable = 0x00000080,
        ClipPlanesScaledPoints = 0x00000100,
        ClipTLVertices = 0x00000200,
        TssArgTemp = 0x00000400,
        BlendOperation = 0x00000800,
        NullReference = 0x00001000,
        IndependentWriteMasks = 0x00004000,
        PerStageConstant = 0x00008000,
        FogAndSpecularAlpha = 0x00010000,
        SeparateAlphaBlend = 0x00020000,
        MrtIndependentBitDepths = 0x00040000,
        MrtPostPixelShaderBlending = 0x00080000,
        FogVertexClamped = 0x00100000,
        PostBlendSrgbConvert = 0x00200000
    }

    [Flags]
    public enum RasterCaps
    {
        Dither = 0x00000001,
        DepthTest = 0x00000010,
        FogVertex = 0x00000080,
        FogTable = 0x00000100,
        MipMapLodBias = 0x00002000,
        ZBufferLessHsr = 0x00008000,
        FogRange = 0x00010000,
        Anisotropy = 0x00020000,
        WBuffer = 0x00040000,
        WFog = 0x00100000,
        ZFog = 0x00200000,
        ColorPerspective = 0x00400000,
        ScissorTest = 0x01000000,
        SlopeScaleDepthBias = 0x02000000,
        DepthBias = 0x04000000,
        MultisampleToggle = 0x08000000
    }

    [Flags]
    public enum CompareCaps
    {
        Never = 0x0001,
        Less = 0x0002,
        Equal = 0x0004,
        LessEqual = 0x0008,
        Greater = 0x0010,
        NotEqual = 0x0020,
        GreaterEqual = 0x0040,
        Always = 0x0080
    }

    [Flags]
    public enum BlendCaps
    {
        Zero = 0x0001,
        One = 0x0002,
        SourceColor = 0x0004,
        InverseSourceColor = 0x0008,
        SourceAlpha = 0x0010,
        InverseSourceAlpha = 0x0020,
        DestinationAlpha = 0x0040,
        InverseDestinationAlpha = 0x0080,
        DestinationColor = 0x0100,
        InverseDestinationColor = 0x0200,
        SourceAlphaSaturated = 0x0400,
        BothSrcAlpha = 0x0800,
        BothInverseSrcAlpha = 0x1000,
        BlendFactor = 0x2000,
        SourceColor2 = 0x4000,
        InverseSourceColor2 = 0x8000
    }

    [Flags]
    public enum ShadeCaps
    {
        ColorGouraudRgb = 0x00000008,
        SpecularGouraudRgb = 0x00000200,
        AlphaGouraudBlend = 0x00004000,
        FogGouraud = 0x00080000
    }

    [Flags]
    public enum TextureCaps
    {
        Perspective = 0x00000001,
        Pow2 = 0x00000002,
        Alpha = 0x00000004,
        SquareOnly = 0x00000020,
        TextureRepeatNotScaledBySize = 0x00000040,
        AlphaPalette = 0x00000080,
        NonPow2Conditional = 0x00000100,
        Projected = 0x00000400,
        CubeMap = 0x00000800,
        VolumeMap = 0x00002000,
        MipMap = 0x00004000,
        MipVolumeMap = 0x00008000,
        MipCubeMap = 0x00010000,
        CubeMapPow2 = 0x00020000,
        VolumeMapPow2 = 0x00040000,
        NoProjectedBumpEnvironment = 0x00200000
    }

    [Flags]
    public enum FilterCaps
    {
        MinPoint = 0x00000100,
        MinLinear = 0x00000200,
        MinAnisotropic = 0x00000400,
        MinPyramidalQuad = 0x00000800,
        MinGaussianQuad = 0x00001000,
        MipPoint = 0x00010000,
        MipLinear = 0x00020000,
        ConvolutionMono = 0x00040000,
        MagPoint = 0x01000000,
        MagLinear = 0x02000000,
        MagAnisotropic = 0x04000000,
        MagPyramidalQuad = 0x08000000,
        MagGaussianQuad = 0x10000000
    }

    [Flags]
    public enum TextureAddressCaps
    {
        Wrap = 0x0001,
        Mirror = 0x0002,
        Clamp = 0x0004,
        Border = 0x0008,
        IndependentUV = 0x0010,
        MirrorOnce = 0x0020
    }

    [Flags]
    public enum LineCaps
    {
        Texture = 0x0001,
        DepthTest = 0x0002,
        Blend = 0x0004,
        AlphaCompare = 0x0008,
        Fog = 0x0010,
        Antialias = 0x0020
    }

    [Flags]
    public enum StencilCaps
    {
        Keep = 0x0001,
        Zero = 0x0002,
        Replace = 0x0004,
        IncrementClamp = 0x0008,
        DecrementClamp = 0x0010,
        Invert = 0x0020,
        Increment = 0x0040,
        Decrement = 0x0080,
        TwoSided = 0x0100
    }

    [Flags]
    public enum VertexFormatCaps
    {
        TextureCoordCountMask = 0x0000FFFF,
        DoNotStripElements = 0x00080000,
        PointSize = 0x00100000
    }

    [Flags]
    public enum TextureOperationCaps
    {
        Disable = 0x00000001,
        SelectArg1 = 0x00000002,
        SelectArg2 = 0x00000004,
        Modulate = 0x00000008,
        Modulate2X = 0x00000010,
        Modulate4X = 0x00000020,
        Add = 0x00000040,
        AddSigned = 0x00000080,
        AddSigned2X = 0x00000100,
        Subtract = 0x00000200,
        AddSmooth = 0x00000400,
        BlendDiffuseAlpha = 0x00000800,
        BlendTextureAlpha = 0x00001000,
        BlendFactorAlpha = 0x00002000,
        BlendTextureAlphaPM = 0x00004000,
        BlendCurrentAlpha = 0x00008000,
        Premodulate = 0x00010000,
        ModulateAlphaAddColor = 0x00020000,
        ModulateColorAddAlpha = 0x00040000,
        ModulateInvAlphaAddColor = 0x00080000,
        ModulateInvColorAddAlpha = 0x00100000,
        BumpEnvironmentMap = 0x00200000,
        BumpEnvironmentMapLuminance = 0x00400000,
        DotProduct3 = 0x00800000,
        MultiplyAdd = 0x01000000,
        Lerp = 0x02000000
    }

    [Flags]
    public enum VertexProcessingCaps
    {
        TextureGen = 0x0001,
        MaterialSource7 = 0x0002,
        DirectionalLights = 0x0008,
        PositionalLights = 0x0010,
        LocalViewer = 0x0020,
        Tweening = 0x0040,
        TexGenSphereMap = 0x0100,
        NoTexGenNonLocalViewer = 0x0200
    }

    [Flags]
    public enum DeclarationTypeCaps
    {
        UByte4 = 0x0001,
        UByte4N = 0x0002,
        Short2N = 0x0004,
        Short4N = 0x0008,
        UShort2N = 0x0010,
        UShort4N = 0x0020,
        UDec3 = 0x0040,
        Dec3N = 0x0080,
        HalfTwo = 0x0100,
        HalfFour = 0x0200
    }

    [Flags]
    public enum VertexShaderCaps
    {
        None,
        Predication = 0x0001
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VertexShader20Caps
    {
        public VertexShaderCaps Caps;
        public int DynamicFlowControlDepth;
        public int TempCount;
        public int StaticFlowControlDepth;
    }

    [Flags]
    public enum PixelShaderCaps
    {
        None,
        ArbitrarySwizzle = 0x0001,
        GradientInstructions = 0x0002,
        Predication = 0x0004,
        NoDependentReadLimit = 0x0008,
        NoTextureInstructionLimit = 0x0010
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PixelShader20Caps
    {
        public PixelShaderCaps Caps;
        public int DynamicFlowControlDepth;
        public int TempCount;
        public int StaticFlowControlDepth;
        public int InstructionSlotCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct Capabilities
    {
        public DeviceType DeviceType;
        public int AdapterOrdinal;
        public Caps Caps;
        public Caps2 Caps2;
        public Caps3 Caps3;
        public PresentInterval PresentationIntervals;
        public CursorCaps CursorCaps;
        public DeviceCaps DeviceCaps;
        public PrimitiveMiscCaps PrimitiveMiscCaps;
        public RasterCaps RasterCaps;
        public CompareCaps DepthCompareCaps;
        public BlendCaps SourceBlendCaps;
        public BlendCaps DestinationBlendCaps;
        public CompareCaps AlphaCompareCaps;
        public ShadeCaps ShadeCaps;
        public TextureCaps TextureCaps;
        public FilterCaps TextureFilterCaps;
        public FilterCaps CubeTextureFilterCaps;
        public FilterCaps VolumeTextureFilterCaps;
        public TextureAddressCaps TextureAddressCaps;
        public TextureAddressCaps VolumeTextureAddressCaps;
        public LineCaps LineCaps;
        public int MaxTextureWidth;
        public int MaxTextureHeight;
        public int MaxVolumeExtent;
        public int MaxTextureRepeat;
        public int MaxTextureAspectRatio;
        public int MaxAnisotropy;
        public float MaxVertexW;
        public float GuardBandLeft;
        public float GuardBandTop;
        public float GuardBandRight;
        public float GuardBandBottom;
        public float ExtentsAdjust;
        public StencilCaps StencilCaps;
        public VertexFormatCaps FVFCaps;
        public TextureOperationCaps TextureOperationCaps;
        public int MaxTextureBlendStages;
        public int MaxSimultaneousTextures;
        public VertexProcessingCaps VertexProcessingCaps;
        public int MaxActiveLights;
        public int MaxUserClipPlanes;
        public int MaxVertexBlendMatrices;
        public int MaxVertexBlendMatrixIndex;
        public float MaxPointSize;
        public int MaxPrimitiveCount;
        public int MaxVertexIndex;
        public int MaxStreams;
        public int MaxStreamStride;
        public int _VertexShaderVersion;
        public int MaxVertexShaderConst;
        public int _PixelShaderVersion;
        public float PixelShader1xMaxValue;
        public DeviceCaps2 DeviceCaps2;
        public float MaxNPatchTessellationLevel;
        public int Reserved5;
        public int MasterAdapterOrdinal;
        public int AdapterOrdinalInGroup;
        public int NumberOfAdaptersInGroup;
        public DeclarationTypeCaps DeclarationTypes;
        public int SimultaneousRTCount;
        public FilterCaps StretchRectFilterCaps;
        public VertexShader20Caps VS20Caps;
        public PixelShader20Caps PS20Caps;
        public FilterCaps VertexTextureFilterCaps;
        public int MaxVShaderInstructionsExecuted;
        public int MaxPShaderInstructionsExecuted;
        public int MaxVertexShader30InstructionSlots;
        public int MaxPixelShader30InstructionSlots;
    }
}
