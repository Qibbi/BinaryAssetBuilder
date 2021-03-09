using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentMovie
    {
        public UIBaseComponent Base;
        public AnsiString MovieComponentName;
        public int MaxNumberOfStream;
    }
}
