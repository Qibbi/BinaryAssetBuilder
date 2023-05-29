using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct KindOfAndStatusAndModelConditionType
{
    public ObjectStatusBitFlags ObjectStatus;
    public ModelConditionBitFlags ModelCondition;
    public KindOfBitFlags KindOf;
    public SageBool UseLocalPlayerFilter;
}

[StructLayout(LayoutKind.Sequential)]
public struct RadarScanMapSpecialAbilityUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public List<KindOfAndStatusAndModelConditionType> IntersectionFlagsFilter;
}
