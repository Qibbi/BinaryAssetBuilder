using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BuildingBehaviorModuleData
    {
        public UpdateModuleData Base;
        public AnsiString NightWindowObject;
        public AnsiString FireWindowObject;
        public AnsiString GlowWindowObject;
        public AnsiString NightFireWindowObject;
    }
}
