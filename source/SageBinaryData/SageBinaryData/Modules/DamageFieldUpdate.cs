using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DamageFieldUpdateModuleData
    {
        public FireWeaponUpdateModuleData Base;
        public int Radius;
        public AssetReference<UpgradeTemplate> RequiredUpgrade;
        public unsafe ObjectFilter* ObjectFilter;
    }
}
