using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandButton
    {
        public String<sbyte> Name;
        public uint Index;
        public unsafe ClientRandomVariable* InitialDelay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CommandSet
    {
        public BaseAssetType Base;
        public String<sbyte> Name;
        public int InitialVisible;
        public List<CommandButton> CommandButton;
    }
}
