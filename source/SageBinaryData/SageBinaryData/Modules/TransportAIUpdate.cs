﻿using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TransportAIUpdateModuleData
    {
        public AIUpdateModuleData Base;
    }
}
