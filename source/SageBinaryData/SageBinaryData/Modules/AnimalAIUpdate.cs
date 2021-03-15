using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AnimalAIUpdateModuleData
    {
        public AIUpdateModuleData Base;
        public int FleeRadius;
        public int FleeDistance;
        public int WanderPercentage;
        public int MinDistance;
        public int MaxDistance;
        public int Radius;
        public Time FleeUpdateTimer;
        public Time WanderUpdateTimer;
        public float InitialFleeBlindlyRadius;
        public SageBool AfraidOfCastles;
    }
}
