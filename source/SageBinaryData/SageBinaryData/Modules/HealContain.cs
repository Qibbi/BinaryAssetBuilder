using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HealContainModuleData
    {
        public HordeGarrisonContainModuleData Base;
        public Time TimeForFullHeal;
    }
}
