using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GrantUpgradeAreaOfEffectSpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
        public float Radius;
        public unsafe ObjectFilter* AcceptObjectFilter;
        public List<AssetReference<UpgradeTemplate>> UpgradeTemplate;
    }
}
