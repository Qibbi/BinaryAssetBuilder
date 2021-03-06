using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.Shell
{
    public enum GameplayType
    {
        VERSUS,
        KOTH,
        CAH,
        CTF,
        SIEGE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameplayTypeSetting
    {
        public AnsiString Label;
        public GameplayType Value;
        public SageBool AvailableWithAI;
    }
}
