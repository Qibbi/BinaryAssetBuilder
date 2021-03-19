using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CreateAndEnterObjectSpecialPowerModuleData
    {
        public OCLSpecialPowerModuleData Base;
        public unsafe Coord3D* FXOffset;
    }
}
