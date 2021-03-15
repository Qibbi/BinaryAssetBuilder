using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LockonInfo
    {
        public uint LockonTime;
        public AnsiString LockonCursor;
        public float LockonInitialDist;
        public float LockonFreq;
        public Angle LockonAngleSpin;
        public SageBool LockonBlinky;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct JetAIUpdateModuleData
    {
        public AIUpdateModuleData Base;
        public Percentage OutOfAmmoDamagePerSecond;
        public Time OutOfAmmoDamageDelay;
        public Percentage TakeoffSpeedForMaxLift;
        public uint TakeoffPause;
        public float MinHeight;
        public float ParkingOffset;
        public float SneakyOffsetWhenAttacking;
        public LocomotorSetType AttackLocomotorType;
        public uint AttackLocomotorPersistTime;
        public uint AttackersMissPersistTime;
        public LocomotorSetType ReturnForAmmoLocomotorType;
        public uint ReturnToBaseIdleTime;
        public AssetReference<WeaponTemplate> UseForOutOfAmmoCheck;
        public AnsiString OutOfAmmoEvaEvent;
        public LockonInfo LockonInfo;
        public SageBool NeedsRunway;
        public SageBool ReturnToBaseWhenVictimDead;
        public SageBool KeepsParkingSpaceWhenAirborne;
        public SageBool CirclesForAttack;
    }
}
