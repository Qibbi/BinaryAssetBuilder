using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SkirmishStartCash
    {
        public int LoCash;
        public int HiCash;
        public int ChoiceStepAmount;
        public int DefaultChoiceIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MpGameRules
    {
        public BaseAssetType Base;
        public SkirmishStartCash SkirmishStartCash;
    }
}
