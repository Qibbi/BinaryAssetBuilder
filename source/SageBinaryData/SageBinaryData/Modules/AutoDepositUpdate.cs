using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum AutoDepositFlagsType
    {
        NONE,
        ACTIVE_WHEN_REPAIRING
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AutoDepositBitFlags
    {
        public const int Count = 0x00000002;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AutoDepositUpdateModuleData
    {
        public UpdateModuleData Base;
        public Time DepositInterval;
        public int DepositAmount;
        public int InitialCaptureBonus;
        public AssetReference<UpgradeTemplate> Upgrade;
        public float UpgradeBonusScalar;
        public AutoDepositBitFlags Flags;
        public unsafe ObjectFilter* ObjectFilter;
        public SageBool GiveNoXP;
        public SageBool OnlyWhenGarrisoned;
    }
}
