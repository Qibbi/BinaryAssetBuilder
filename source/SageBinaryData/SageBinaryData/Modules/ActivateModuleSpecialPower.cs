using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

public enum TriggerType
{
    SELF_POSITION,
    TARGET_POSITION,
    TARGET_OBJECT
}

[StructLayout(LayoutKind.Sequential)]
public struct SpecialPowerModuleInfo
{
    public TypedAssetId<ModuleData> ModuleId;
    public TriggerType TriggerType;
    public SageBool TriggerAtTargetPosition;
}

[StructLayout(LayoutKind.Sequential)]
public struct ActivateModuleSpecialPowerModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public List<SpecialPowerModuleInfo> SpecialPowerModules;
}
