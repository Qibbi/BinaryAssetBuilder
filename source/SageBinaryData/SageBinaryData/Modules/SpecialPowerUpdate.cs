using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SpecialPowerUpdateModuleData
{
    public UpdateModuleData Base;
    public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
    public unsafe SoundOrEvaEvent* InitiateSound;
    public SageBool StartsPaused;
}
