using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TiberiumThiefSpecialAbilityUpdateModuleData
    {
        public SpecialAbilityUpdateModuleData Base;
        public int TiberiumStolenPerUpdate;
        public Time DelayBetweenThefts;
        public int TiberiumCapacity;
        public ObjectStatusBitFlags ObjectStatusWhenNotEmpty;
        public ModelConditionBitFlags ModelConditionWhenNotEmpty;
        public SageBool PlayWeaponPreFireFX;
    }
}
