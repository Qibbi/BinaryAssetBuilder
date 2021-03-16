using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RandomModelConditionBehaviorModuleData
    {
        public CreateModuleData Base;
        public List<AnsiString> Conditions;
    }
}
