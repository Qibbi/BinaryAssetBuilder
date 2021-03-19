using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RadarMarkerClientUpdateModuleData
    {
        public ClientUpdateModuleData Base;
        public AnsiString TypeName;
    }
}
