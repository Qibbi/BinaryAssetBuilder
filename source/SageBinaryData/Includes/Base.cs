using System;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum DistributionType
    {
        CONSTANT,
        UNIFORM,
        GAUSSIAN,
        TRIANGULAR,
        LOW_BIAS,
        HIGH_BIAS
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RandomVariable
    {
        public DistributionType Type;
        public float Low;
        public float High;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LogicRandomVariable
    {
        public RandomVariable Base;

        public float GetValue()
        {
            throw new NotImplementedException();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ClientRandomVariable
    {
        public RandomVariable Base;

        public float GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
