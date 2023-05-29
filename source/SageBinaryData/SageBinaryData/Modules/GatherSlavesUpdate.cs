using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct GatherSlavesUpdateModuleData
{
    public UpdateModuleData Base;
    public AssetReference<GameObject> SlaveTemplate;
    public float Radius;
    public uint Amount;
}
