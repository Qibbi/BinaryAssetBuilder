using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct LinearDamageUpdateModuleData
{
    public UpdateModuleData Base;
    public float StartDistanceOffset;
    public float Radius;
    public float Length;
    public AssetReference<FXList> SweepFXList;
    public AssetReference<WeaponTemplate> SweepWeapon;
    public Velocity Speed;
}
