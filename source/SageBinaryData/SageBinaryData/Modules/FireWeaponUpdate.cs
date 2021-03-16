﻿using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FireWeaponUpdateModuleDataFireWeaponNugget
    {
        public AssetReference<WeaponTemplate> WeaponName;
        public Time FireDelay;
        public Time FireInterval;
        public unsafe Coord3D* Offset;
        public SageBool OneShot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FireWeaponUpdateModuleData
    {
        public UpdateModuleData Base;
        public DisabledBitFlags ActiveWhenDisabled;
        public List<FireWeaponUpdateModuleDataFireWeaponNugget> FireWeaponNugget;
        public SageBool HeroModeTrigger;
        public SageBool ChargingModeTrigger;
        public SageBool AliveOnly;
    }
}
