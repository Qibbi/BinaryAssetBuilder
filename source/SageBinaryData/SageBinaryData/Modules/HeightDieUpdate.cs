using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HeightDieUpdateModuleData
    {
        public UpdateModuleData Base;
        public float TargetHeight;
        public float DestroyAttachedParticlesAtHeight;
        public Duration InitialDelay;
        public SageBool TargetHeightIncludesStructures;
        public SageBool OnlyWhenMovingDown;
        public SageBool SnapToGroundOnDeath;
    }
}
