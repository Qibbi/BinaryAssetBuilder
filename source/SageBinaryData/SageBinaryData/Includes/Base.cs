using Relo;
using System;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RGBColor
{
    public float R;
    public float G;
    public float B;
}

[StructLayout(LayoutKind.Sequential)]
public struct RGBAColor
{
    public RGBColor Base;
    public float A;
}

[StructLayout(LayoutKind.Sequential)]
public struct Color3f
{
#pragma warning disable IDE1006 // Naming Styles
    public float r;
    public float g;
    public float b;
#pragma warning restore IDE1006 // Naming Styles;
}

[StructLayout(LayoutKind.Sequential)]
public struct Color4f
{
#pragma warning disable IDE1006 // Naming Styles
    public float r;
    public float g;
    public float b;
    public float a;
#pragma warning restore IDE1006 // Naming Styles;
}

[StructLayout(LayoutKind.Sequential)]
public struct RealRange
{
    public float Low;
    public float High;
}

[StructLayout(LayoutKind.Sequential)]
public struct IntRange
{
    public int Low;
    public int High;
}

[StructLayout(LayoutKind.Sequential)]
public struct Coord2D
{
#pragma warning disable IDE1006 // Naming Styles
    public float x;
    public float y;
#pragma warning restore IDE1006 // Naming Styles
}

[StructLayout(LayoutKind.Sequential)]
public struct ICoord2D
{
#pragma warning disable IDE1006 // Naming Styles
    public int x;
    public int y;
#pragma warning restore IDE1006 // Naming Styles
}

[StructLayout(LayoutKind.Sequential)]
public struct Coord3D
{
#pragma warning disable IDE1006 // Naming Styles
    public float x;
    public float y;
    public float z;
#pragma warning restore IDE1006 // Naming Styles
}

// Both Color3 and Color4 map to this
[StructLayout(LayoutKind.Sequential)]
public struct Color
{
    public byte B;
    public byte G;
    public byte R;
    public byte A;
}

public enum DistributionType
{
    CONSTANT,
    UNIFORM,
    GAUSSIAN,
    TRIANGULAR,
    LOW_BIAS,
    HIGH_BIAS
}

[StructLayout(LayoutKind.Sequential)]
public struct RandomVariable
{
    public DistributionType Type;
    public float Low;
    public float High;
}

[StructLayout(LayoutKind.Sequential)]
public struct LogicRandomVariable
{
    public RandomVariable Base;

    public float GetValue()
    {
        throw new NotImplementedException();
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct ClientRandomVariable
{
    public RandomVariable Base;

    public float GetValue()
    {
        throw new NotImplementedException();
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct ReplaceTexture
{
    public AssetReference<Texture> Original;
    public AssetReference<Texture> New;
}

[StructLayout(LayoutKind.Sequential)]
public struct AudioEventInfo
{
}

[StructLayout(LayoutKind.Sequential)]
public struct SoundOrEvaEvent
{
    public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* Sound;
    public unsafe AnsiString* EvaEvent;
}
