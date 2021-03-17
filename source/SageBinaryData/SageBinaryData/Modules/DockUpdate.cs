using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DockUpdateModuleData
    {
        public UpdateModuleData Base;
        public int NumberApproachPositions;
        public Time MinDockTime;
        public Time ObjectsInLineWeight;
        public unsafe ObjectFilter* ForVoiceRetreatThisIsASafeHarborToObjectFilter;
        public SageBool AllowsPassthrough;
        public SageBool GoToRallyPointAfterDock;
        public SageBool ShouldDockInReverse;
    }
}
