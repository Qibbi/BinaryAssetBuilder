using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DQuadrupedDrawModuleData
    {
        public W3DScriptedModelDrawModuleData Base;
        public AnsiString LeftFrontFootBone;
        public AnsiString RightFrontFootBone;
        public AnsiString LeftRearFootBone;
        public AnsiString RightRearFootBone;
    }
}
