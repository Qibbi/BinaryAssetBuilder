using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InactiveBodyModuleData
    {
        public BodyModuleData Base;
    }
}
