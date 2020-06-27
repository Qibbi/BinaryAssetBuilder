using System.Runtime.InteropServices;

public enum NVQualitySetting
{
    QualityFastest = 68,
    QualityNormal,
    QualityProduction = 71,
    QualityHighest
}

public enum NVCompressionWeighting
{
    LuminanceWeighting,
    GreyScaleWeighting,
    TangentSpaceNormalMapWeighting,
    ObjectSpaceNormalMapWeighting,
    UserDefinedWeighting
}

public enum NVRescaleTypes
{
    RescaleNone,
    RescaleNearestPower2,
    RescaleBiggestPower2,
    RescaleSmallestPower2,
    RescaleNextSmallestPower2,
    RescalePreScale,
    RescaleRelScale
}

public enum NVMipFilterTypes
{
    MipFilterPoint,
    MipFilterBox,
    MipFilterTriangle,
    MipFilterQuadratic,
    MipFilterCubic,
    MipFilterCatrom,
    MipFilterMitchell,
    MipFilterGaussian,
    MipFilterSinc,
    MipFilterBessel,
    MipFilterHanning,
    MipFilterHamming,
    MipFilterBlackman,
    MipFilterKaiser
}

public enum NVMipMapGeneration
{
    GenerateMipMaps = 30,
    UseExistingMipMaps,
    NoMipMaps,
    CompleteMipMapChain
}

public enum NVSharpenFilterTypes
{
    SharpenFilterNone,
    SharpenFilterNegative,
    SharpenFilterLighter,
    SharpenFilterDarker,
    SharpenFilterContrastMore,
    SharpenFilterContrastLess,
    SharpenFilterSmoothen,
    SharpenFilterSharpenSoft,
    SharpenFilterSharpenMedium,
    SharpenFilterSharpenStrong,
    SharpenFilterFindEdges,
    SharpenFilterContour,
    SharpenFilterEdgeDetect,
    SharpenFilterEdgeDetectSoft,
    SharpenFilterEmboss,
    SharpenFilterMeanRemoval,
    SharpenFilterUnSharp,
    SharpenFilterXSharpen,
    SharpenFilterWarpSharp,
    SharpenFilterCustom
}

public enum NVTextureTypes
{
    TextureTypeTexture2D,
    TextureTypeCubeMap,
    TextureTypeVolumeMap
}

public enum NVTextureFormats
{
    DXT1,
    DXT1a,
    DXT3,
    DXT5,
    A4R4G4B4,
    A1R5G5B5,
    A0R5G6B5,
    A8R8G8B8,
    A0R8G8B8,
    A0R5G5B5,
    P8c,
    V8U8,
    CxV8U8,
    A8,
    P4c,
    Q8W8V8U8,
    A8L8,
    R32F,
    A32B32G32R32F,
    A16B16G16R16F,
    L8,
    P8a,
    P4a,
    R16F,
    DXT5_NM,
    AXR8G8B8,
    V16U16,
    G16R16,
    G16R16F,
    K3Dc,
    L16,
    UnknownTextureFormat = -1
}

[StructLayout(LayoutKind.Sequential, Size = 1644)]
public struct NVCompressionOptions
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SCustomFilterData
    {
        public unsafe fixed float Filter[25]; // [5][5]
        public float Div;
        public float Bias;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SUnsharpData
    {
        public float Radius32F;
        public float Amount32F;
        public float Threshold32F;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SXSharpData
    {
        public float Strength32F;
        public float Threshold32F;
    }

    public const int MAX_MIP_MAPS = 17;

    public NVQualitySetting Quality;
    public float RmsErrorSearchThreshold;
    public NVCompressionWeighting WeightType;
    public unsafe fixed float Weight[3];
    public NVNormalMap NormalMap;
    public SageBool NormalizeTexels;
    public NVRescaleTypes RescaleImageType;
    public NVMipFilterTypes RescaleImageFilter;
    public float ScaleX;
    public float ScaleY;
    public SageBool Clamp;
    public float ClampX;
    public float ClampY;
    public SageBool ClampScale;
    public float ClampScaleX;
    public float ClampScaleY;
    public NVMipMapGeneration MipMapGeneration;
    public int NumMipMapsToWrite;
    public NVMipFilterTypes MipFilterType;
    public SageBool BinaryAlpha;
    public float AlphaThreshold32F;
    public SageBool AlphaBorder;
    public SageBool AlphaBorderLeft;
    public SageBool AlphaBorderRight;
    public SageBool AlphaBorderTop;
    public SageBool AlphaBorderBottom;
    public SageBool Border;
    public FPPixel BorderColor32F;
    public SageBool FadeColor;
    public SageBool FadeAlpha;
    public FPPixel FadeToColor32F;
    public int FadeToDelay;
    public float FadeAmount32F;
    public SageBool UserSpecifiedFadingAmounts;
    public unsafe fixed float UserFadingAmounts[MAX_MIP_MAPS];
    public SCustomFilterData CustomFilterData;
    public SUnsharpData UnsharpData;
    public SXSharpData XSharpData;
    public unsafe fixed int SharpeningPassesPerMipLevel[MAX_MIP_MAPS];
    public NVSharpenFilterTypes SharpenFilterType;
    public SageBool ErrorDiffusion;
    public int ErrorDiffusionWidth;
    public SageBool EnableFilterGamma;
    public float FilterGamma;
    public float FilterBlur;
    public SageBool OverrideFilterWidth;
    public float FilterWidth;
    public NVTextureTypes TextureType;
    public NVTextureFormats TextureFormat;
    public uint PaletteSize;
    public unsafe fixed uint ColorPalette[256]; // RGBA_t
    public SageBool AutoGeneratePalette;
    public FPPixel OutputScale;
    public FPPixel OutputBias;
    public FPPixel InputScale;
    public FPPixel InputBias;
    public SageBool ConvertToGreyScale;
    public FPPixel GreyScaleWeight;
    public FPPixel Brightness;
    public FPPixel Contrast;
    public SageBool OutputWrap;
    public SageBool CalcLuminance;
    public SageBool SwapRB;
    public SageBool SwapRG;
    public SageBool ForceDXT1FourColors;
    public SageBool RGBE;
    public SageBool CreateOnePalette;
    public SageBool DitherColor;
    public SageBool DitherMip0;
    public SageBool PreModulateColorWithAlpha;
    public SageBool AlphaFilterModulate;
    public unsafe void* UserData;

    public void Initialize()
    {
        NormalMap.Initialize();
        SetDefaultOptions();
    }

    public unsafe void SetDefaultOptions()
    {
        Quality = NVQualitySetting.QualityProduction;
        RmsErrorSearchThreshold = 400.0f;
        RescaleImageType = NVRescaleTypes.RescaleNone;
        RescaleImageFilter = NVMipFilterTypes.MipFilterCubic;
        ScaleX = 1.0f;
        ScaleY = 1.0f;
        Clamp = false;
        ClampX = 4096.0f;
        ClampY = 4096.0f;
        ClampScale = false;
        ClampScaleX = 4096.0f;
        ClampScaleY = 4096.0f;
        MipMapGeneration = NVMipMapGeneration.GenerateMipMaps;
        NumMipMapsToWrite = 0;
        MipFilterType = NVMipFilterTypes.MipFilterTriangle;
        BinaryAlpha = false;
        RGBE = false;
        AlphaBorder = false;
        AlphaBorderLeft = false;
        AlphaBorderRight = false;
        AlphaBorderTop = false;
        AlphaBorderBottom = false;
        Border = false;
        BorderColor32F.R = 0.0f;
        BorderColor32F.G = 0.0f;
        BorderColor32F.B = 0.0f;
        BorderColor32F.A = 0.0f;
        FadeColor = false;
        FadeAlpha = false;
        FadeToColor32F.R = 0.0f;
        FadeToColor32F.G = 0.0f;
        FadeToColor32F.B = 0.0f;
        FadeToColor32F.A = 0.0f;
        FadeToDelay = 0;
        FadeAmount32F = 0.15f;
        AlphaThreshold32F = 0.5f;
        DitherColor = false;
        DitherMip0 = false;
        ForceDXT1FourColors = false;
        SharpenFilterType = NVSharpenFilterTypes.SharpenFilterNone;
        ErrorDiffusion = false;
        ErrorDiffusionWidth = 1;
        WeightType = NVCompressionWeighting.LuminanceWeighting;
        NormalizeTexels = false;
        Weight[0] = 0.3086f;
        Weight[1] = 0.6094f;
        Weight[2] = 0.0820f;
        EnableFilterGamma = false;
        FilterGamma = 2.2f;
        FilterBlur = 1.0f;
        FilterWidth = 10.0f;
        OverrideFilterWidth = false;
        TextureType = NVTextureTypes.TextureTypeTexture2D;
        TextureFormat = NVTextureFormats.DXT1;
        SwapRG = false;
        SwapRB = false;
        UserData = null;
        float[] defaultFilter = new[]
        {
            0.0f, 0.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 0.0f, -2.0f, 0.0f, 0.0f,
            0.0f, -2.0f, 11.0f, -2.0f, 0.0f,
            0.0f, 0.0f, -2.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 0.0f, 0.0f
        };
        for (int idx = 0; idx < 25; ++idx)
        {
            CustomFilterData.Filter[idx] = defaultFilter[idx];
        }
        CustomFilterData.Div = 3.0f;
        CustomFilterData.Bias = 0.0f;
        UnsharpData.Radius32F = 5.0f;
        UnsharpData.Amount32F = 0.5f;
        UnsharpData.Threshold32F = 0.0f;
        XSharpData.Strength32F = 1.0f;
        XSharpData.Threshold32F = 1.0f;
        SharpeningPassesPerMipLevel[0] = 0;
        for (int idx = 1; idx < MAX_MIP_MAPS; ++idx)
        {
            SharpeningPassesPerMipLevel[idx] = 1;
        }
        AlphaFilterModulate = false;
        PreModulateColorWithAlpha = false;
        UserSpecifiedFadingAmounts = false;
        for (int idx = 0; idx < 256; ++idx)
        {
            ColorPalette[idx] = 0u;
        }
        PaletteSize = 0;
        AutoGeneratePalette = false;
        OutputScale.R = 1.0f;
        OutputScale.G = 1.0f;
        OutputScale.B = 1.0f;
        OutputScale.A = 1.0f;
        OutputBias.R = 0.0f;
        OutputBias.G = 0.0f;
        OutputBias.B = 0.0f;
        OutputBias.A = 0.0f;
        InputScale.R = 1.0f;
        InputScale.G = 1.0f;
        InputScale.B = 1.0f;
        InputScale.A = 1.0f;
        InputBias.R = 0.0f;
        InputBias.G = 0.0f;
        InputBias.B = 0.0f;
        InputBias.A = 0.0f;
        ConvertToGreyScale = false;
        GreyScaleWeight.R = 0.3086f;
        GreyScaleWeight.G = 0.6094f;
        GreyScaleWeight.B = 0.0820f;
        GreyScaleWeight.A = 0.0f;
        Brightness.R = 0.0f;
        Brightness.G = 0.0f;
        Brightness.B = 0.0f;
        Brightness.A = 0.0f;
        Contrast.R = 1.0f;
        Contrast.G = 1.0f;
        Contrast.B = 1.0f;
        Contrast.A = 1.0f;
        CalcLuminance = false;
        OutputWrap = false;
        CreateOnePalette = false;
    }
}
