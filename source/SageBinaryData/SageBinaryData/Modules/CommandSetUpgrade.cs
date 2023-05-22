using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CommandSetUpgradeModuleData
{
    public UpgradeModuleData Base;
    public TypedAssetId<LogicCommandSet> CommandSet;
}
