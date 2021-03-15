using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BeamTargetModuleData
    {
        public BehaviorModuleData Base;
    }
}
