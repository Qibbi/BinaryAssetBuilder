using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TiberiumCrystalBehaviorModuleData
    {
        public UpdateModuleData Base;
        public uint NumBoxes;
        public uint ValuePerBox;
        public uint GrowthStages;
        public Time TimeBetweenGrowthStages;
        public Time GrowthTimePerStage;
        public Color RadarColor;
    }
}
