#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameLifetimeUpdateModuleData
{
    public UpdateModuleData Base;
    public int LifeTimeTurns;
}
#endif
