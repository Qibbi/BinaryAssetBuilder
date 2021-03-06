using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.Shell
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentBootup
    {
        public UIBaseComponent Base;
        public AnsiString RenderImageName;
        public AnsiString LoadingTextImageName;
    }
}
