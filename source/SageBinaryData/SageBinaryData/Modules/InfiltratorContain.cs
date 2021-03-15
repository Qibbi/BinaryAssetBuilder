using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum InfiltratorEffectType
    {
        RADAR_FREEZE,
        DISABLE,
        STEAL_MONEY
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InfiltratorContainModuleData
    {
        public ContainModuleData Base;
        public AssetReference<ObjectCreationList> ReplaceWith;
        public Time Duration;
        public InfiltratorEffectType Effect;
        public unsafe ObjectFilter* CanEnterFilter;
        public SageBool ImmediatelyEnabled;
    }
}
