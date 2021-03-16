using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RadarSpySpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
        public List<AnsiString> TargetFilter;
        public Time SpyDuration;
    }
}
