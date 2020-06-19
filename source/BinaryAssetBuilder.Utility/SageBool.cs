using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct SageBool : IComparable<SageBool>, IComparable, IEquatable<SageBool>
{
    private byte _value;

    public bool Value { get => _value != 0; set => _value = (byte)(value ? 1 : 0); }

    public static bool operator ==(SageBool x, SageBool y)
    {
        return x.Value == y.Value;
    }

    public static bool operator !=(SageBool x, SageBool y)
    {
        return x.Value != y.Value;
    }

    public static bool operator !(SageBool x)
    {
        return x.Value;
    }

    public static implicit operator SageBool(bool x)
    {
        return new SageBool { Value = x };
    }

    public static implicit operator bool(SageBool x)
    {
        return x.Value;
    }

    public int CompareTo([AllowNull] SageBool other)
    {
        return _value < other._value ? -1 : _value <= other._value ? 0 : 1;
    }

    public int CompareTo(object obj)
    {
        return obj is SageBool objT ? CompareTo(objT) : 1;
    }

    public bool Equals([AllowNull] SageBool other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is SageBool objT && Equals(objT);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
