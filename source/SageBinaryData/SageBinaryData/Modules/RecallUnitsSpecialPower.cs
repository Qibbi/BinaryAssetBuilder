using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RecallUnitsSpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
        public SageBool PlayReturnVoiceFromRecalledUnit;
    }
}
