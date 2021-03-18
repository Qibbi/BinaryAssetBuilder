using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SquishCollideModuleData
    {
        public CollideModuleData Base;
        public Time CrushAnimTime;
        public Time CrushKillDelay;
        public SageBool UseDirectionCheck;
    }
}
