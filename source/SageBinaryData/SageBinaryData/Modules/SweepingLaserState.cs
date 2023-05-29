using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SweepingLaserStateModuleData
{
    public LaserStateModuleData Base;
    public float Radius;
    public AssetReference<FXList> SweepFXList;
    public AssetReference<FXList> VeteranSweepFXList;
    public Time SweepFXTimeout;
    public AssetReference<WeaponTemplate> SweepWeapon;
}
