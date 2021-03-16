using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OilSpillUpdateModuleData
    {
        public FireWeaponUpdateModuleData Base;
        public TypedAssetId<GameObject> BreadCrumb;
        public AssetReference<WeaponTemplate> IgnitionWeaponName;
        public float IgnitionWeaponSpacing;
        public AssetReference<FXList> OilSpillFX;
    }
}
