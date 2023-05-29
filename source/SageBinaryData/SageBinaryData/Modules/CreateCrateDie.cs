#if TIBERIUMWARS
using System.Runtime.InteropServices;
using Relo;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CreateCrateDieModuleData
{
    public DieModuleData Base;
    public List<AnsiString> CrateNameList;
}
#endif
