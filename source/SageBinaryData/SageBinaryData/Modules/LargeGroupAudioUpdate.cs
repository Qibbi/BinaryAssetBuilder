using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct LargeGroupAudioUpdateModuleData
{
    public UpdateModuleData Base;
    public Duration FramesBetweenUpdatesMin;
    public Duration FramesBetweenUpdatesVariation;
    public List<StringHash> Key;
    public ushort UnitWeight;
}
