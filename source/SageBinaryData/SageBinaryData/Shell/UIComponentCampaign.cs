using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentCampaign
    {
        public UIBaseComponent Base;
        public AnsiString TowToken;
        public AnsiString MissionToken;
        public AnsiString MissionBriefingToken;
        public AnsiString LoadMusic;
    }
}
