﻿using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MoveToPositionAndReplaceSelfSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
}
