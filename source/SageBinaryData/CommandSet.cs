using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandButton
    {
        public AnsiString Name;
        public uint Index;
        public unsafe ClientRandomVariable* InitialDelay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CommandSet
    {
        public BaseAssetType Base;
        public AnsiString Name;
        public int InitialVisible;
        public List<CommandButton> CommandButton;
    }
}
