#if KANESWRATH
using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SpecialDisguiseUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public float OpacityTarget;
    public TypedAssetId<GameObject> DisguiseAsTemplateId;
    public TypedAssetId<GameObject> EnemyPerspectiveDisguisedTemplateId;
    public AssetReference<FXList> DisguiseFX;
    public SageBool TriggerInstantlyOnCreate;
    public SageBool ForceMountedWhenDisguising;
}
#endif
