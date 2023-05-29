using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MonitorSpecialPowerTimerUpdateModuleData
{
    public UpdateModuleData Base;
    public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
    public ModelConditionBitFlags ReadyCondition;
}
