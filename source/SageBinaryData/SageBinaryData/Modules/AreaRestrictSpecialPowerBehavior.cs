using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct AreaRestrictSpecialPowerBehaviorModuleData
{
    public BehaviorModuleData Base;
    public SpecialPowerRestrictionType RestrictionType;
    public AnsiString AreaName;
}
