using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.Shell
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentMovieArchive
    {
        public UIBaseComponent Base;
        public AnsiString MissionSpec;
    }
}
