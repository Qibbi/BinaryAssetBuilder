using System;
using System.Runtime.InteropServices;

namespace Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SizeT : IEquatable<SizeT>
    {
#if WIN32
        private readonly uint _value;
#else
        private readonly ulong _value;
#endif

        public SizeT(uint size)
        {
            _value = size;
        }

        public SizeT(int size)
        {
            _value = (uint)size;
        }

        public static bool operator ==(SizeT x, SizeT y)
        {
            return x._value == y._value;
        }

        public static bool operator !=(SizeT x, SizeT y)
        {
            return x._value != y._value;
        }
        public static bool operator >=(SizeT x, SizeT y)
        {
            return x._value >= y._value;
        }
        public static bool operator <=(SizeT x, SizeT y)
        {
            return x._value <= y._value;
        }
        public static bool operator >(SizeT x, SizeT y)
        {
            return x._value > y._value;
        }
        public static bool operator <(SizeT x, SizeT y)
        {
            return x._value < y._value;
        }

        public static explicit operator int(SizeT x)
        {
            return (int)x._value;
        }

#if WIN32
        public static explicit operator uint(SizeT x)
        {
            return x._value;
        }
#else
        public static explicit operator ulong(SizeT x)
        {
            return x._value;
        }
#endif

        public bool Equals(SizeT other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            return obj is SizeT objT && Equals(objT);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
