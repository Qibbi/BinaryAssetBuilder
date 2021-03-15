using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HordeAIUpdateModuleData
    {
        public AIUpdateModuleData Base;
    }
}
