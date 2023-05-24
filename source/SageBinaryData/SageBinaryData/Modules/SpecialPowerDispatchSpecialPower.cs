using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DispatchSpecialPowerType
{
    public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
}

[StructLayout(LayoutKind.Sequential)]
public struct SpecialPowerDispatchSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
    public List<DispatchSpecialPowerType> SpecialPower;
    public SageBool RequireAllPowersToFunction;
}
