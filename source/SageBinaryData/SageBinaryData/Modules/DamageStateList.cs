using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DamageState
{
    public Percentage MinHealth;
    public Percentage MaxHealth;
    public ObjectStatusBitFlags ObjectStatus;
    public ModelConditionBitFlags ModelConditions;
}

[StructLayout(LayoutKind.Sequential)]
public struct DamageStateListModuleData
{
    public DamageModuleData Base;
    public List<DamageState> Data;
}
