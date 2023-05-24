#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct TiberiumFieldModBehaviorModuleData
{
    public DieModuleData Base;
    public ObjectStatusBitFlags ObjectStatus;
    public ModelConditionBitFlags ModelCondition;
}
#endif
