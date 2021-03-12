using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum AIBankAccountType
    {
        INVESTMENT,
        SPECIAL_OPERATIONS,
        PRODUCTION,
        DEFENSE,
        TECHNOLOGY,
        SLUSH_FUND
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIBankBudgetListType
    {
        public AIBankAccountType Account;
        public Percentage Percent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIBankBudget
    {
        public List<AIBankBudgetListType> AccountShare;
    }
}
