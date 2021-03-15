using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RespawnBodyModuleData
    {
        public ActiveBodyModuleData Base;
        public unsafe ObjectFilter* PermanentlyKilledByFilter;
        public SageBool UseRespawn;
    }
}
