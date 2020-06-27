using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct CBool : IComparable<CBool>, IComparable, IEquatable<CBool>
{
    private uint _value;

    public bool Value { get => _value != 0u; set => _value = (value ? 1u : 0u); }

    public static bool operator ==(CBool x, CBool y)
    {
        return x.Value == y.Value;
    }

    public static bool operator !=(CBool x, CBool y)
    {
        return x.Value != y.Value;
    }

    public static bool operator !(CBool x)
    {
        return !x.Value;
    }

    public static implicit operator CBool(bool x)
    {
        return new CBool { Value = x };
    }

    public static implicit operator bool(CBool x)
    {
        return x.Value;
    }

    public static explicit operator CBool(int x)
    {
        return new CBool { _value = (uint)x };
    }

    public static explicit operator int(CBool x)
    {
        return (int)x._value;
    }

    public int CompareTo([AllowNull] CBool other)
    {
        return _value < other._value ? -1 : _value <= other._value ? 0 : 1;
    }

    public int CompareTo(object obj)
    {
        return obj is CBool objT ? CompareTo(objT) : 1;
    }

    public bool Equals([AllowNull] CBool other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is CBool objT && Equals(objT);
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
