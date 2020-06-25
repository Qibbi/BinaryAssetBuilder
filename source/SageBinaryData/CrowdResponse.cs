using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Threshold
    {
        public int NumUnits;
        public AudioArrayVoice AudioArrayVoice;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CrowdResponse
    {
        public BaseInheritableAsset Base;
        public int Weight;
        public List<Threshold> Threshold;
    }
}
