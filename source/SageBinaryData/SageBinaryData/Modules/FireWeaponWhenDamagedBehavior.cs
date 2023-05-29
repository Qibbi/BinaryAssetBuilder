using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FireWeaponWhenDamagedBehaviorModuleData
{
    public UpgradeModuleData Base;
    public uint DamageTypes;
    public float DamageAmount;
    public AssetReference<WeaponTemplate> ReactionWeaponPristine;
    public AssetReference<WeaponTemplate> ReactionWeaponDamaged;
    public AssetReference<WeaponTemplate> ReactionWeaponReallyDamaged;
    public AssetReference<WeaponTemplate> ReactionWeaponRubble;
    public AssetReference<WeaponTemplate> ContinuousWeaponPristine;
    public AssetReference<WeaponTemplate> ContinuousWeaponDamaged;
    public AssetReference<WeaponTemplate> ContinuousWeaponReallyDamaged;
    public AssetReference<WeaponTemplate> ContinuousWeaponRubble;
    public SageBool InitiallyActive;
}
