using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InvisibilitySpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
        public float BroadcastRadius;
        public uint DurationFrames;
        public unsafe InvisibilityNuggetType* InvisibilityNugget;
        public ObjectFilter ObjectFilter;
    }
}
