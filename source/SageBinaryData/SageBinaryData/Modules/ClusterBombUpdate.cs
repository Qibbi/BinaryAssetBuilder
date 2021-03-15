using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClusterBombUpdateModuleData
    {
        public UpdateModuleData Base;
        public AssetReference<WeaponTemplate> WeaponName;
        public unsafe AssetReference<WeaponTemplate>* InitialWeaponName;
        public float Radius;
        public int NumBomblets;
        public Time MinDelay;
        public Time MaxDelay;
        public AssetReference<FXList> BombletFX;
    }
}
