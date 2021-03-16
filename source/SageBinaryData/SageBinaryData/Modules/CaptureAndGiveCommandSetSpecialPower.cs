using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CaptureAndGiveCommandSetSpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
        public TypedAssetId<LogicCommandSet> CommandSet;
    }
}
