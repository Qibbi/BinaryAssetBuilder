using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MinefieldBehaviorModuleData
{
    public UpdateModuleData Base;
    public AssetReference<WeaponTemplate> DetonationWeapon;
    public ObjectFilterRelationshipBitMask DetonatedBy;
    public AssetReference<FXList> DetonationFX;
    public uint NumVirtualMines;
    public float RepeatDetonateMoveThresh;
}
