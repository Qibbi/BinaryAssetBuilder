﻿using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct StealUnitUpdateModuleData
{
    public AttachUpdateModuleData Base;
}
