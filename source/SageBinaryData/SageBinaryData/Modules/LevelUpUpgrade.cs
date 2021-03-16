using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LevelUpUpgradeModuleData
    {
        public UpgradeModuleData Base;
        public int LevelsToGain;
        public int LevelCap;
        public SageBool DoFlash;
    }
}
