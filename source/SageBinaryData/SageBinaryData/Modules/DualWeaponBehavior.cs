using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DualWeaponBehaviorModuleData
{
    public BehaviorModuleData Base;
    public float SwitchWeaponOnCloseRangeDistance;
    public uint DelayBetweenSwitches;
    public unsafe ObjectFilter* ObjectFilter;
    public SageBool UseCloseRangeWhileMounted;
    public SageBool UseHordeWeapon;
    public SageBool UseRealVictim;
}
