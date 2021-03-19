using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StructureUnpackUpdateModuleData
    {
        public UpdateModuleData Base;
        public Time UnpackTime;
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* UnpackCompleteSound;
    }
}
