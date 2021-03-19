using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SuppressionUpdateModuleData
    {
        public UpdateModuleData Base;
        public Time UpdateDelay;
        public float Suppressability;
        public Time SuppressionDuration;
        public AssetReference<AttributeModifier> AttributeModifierSuppressed;
        public AssetReference<AttributeModifier> AttributeModifierForceMove;
        public ObjectStatusBitFlags IgnoreSuppressionObjectStatus;
    }
}
