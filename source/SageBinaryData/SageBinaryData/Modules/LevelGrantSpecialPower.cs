﻿using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct LevelGrantSpecialPowerModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public int Experience;
    public float RadiusEffect;
    public AssetReference<FXList> LevelFX;
    public unsafe ObjectFilter* AcceptanceFilter;
}
