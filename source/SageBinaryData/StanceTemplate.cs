using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum Stance
    {
        GUARD,
        AGGRESSIVE,
        HOLD_POSITION,
        HOLD_FIRE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StanceDefinition
    {
        public Stance Type;
        public unsafe AssetReference<AttributeModifier>* AttributeModifier;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StanceTemplate
    {
        public BaseAssetType Base;
        public List<StanceDefinition> StanceDefinition;
    }
}
