using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RebuildHoleBehaviorModuleData
{
    public UpdateModuleData Base;
    public Time WorkerRespawnDelay;
    public Percentage HoleHealthRegenPercentPerSecond;
    public TypedAssetId<GameObject> WorkerTemplate;
}
