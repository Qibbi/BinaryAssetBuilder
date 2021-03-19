using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RunOffMapBehaviorModuleData
    {
        public BehaviorModuleData Base;
        public AnsiString RunOffMapWaypointName;
        public SageBool RequiresSpecificTrigger;
        public SageBool DieOnMap;
        public SageBool FlyingOffMap;
    }
}
