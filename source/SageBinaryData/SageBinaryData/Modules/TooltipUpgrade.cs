#if TIBERIUMWARS
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct TooltipUpgradeModuleData
{
    public UpgradeModuleData Base;
    public AnsiString NewDisplayName;
    public AnsiString NewDescription;
}
#endif
