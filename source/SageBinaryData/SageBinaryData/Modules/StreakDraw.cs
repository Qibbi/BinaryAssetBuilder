using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DStreakDrawModuleData
    {
        public DrawModuleData Base;
        public float Length;
        public float Width;
        public uint NumSegments;
        public AssetReference<Texture> Texture;
        public List<WeatherTexture> WeatherTexture;
        public unsafe Color3f* Color;
        public SageBool Additive;
    }
}
