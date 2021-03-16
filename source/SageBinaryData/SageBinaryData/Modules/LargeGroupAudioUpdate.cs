using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LargeGroupAudioUpdateModuleData
    {
        public UpdateModuleData Base;
        public uint FramesBetweenUpdatesMin;
        public uint FramesBetweenUpdatesVariation;
        public uint UnitWeight;
        public List<StringHash> Key;
    }
}
