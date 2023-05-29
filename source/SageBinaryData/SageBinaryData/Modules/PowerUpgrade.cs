using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct PowerUpgradeModuleData
{
    public UpgradeModuleData Base;
}
