using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct KeepObjectDieModuleData
{
    public DieModuleData Base;
    public Time CollapsingTime;
    public SageBool StayOnRadar;
}
