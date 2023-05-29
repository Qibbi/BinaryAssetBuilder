using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DockUpdateModuleData
{
    public UpdateModuleData Base;
    public int NumberApproachPositions;
    public Time MinDockTime;
    /// <summary>
    /// This is to be added to the computeRelativeCost on a per object waiting to dock with this dock. Makes it less
    /// likely to be picked by the object for each object in line.
    /// </summary>
    public Time ObjectsInLineWeight;
    public unsafe ObjectFilter* ForVoiceRetreatThisIsASafeHarborToObjectFilter;
    public SageBool AllowsPassthrough;
    public SageBool GoToRallyPointAfterDock;
    public SageBool ShouldDockInReverse;
}
