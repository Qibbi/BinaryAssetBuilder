using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SkirmishOpeningMoveOrder
    {
        public Time Time;
        public AnsiString Build;
        public AIBankAccountType Account;
        public uint Deposit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SkirmishOpeningMove
    {
        public BaseAssetType Base;
        public AnsiString Side;
        public List<SkirmishOpeningMoveOrder> Order;
    }
}
