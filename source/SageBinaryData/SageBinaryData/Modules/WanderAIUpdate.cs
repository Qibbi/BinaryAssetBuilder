using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WanderAIUpdateModuleData
    {
        public AIUpdateModuleData Base;
        public ModelConditionBitFlags EntryCondition;
        public uint WanderDistance;
        public SageBool AttackAll;
        public SageBool Selectable;
    }
}
