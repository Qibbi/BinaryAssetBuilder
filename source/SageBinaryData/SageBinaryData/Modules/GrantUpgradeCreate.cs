using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct GrantUpgradeCreateModuleData
{
    public CreateModuleData Base;
    public AssetReference<UpgradeTemplate> UpgradeToGrant;
    public ObjectStatusBitFlags ExemptStatus;
    public SageBool GiveOnBuildComplete;
}
