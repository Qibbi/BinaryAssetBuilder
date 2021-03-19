using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MonitorSpecialPowerTimerUpdateModuleData
    {
        public UpdateModuleData Base;
        public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
        public ModelConditionBitFlags ReadyCondition;
    }
}
