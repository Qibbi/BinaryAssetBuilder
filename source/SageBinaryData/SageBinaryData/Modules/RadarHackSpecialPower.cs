using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RadarHackSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
    public uint NumFalseReturns;
    public float Radius;
    public Time HackDuration;
}
