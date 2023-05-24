using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CrateCollideModuleData
{
    public CollideModuleData Base;
    public KindOfBitFlags KindOf;
    public KindOfBitFlags KindOfNot;
    public ScienceType PickupScience;
    public AssetReference<FXList> ExecuteFX;
    public TypedAssetId<GameObject> ExecutionAnimationTemplate;
    public float ExecuteAnimationDisplayTimeInSeconds;
    public float ExecuteAnimationZRisePerSecond;
    public SageBool IsForbidOwnerPlayer;
    public SageBool IsBuildingPickup;
    public SageBool IsHumanOnlyPickup;
    public SageBool IsHumanOnlyPickupInSinglePlayerCampaign;
    public SageBool ExecuteAnimationFades;
}
