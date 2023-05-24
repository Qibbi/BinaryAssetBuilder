using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HordeDispatchSpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
#if KANESWRATH
        public uint MaxMembersToDispatchTo;
#endif
    }
}
