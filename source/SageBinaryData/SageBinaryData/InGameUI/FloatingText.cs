using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIFloatingTextSettings
    {
        public Time TimeOut;
        public Velocity MoveUpSpeed;
        public Velocity MoveVanishRate;
        public FontDesc Font;
    }
}
