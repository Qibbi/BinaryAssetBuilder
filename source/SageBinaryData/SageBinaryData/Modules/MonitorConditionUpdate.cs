using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MonitorConditionUpdateModuleData
{
    public UpdateModuleData Base;
    public ModelConditionBitFlags ModelConditionFlags;
    public TypedAssetId<LogicCommandSet> ModelConditionCommandSetString;
    public WeaponSetBitFlags WeaponFlags;
    public TypedAssetId<LogicCommandSet> WeaponToggleCommandSetString;
}
