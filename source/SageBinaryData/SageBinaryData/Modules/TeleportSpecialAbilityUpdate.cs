using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TeleportSpecialAbilityUpdateModuleData
    {
        public SpecialAbilityUpdateModuleData Base;
        public Time BusyDuration;
        public AssetReference<WeaponTemplate> DestinationWeapon;
        public AssetReference<WeaponTemplate> SourceWeapon;
        public float MaxDistance;
        public float HeightToTeleportTo;
        public Time FadeInTime;
    }
}
