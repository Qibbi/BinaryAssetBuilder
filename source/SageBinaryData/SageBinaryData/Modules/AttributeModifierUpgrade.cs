using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct AttributeModifierUpgradeModuleData
{
    public UpgradeModuleData Base;
    public AssetReference<AttributeModifier> AttributeModifier;
}
