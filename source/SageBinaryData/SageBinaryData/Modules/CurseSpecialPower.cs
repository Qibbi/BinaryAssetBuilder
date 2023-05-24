using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CurseSpecialPowerModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public AssetReference<FXList> TriggerFX;
    public AssetReference<FXList> CurseFX;
    public float CurseFactor;
    public ObjectFilter AffectObjectFilter;
    public SageBool CurseAllPlayerPowers;
}
