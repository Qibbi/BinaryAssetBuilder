using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RadarJamSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
    public float JamRadius;
    public Time JamDuration;
}
