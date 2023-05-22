using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RebuildHoleExposeDieModuleData
{
    public DieModuleData Base;
    public TypedAssetId<GameObject> HoleId;
    public float HoleMaxHealth;
    public Time FadeInSeconds;
    public SageBool TransferAttackers;
}
