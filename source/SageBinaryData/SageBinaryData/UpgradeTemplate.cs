using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UpgradeTemplate
{
    public BaseInheritableAsset Base;
    public AnsiString DisplayName;
    public AnsiString Description;
    public AnsiString TypeDescription;
    public AnsiString AcquireHint;
    public UpgradeType Type;
    public Time BuildTime;
    public int BuildCost;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> ResearchSound;
    public AnsiString ResearchCompleteEvaEvent;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> UnitSpecificSound;
    public AssetReference<FXList> UpgradeFX;
    public AnsiString LocalPlayerGainsUpgradeEvaEvent;
    public AnsiString AlliedPlayerGainsUpgradeEvaEvent;
    public AnsiString EnemyPlayerGainsUpgradeEvaEvent;
    public AnsiString LocalPlayerLosesUpgradeEvaEvent;
    public AnsiString AlliedPlayerLosesUpgradeEvaEvent;
    public AnsiString EnemyPlayerLosesUpgradeEvaEvent;
    public unsafe AnsiString* LocalPlayerProductionStartedEvaEvent;
    public unsafe AnsiString* LocalPlayerBuildOnHoldEvaEvent;
    public unsafe AnsiString* LocalPlayerBuildCancelledEvaEvent;
    public TypedAssetId<BaseAssetType> UseObjectTemplateForCostDiscount; // should be TypedAssetId<GameObject> but .net thinks it might be a circular reference
    public AnsiString GroupName;
    public uint GroupOrder;
    public AIUpgradeHeuristicType SkirmishAIHeuristic;
    public UpgradeOptions Options;
    public AnsiString IconImage;
    public unsafe GameDependencyType* GameDependency;
    public SageBool WaypointQueueable;
}
