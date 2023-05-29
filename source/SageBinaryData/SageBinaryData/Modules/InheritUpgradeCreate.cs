using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct InheritUpgradeCreateModuleData
{
    public CreateModuleData Base;
    public float Radius;
    public ObjectFilter ObjectFilter;
    public List<TypedAssetId<UpgradeTemplate>> Upgrade;
}
