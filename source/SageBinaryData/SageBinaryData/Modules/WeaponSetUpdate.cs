using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct WeaponSlot_WeaponData
{
    public WeaponSlotType Ordering;
    public AssetReference<WeaponTemplate> Template;
    public AssetReference<UpgradeTemplate> Upgrade;
    public ObjectStatusBitFlags ObjectStatus;
    public SageBool IsPlayerUpgradePermanent;
}

public enum WeaponSlotInterleavedStyleType
{
    INTERLEAVE_FIRST_AVAILABLE,
    INTERLEAVE_RANDOM
}

[StructLayout(LayoutKind.Sequential)]
public struct WeaponSlot_Hardpoint : IPolymorphic
{
    public uint TypeId;
    public uint ID;
    public WeaponSlotInterleavedStyleType InterleavedStyle;
    public WeaponChoiceCriteria WeaponChoiceCriteria;
    public List<WeaponSlot_WeaponData> Weapon;
    public SageBool AllowInterleavedFiring;
}

[StructLayout(LayoutKind.Sequential)]
public struct WeaponSlot_Turret
{
    public WeaponSlot_Hardpoint Base;
    public TurretAIData TurretSettings;
}

[StructLayout(LayoutKind.Sequential)]
public struct WeaponSlot_HierarchicalTurret
{
    public WeaponSlot_Turret Base;
    public uint ParentID;
}

[StructLayout(LayoutKind.Sequential)]
public struct WeaponSetUpdateModuleData
{
    public UpdateModuleData Base;
    public List<WeaponSlot_Hardpoint> WeaponSlotHardpoint;
    public List<WeaponSlot_Turret> WeaponSlotTurret;
    public List<WeaponSlot_HierarchicalTurret> WeaponSlotHierarchicalTurret;
}
