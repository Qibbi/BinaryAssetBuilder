using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DSpotlightDrawModuleData
    {
        public W3DScriptedModelDrawModuleData Base;
        public Time RefreshTime;
        public Time SweepTime;
    }
}
