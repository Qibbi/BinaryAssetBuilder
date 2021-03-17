using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponFireProbabilityType
    {
        public DeathBitFlags DeathType;
        public uint ChancePercentage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FireWeaponWhenDeadBehaviorModuleData
    {
        public UpgradeModuleData Base;
        public Time DelayTime;
        public AssetReference<WeaponTemplate> DeathWeapon;
        public KindOfBitFlags FocusFireKindOfFlag;
        public unsafe Coord3D* WeaponOffset;
        public DieMuxDataType DieMuxData;
        public List<WeaponFireProbabilityType> WeaponFireProbability;
        public SageBool InitiallyActive;
        public SageBool ActiveDuringConstruction;
        public SageBool ContinueToBezierDestination;
    }
}
