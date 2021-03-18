using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProductionSpeedBonusUpgradeModuleData
    {
        public UpgradeModuleData Base;
        public int Frames;
        public float Bonus;
        public TypedAssetId<GameObject> Template;
    }
}
