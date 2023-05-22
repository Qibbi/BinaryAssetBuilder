using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

public enum WhereToFireType
{
    TARGET_OBJECT,
    TARGET_POSITION,
    OWNER_POSITION
}

public enum FireWeaponFlagsType
{
    NONE,
    TARGET_MUST_BE_MOVING
}

[StructLayout(LayoutKind.Sequential)]
public struct FireWeaponFlagsBitFlags
{
    public const int Count = 2;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

[StructLayout(LayoutKind.Sequential)]
public struct FireWeaponCollideModuleData
{
    public CollideModuleData Base;
    public AssetReference<WeaponTemplate> CollideWeapon;
    public FireWeaponFlagsBitFlags Flags;
    public ObjectStatusBitFlags RequiredStatus;
    public ObjectStatusBitFlags ForbiddenStatus;
    public WhereToFireType WhereToFire;
    public SageBool FireOnce;
}
