using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct EMPUpdateModuleData
{
    public UpdateModuleData Base;
    public Time Lifetime;
    public Time StartFadeDelay;
    public Time DisabledDuration;
    public float StartScale;
    public float TargetScaleMin;
    public float TargetScaleMax;
    public AssetReference<FXParticleSystemTemplate> DisableFXParticleSystem;
    public float SparksPerCubicFoot;
    public unsafe Color3f* StartColor;
    public unsafe Color3f* EndColor;
}
