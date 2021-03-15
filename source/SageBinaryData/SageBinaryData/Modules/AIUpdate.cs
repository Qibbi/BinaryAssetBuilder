using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum AutoAcquireEnemiesType
    {
        YES,
        STEALTHED,
        NO,
        NOTWHILEATTACKING,
        ATTACK_BUILDINGS
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AutoAcquireEnemiesBitFlags
    {
        public const int Count = 0x00000005;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIUpdateModuleData
    {
        public UpdateModuleData Base;
        public AnsiString AttackPriority;
        public AutoAcquireEnemiesBitFlags AutoAcquireEnemiesWhenIdle;
        public float StopChaseDistance;
        public float HoldGroundCloseRangeDistance;
        public AnsiString AILuaEventsList;
        public Time MinCowerTime;
        public Time MaxCowerTime;
        public Time RampageTime;
        public Time BurningDeathTime;
        public uint TimeToEjectPassengersOnRampage;
        public LocomotorSetType ComboLocomotorSet;
        public float ComboLocoAttackDistance;
        public List<AnsiString> SpecialContactPoints;
        public Time IdleTargetTime;
        public uint MaxCombineChildren;
        public float SpawnOffsetRadius;
        public unsafe UnitAITargetChooserData* UnitAITargetChooserData;
        public SageBool StandGround;
        public SageBool CanAttackWhileContained;
        public SageBool RampageRequiresAflame;
        public SageBool FadeOnPortals;
    }
}
