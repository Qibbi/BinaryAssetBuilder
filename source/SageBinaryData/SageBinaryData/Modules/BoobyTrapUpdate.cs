﻿using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct BoobyTrapUpdateModuleData
{
    public AttachUpdateModuleData Base;
    public ObjectStatusBitFlags FireWeaponConditionsOnParent;
    public ObjectStatusBitFlags PreventEnteringSetStatusOnParent;
    public AssetReference<WeaponTemplate> SpecialWeapon;
    public unsafe ObjectFilter* PreventEnteringFilter;
    public SageBool AllowTriggerOnAllies;
}
