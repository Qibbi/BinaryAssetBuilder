#if KANESWRATH
using System.Runtime.InteropServices;
using Relo;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UpgradeContainerOnContainModuleData
{
    public AnsiString ID;
    public List<ObjectFilter> UnitFilter;
    public List<AssetReference<UpgradeTemplate>> UpgradeList;
}
#endif
