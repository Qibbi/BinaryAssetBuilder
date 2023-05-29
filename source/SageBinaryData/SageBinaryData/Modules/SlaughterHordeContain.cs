using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SlaughterHordeContainModuleData
{
    public HordeGarrisonContainModuleData Base;
    public float CashBackPercent;
    public ObjectStatusBitFlags CanAlwaysEnterStatus;
    public ObjectFilter CanAlwaysEnterObjectFilter;
}
