using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DominateEnemySpecialPowerModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public float DominateRadius;
    public AssetReference<FXList> TriggerFX;
    public AssetReference<FXList> DominatedFX;
#if KANESWRATH
    public AssetReference<FXList> FiringFX;
#endif
    public unsafe ObjectFilter* AttributeModifierAffects;
    public SageBool PermanentlyConvert;
}
