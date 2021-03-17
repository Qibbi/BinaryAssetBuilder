using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponFireSpecialAbilityUpdateModuleData
    {
        public SpecialAbilityUpdateModuleData Base;
        public AssetReference<WeaponTemplate> SpecialWeapon;
        public int WhichSpecialWeapon;
        public Time BusyForDuration;
        public int WeaponSlotID;
        public WeaponSlotType WeaponSlotType;
        public SageBool SkipContinue;
        public SageBool NeedLivingTargets;
        public SageBool PlayWeaponPreFireFX;
        public SageBool OffsetTargetLocationFromObject;
        public SageBool DestealthClosestObjectMatchingFilter;
    }
}
