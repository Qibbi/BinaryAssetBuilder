using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ModelConditionUpgradeModuleData
    {
        public UpgradeModuleData Base;
        public ModelConditionBitFlags AddConditionFlags;
        public ModelConditionBitFlags RemoveConditionFlags;
        public ModelConditionFlagType AddTempConditionFlag;
        public Time TempConditionTime;
    }
}
