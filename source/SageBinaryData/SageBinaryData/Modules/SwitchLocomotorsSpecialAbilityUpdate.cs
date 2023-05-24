using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SwitchLocomotorsSpecialAbilityUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public Time BusyForDuration;
    public float LandingRange;
    public AssetReference<SpecialPowerTemplate> HordeMembersSpecialPowerTemplate;
    public SageBool UseUpgradedLocomotor;
    public SageBool TriggersLanding;
    public SageBool TriggersFlight;
}
