using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct TemporarilyDefectUpdateModuleData
{
    public UpdateModuleData Base;
    public Duration DefectionFrameCount;
}
