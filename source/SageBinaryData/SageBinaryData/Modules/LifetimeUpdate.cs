using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct LifetimeUpdateModuleData
{
    public UpdateModuleData Base;
    public Time MinLifetime;
    public Time MaxLifetime;
    public DeathType DeathType;
    public SageBool WaitForWakeUp;
    public SageBool ScoreKill;
    public SageBool IgnoreProjectileState;
}
