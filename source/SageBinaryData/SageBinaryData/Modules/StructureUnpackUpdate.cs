using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct StructureUnpackUpdateModuleData
{
    public UpdateModuleData Base;
    public Time UnpackTime;
    public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* UnpackCompleteSound;
}
