using System;

namespace BinaryAssetBuilder
{
    public abstract class ACommandLineOptionAttribute : Attribute
    {
        public object MinValue { get; }
        public object MaxValue { get; }
        public object[] ValidValueSet { get; }

        public ACommandLineOptionAttribute()
        {
        }

        public ACommandLineOptionAttribute(object minValue, object maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public ACommandLineOptionAttribute(object[] validValueSet)
        {
            ValidValueSet = validValueSet;
        }
    }
}