using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ExperienceLevelCreateModuleData
    {
        public CreateModuleData Base;
        public int Level;
        public SageBool MPOnly;
    }
}
