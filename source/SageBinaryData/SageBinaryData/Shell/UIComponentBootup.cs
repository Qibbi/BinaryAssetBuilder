using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentBootup
    {
        public UIBaseComponent Base;
        public AnsiString RenderImageName;
        public AnsiString LoadingTextImageName;
    }
}
