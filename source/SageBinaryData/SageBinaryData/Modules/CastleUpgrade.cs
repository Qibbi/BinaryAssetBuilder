using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CastleUpgradeModuleData
{
    public UpgradeModuleData Base;
    public AssetReference<UpgradeTemplate> Upgrade;
    public float WallUpgradeRadius;
}
