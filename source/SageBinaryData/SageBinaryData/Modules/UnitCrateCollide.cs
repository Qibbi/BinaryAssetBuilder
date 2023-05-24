using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UnitCrateCollideModuleData
{
    public CrateCollideModuleData Base;
    public uint UnitCount;
    public TypedAssetId<GameObject> UnitType;
}
