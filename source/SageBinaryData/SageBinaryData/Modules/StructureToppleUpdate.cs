using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct StructureToppleUpdateFXBoneInfo
{
    public AnsiString BoneName;
    public AssetReference<FXParticleSystemTemplate> ParticleSystemTemplate;
}

[StructLayout(LayoutKind.Sequential)]
public struct StructureToppleUpdateAngleFXInfo
{
    public Angle Angle;
    public AssetReference<FXList> FXList;
}
[StructLayout(LayoutKind.Sequential)]
public struct StructureToppleUpdateModuleData
{
    public UpdateModuleData Base;
    public Time MinToppleDelay;
    public Time MaxToppleDelay;
    public float StructuralIntegrity;
    public float StructuralDecay;
    public float ToppleAccelerationFactor;
    public DamageBitFlags DamageFXTypes;
    public AssetReference<FXList> ToppleStartFXList;
    public AssetReference<FXList> ToppleDelayFXList;
    public AssetReference<FXList> ToppleFXList;
    public AssetReference<FXList> ToppleDoneFXList;
    public AssetReference<FXList> CrushingFXList;
    public AssetReference<WeaponTemplate> CrushingWeaponName;
    public Time MinToppleBurstDelay;
    public Time MaxToppleBurstDelay;
    public float ForceToppleAngle;
    public List<AssetReference<ObjectCreationList>> OCLs;
    public List<int> OCLCount;
    public List<StructureToppleUpdateFXBoneInfo> FXBones;
    public List<StructureToppleUpdateAngleFXInfo> AngleFX;
    public unsafe DieMuxDataType* Die;
}
