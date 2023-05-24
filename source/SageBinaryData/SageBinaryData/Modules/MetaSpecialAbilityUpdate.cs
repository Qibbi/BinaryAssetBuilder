#if KANESWRATH
using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaSpecialAbilityUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    /// <summary>
    /// If TargetKindOf is set, the getReachableTargets method will use a BeamSpecialAbilityUpdate-like
    /// method of drawing target circles. It will draw circles around all Allied, alive objects
    /// matching the kindof list in TargetKindOf.
    /// </summary>
    public KindOfBitFlags TargetKindOf;
    /// <summary>
    /// Used only for SPECIAL ONE BUTTON TO MOVE THEM ALL hackery DO NOT USE!
    /// </summary>
    public List<MetagameOperationsEnums> MetaGameOPtoUse;
    public List<TypedAssetId<UpgradeTemplate>> UpgradeToWatchFor;
    public List<float> RadiusOfDropZone;
    public List<ObjectFilter> ObjectFilter;
    /// <summary>
    /// If TargetSelf is set to true, TargetKindOf will be ignored.
    /// </summary>
    public SageBool TargetSelf;
    /// <summary>
    /// This is used only for the SPECIAL ONE BUTTON TO MOVE THEM ALL power.
    /// </summary>
    public SageBool SpecialMove;
}
#endif
