using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Query
    {
        public int EMax;
        public int Value;
        public unsafe ObjectFilter* ObjectFilter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AutoAbilityBehaviorModuleData
    {
        public UpdateModuleData Base;
        public float MaxScanRange;
        public float MinScanRange;
        public float Radius;
        public Time IdleSeconds;
        public AssetReference<SpecialPowerTemplate> SpecialAbilityName;
        public ObjectStatusBitFlags ForbiddenStatus;
        public List<Query> Queries;
        public SageBool StartsActive;
        public SageBool UseStartPosition;
        public SageBool AdjustAttackPos;
        public SageBool AllowSelf;
    }
}
