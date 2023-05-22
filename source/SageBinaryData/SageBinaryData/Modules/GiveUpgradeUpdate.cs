using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct GiveUpgradeUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public AssetReference<FXList> GiveUpgradeEffect;
    public AssetReference<FXList> SpawnOutFX;
    public float FadeOutSpeed;
    public SageBool DeliverUpgrade;
}
