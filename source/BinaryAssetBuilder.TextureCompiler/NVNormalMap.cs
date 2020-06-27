using System.Runtime.InteropServices;

public enum NVNormalMapFilters
{
    Filter4x = 1040,
    Filter3x3,
    Filter5x5,
    Filter7x7,
    Filter9x9,
    FilterDuDv
}

public enum NVHeightConversionMethods
{
    AlphaChannel = 1009,
    AverageRGB,
    BiasedRGB,
    Red,
    Green,
    Blue,
    MaxRGB,
    ColorSpace,
    Normalize,
    NormalMapToHeightMap
}

public enum NVAlphaResult
{
    AlphaUnchanged = 1033,
    AlphaHeight,
    AlphaSetToZero,
    AlphaSetToOne
}

[StructLayout(LayoutKind.Sequential)]
public struct NVNormalMap
{
    public SageBool EnableNormalMapConversion;
    public int MinZ;
    public float Scale;
    public NVNormalMapFilters FilterKernel;
    public NVHeightConversionMethods HeightConversionMethod;
    public NVAlphaResult AlphaResult;
    public SageBool Wrap;
    public SageBool InvertX;
    public SageBool InvertY;
    public SageBool InvertZ;
    public SageBool AddHeightMap;
    public SageBool NormalMapSwapRGB;

    public void Initialize()
    {
        EnableNormalMapConversion = false;
        MinZ = 0;
        Scale = 1.0f;
        FilterKernel = NVNormalMapFilters.Filter3x3;
        HeightConversionMethod = NVHeightConversionMethods.AverageRGB;
        AlphaResult = NVAlphaResult.AlphaUnchanged;
        Wrap = false;
        InvertX = false;
        InvertY = false;
        InvertZ = false;
        AddHeightMap = false;
        NormalMapSwapRGB = false;
    }
}
