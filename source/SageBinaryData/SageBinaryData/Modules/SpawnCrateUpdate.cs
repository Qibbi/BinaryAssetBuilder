using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

public enum SpawnCrateUpdateFlagsType
{
    NONE,
    DELETE_EXPIRED_CRATES
}

[StructLayout(LayoutKind.Sequential)]
public struct SpawnCrateUpdateFlagsBitFlags
{
    public const int Count = 2;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

[StructLayout(LayoutKind.Sequential)]
public struct SpawnCrateUpdateModuleData
{
    public UpdateModuleData Base;
    public uint MaxCrates;
    public Time CreateFrequency;
    public Time CrateLifetime;
    public float MapExclusionMargin;
    public float BlockingUnitRange;
    public float BlockingStartPositionRange;
    public SpawnCrateUpdateFlagsBitFlags Flags;
    public List<AssetReference<GameObject>> CrateList;
    public unsafe ObjectFilter* BlockingUnits;
}
