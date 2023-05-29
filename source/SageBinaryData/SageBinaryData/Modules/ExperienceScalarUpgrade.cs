using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ExperienceScalarUpgradeModuleData
{
    public UpgradeModuleData Base;
    public float AddXPScalar;
}
