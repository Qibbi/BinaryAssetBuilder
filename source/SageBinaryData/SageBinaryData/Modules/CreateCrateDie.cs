using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CreateCrateDieModuleData
    {
        public DieModuleData Base;
        public List<AnsiString> CrateNameList;
    }
}
