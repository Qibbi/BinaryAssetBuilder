using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DamageFXGroup
{
    public DamageFXType Type;
    public float Amount;
    public Time ThrottleTime;
    public AssetReference<FXList> MajorFX;
    public AssetReference<FXList> MinorFX;
    public AssetReference<FXList> MajorVeteranFX;
    public AssetReference<FXList> MinorVeteranFX;
}

[StructLayout(LayoutKind.Sequential)]
public struct VeterancyDamageFXGroup
{
    public DamageFXGroup Base;
    public VeterancyLevel Veterancy;
}

[StructLayout(LayoutKind.Sequential)]
public struct DamageFX
{
    public BaseAssetType Base;
    public List<DamageFXGroup> FXGroup;
    public List<VeterancyDamageFXGroup> VeterancyFXGroup;
}
