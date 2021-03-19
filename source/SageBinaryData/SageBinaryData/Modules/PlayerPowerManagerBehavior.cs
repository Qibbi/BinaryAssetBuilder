using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PlayerPowerManagerBehaviorModuleData
    {
        public UpdateModuleData Base;
        public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
    }
}
