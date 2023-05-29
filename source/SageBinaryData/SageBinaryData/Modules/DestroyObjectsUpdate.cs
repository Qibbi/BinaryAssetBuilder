using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DestroyObjectsUpdateModuleData
{
    public UpdateModuleData Base;
    public float Radius;
    public ObjectFilter ObjectFilter;
}
