using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RadarFreezeSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
    public List<AnsiString> TargetFilter;
    public Time FreezeDuration;
}
