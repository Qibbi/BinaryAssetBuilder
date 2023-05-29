using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct PlayerPowerManagerBehaviorModuleData
{
    public UpdateModuleData Base;
    public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
}
