﻿#if TIBERIUMWARS
using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RespawnRuleType
{
    public uint Time;
    public Percentage Health;
    public uint Cost;
    public uint Level;
    public SageBool AutoSpawn;
}

[StructLayout(LayoutKind.Sequential)]
public struct RespawnUpdateModuleData
{
    public UpdateModuleData Base;
    public ModelConditionBitFlags DeathMC;
    public AssetReference<FXList> DeathFX;
    public Duration DeathAnimationTime;
    public ModelConditionBitFlags SpawnMC;
    public AssetReference<FXList> SpawnFX;
    public Duration SpawnAnimationTime;
    public ModelConditionBitFlags RespawnMC;
    public AssetReference<FXList> RespawnFX;
    public Duration RespawnAnimationTime;
    public AssetReference<PackedTextureImage> ButtonImage;
    public TypedAssetId<GameObject> RespawnAsTemplate;
    public List<RespawnRuleType> Rule;
    public unsafe ObjectFilter* AutoRespawnAtObjectFilter;
}
#endif
