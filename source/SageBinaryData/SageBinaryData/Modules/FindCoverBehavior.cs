using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FindCoverBehaviorModuleData
    {
        public UpdateModuleData Base;
        public AssetReference<AttributeModifier> AttributeModifierInCover;
        public float CoverScanRange;
    }
}
