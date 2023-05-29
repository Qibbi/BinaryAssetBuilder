using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CaptureBehaviorModuleData
{
    public BehaviorModuleData Base;
    public uint GrantMoney;
    public TypedAssetId<GameObject> SlavedCaptureObject;
    public SageBool GrantMoneyOneTime;
}
