using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentObjectives
    {
        public UIBaseComponent Base;
        public AnsiString AptStringNewBonusObjective;
        public AnsiString AptStringObjectiveCompleted;
    }
}
