using System;
using System.Runtime.CompilerServices;

namespace Mathematics
{
    public static class MathUtil
    {
        public const float Pi = 3.1415926535897932f;
        public const double PiDouble = 3.1415926535897932;
        public const float PiInv = 1 / Pi;
        public const double PiInvDouble = 1 / PiDouble;
        public const float PiHalf = Pi / 2;
        public const double PiHalfDouble = PiDouble / 2;
        public const float TwoPi = 2 * Pi;
        public const double TwoPiDouble = 2 * PiDouble;
        public const float PiOverTwo = Pi / 2;
        public const double PiOverTwoDouble = PiDouble / 2;
        public const float NumberSmall = 1e-8f;
        public const float NumberKindaSmall = 1e-4f;
        public const float NumberBig = 3.4e+38f;
        public const float EulersNumber = 2.71828182845904523536f;
        public const double EulerNumberDouble = 2.71828182845904523536;
        public const float Epsilon = 1.401298e-45f;
        public const float EpsilonHalf = 4.887581e-4f;
        public const double EpsilonDouble = 4.94065645841247e-324;
        public const float FloatMax = 3.402823466e+38f;
        public const float ThresholdNormal = 0.0001f;
        public const float ThresholdPointOnPlane = 0.1f;
        public const float ThresholdPointOnSide = 0.2f;
        public const float ThresholdPointsAreSame = 0.00002f;
        public const float ThresholdPointsAreNear = 0.015f;
        public const float ThresholdNormalsAreSame = 0.00002f;
        public const float ThresholdVectorsAreNear = 0.0004f;

        private static Random _random = new Random();
        private static int _sRandSeed;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int RandHelper(int value)
        {
            return value > 0 ? Min(TruncToInt(RandInt() * value), value - 1) : 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int TruncToInt(float f)
        {
            return (int)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int TruncToInt(double d)
        {
            return (int)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float TruncToFloat(float f)
        {
            return TruncToInt(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long TruncToLong(double d)
        {
            return (long)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TruncToDouble(double d)
        {
            return TruncToLong(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FloorToInt(float f)
        {
            return TruncToInt((float)Math.Floor(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FloorToInt(double d)
        {
            return TruncToInt(Math.Floor(d));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FloorToFloat(float f)
        {
            return (float)Math.Floor(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FloorToDouble(double d)
        {
            return Math.Floor(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundToInt(float f)
        {
            return FloorToInt(f + 0.5f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundToInt(double d)
        {
            return FloorToInt(d + 0.5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RoundToFloat(float f)
        {
            return FloorToFloat(f + 0.5f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RoundToDouble(double d)
        {
            return FloorToDouble(d + 0.5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CeilToInt(float f)
        {
            return TruncToInt((float)Math.Ceiling(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CeilToInt(double d)
        {
            return TruncToInt(Math.Ceiling(d));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CeilToFloat(float f)
        {
            return (float)Math.Ceiling(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CeilToDouble(double d)
        {
            return Math.Ceiling(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FractionalFloat(float f)
        {
            return f - TruncToFloat(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FractionalDouble(double d)
        {
            return d - TruncToDouble(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Frac(float f)
        {
            return f - FloorToFloat(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double FracDouble(double d)
        {
            return d - FloorToDouble(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Mod(float f, out float intPart)
        {
            intPart = FractionalFloat(f);
            return f - intPart;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Mod(double d, out double intPart)
        {
            intPart = FractionalDouble(d);
            return d - intPart;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(float f)
        {
            return (float)Math.Exp(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp2(float f)
        {
            return (float)Math.Pow(2.0, f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LogE(float f)
        {
            return (float)Math.Log(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LogX(float @base, float f)
        {
            return LogE(f) / LogE(@base);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log2(float f)
        {
            return LogE(f) * 1.4426950f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float FMod(float x, float y)
        {
            if (Math.Abs(y) <= 1e-8f)
            {
                // Error
                return 0.0f;
            }
            float quotient = TruncToFloat(x / y);
            float intPortion = y * quotient;
            if (Math.Abs(intPortion) > Math.Abs(x))
            {
                intPortion = x;
            }
            return x - intPortion;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float f)
        {
            return (float)Math.Sin(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sin(double d)
        {
            return Math.Sin(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float f)
        {
            return (float)Math.Asin(f < -1.0f ? -1.0f : f < 1.0f ? f : 1.0f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sinh(float f)
        {
            return (float)Math.Sinh(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float f)
        {
            return (float)Math.Cos(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float f)
        {
            return (float)Math.Acos(f < -1.0f ? -1.0f : f < 1.0f ? f : 1.0f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(float f)
        {
            return (float)Math.Tan(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float f)
        {
            return (float)Math.Atan(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sqrt(int i)
        {
            return (int)Math.Sqrt(i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float f)
        {
            return (float)Math.Sqrt(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Pow(int x, int y)
        {
            return (int)Math.Pow(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float x, float y)
        {
            return (float)Math.Pow(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float InvSqrt(float f)
        {
            return (float)(1.0 / Math.Sqrt(f));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsNan(float f)
        {
            return ((*(uint*)&f) & 0x7FFFFFFF) > 0x7F800000;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsFinite(float f)
        {
            return ((*(uint*)&f) & 0x7F800000) != 0x7F800000;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsNegativeFloat(float f)
        {
            return (*(uint*)&f) >= 0x80000000u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsNegativeDouble(double d)
        {
            return (*(ulong*)&d) >= 0x8000000000000000u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RandInit(int seed)
        {
            _random = new Random(seed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RandInt()
        {
            return _random.Next();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RandFloat()
        {
            return _random.Next() / (float)int.MaxValue;
        }

        public static void SRandInit(int seed)
        {
            _sRandSeed = seed;
        }

        public static int GetSRandSeed()
        {
            return _sRandSeed;
        }

        public static unsafe float SRand()
        {
            unchecked
            {
                _sRandSeed = (_sRandSeed * 196314165) + 907633515;
            }
            float sRandTemp = 1.0f;
            uint temp = *(uint*)&sRandTemp;
            temp = (temp & 0xFF800000) | (uint)(_sRandSeed & 0x007FFFFF);
            return FractionalFloat(*(float*)&temp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint FloorLog2(uint value)
        {
            uint result = 0;
            if (value >= 1 << 16)
            {
                value >>= 16;
                result += 16;
            }
            if (value >= 1 << 8)
            {
                value >>= 8;
                result += 8;
            }
            if (value >= 1 << 4)
            {
                value >>= 4;
                result += 4;
            }
            if (value >= 1 << 2)
            {
                value >>= 2;
                result += 2;
            }
            if (value >= 1 << 1)
            {
                result += 1;
            }
            return value == 0 ? 0 : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong FloorLog2(ulong value)
        {
            ulong result = 0;
            if (value >= 1 << 32)
            {
                value >>= 32;
                result += 32;
            }
            if (value >= 1 << 16)
            {
                value >>= 16;
                result += 16;
            }
            if (value >= 1 << 8)
            {
                value >>= 8;
                result += 8;
            }
            if (value >= 1 << 4)
            {
                value >>= 4;
                result += 4;
            }
            if (value >= 1 << 2)
            {
                value >>= 2;
                result += 2;
            }
            if (value >= 1 << 1)
            {
                result += 1;
            }
            return value == 0 ? 0 : result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CountLeadingZeros(uint value)
        {
            if (value == 0u)
            {
                return 32u;
            }
            return 31u - FloorLog2(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CountLeadingZeros(ulong value)
        {
            if (value == 0UL)
            {
                return 64UL;
            }
            return 63UL - FloorLog2(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CountTrailingZeros(uint value)
        {
            if (value == 0u)
            {
                return 32u;
            }
            uint result = 0;
            while ((value & 1) == 0)
            {
                value >>= 1;
                ++result;
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CeilLog2(uint value)
        {
            return (32 - CountLeadingZeros(value - 1)) & (uint)~(((int)(CountLeadingZeros(value) << 26)) >> 31); ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CeilLog2(ulong value)
        {
            return (64 - CountLeadingZeros(value - 1)) & (ulong)~(((long)(CountLeadingZeros(value) << 57)) >> 63); ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RoundUpToPowerOfTwo(uint value)
        {
            return 1u << (int)CeilLog2(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SelectFloat(float comp, float valueGEZero, float valueLTZero)
        {
            return comp >= 0.0f ? valueGEZero : valueLTZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SelectDouble(double comp, double valueGEZero, double valueLTZero)
        {
            return comp >= 0.0 ? valueGEZero : valueLTZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RandIntRange(int min, int max)
        {
            return min + RandHelper(max - min + 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RandFloatRange(float min, float max)
        {
            return min + ((max - min) * RandFloat());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RandBool()
        {
            return RandIntRange(0, 1) == 1 ? true : false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Abs(sbyte x)
        {
            return x >= 0 ? x : (sbyte)-x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Abs(short x)
        {
            return x >= 0 ? x : (short)-x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Abs(int x)
        {
            return x >= 0 ? x : -x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Abs(long x)
        {
            return x >= 0L ? x : -x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float x)
        {
            return x >= 0.0f ? x : -x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Abs(double x)
        {
            return x >= 0.0 ? x : -x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Sign(sbyte x)
        {
            return x > 0 ? (sbyte)1 : x < 0 ? (sbyte)-1 : (sbyte)0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Sign(short x)
        {
            return x > 0 ? (short)1 : x < 0 ? (short)-1 : (short)0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(int x)
        {
            return x > 0 ? 1 : x < 0 ? -1 : 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sign(long x)
        {
            return x > 0L ? 1L : x < 0L ? -1L : 0L;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sign(float x)
        {
            return x > 0.0f ? 1.0f : x < 0.0f ? -1.0f : 0.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sign(double x)
        {
            return x > 0.0 ? 1.0 : x < 0.0 ? -1.0 : 0.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max(byte x, byte y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max(sbyte x, sbyte y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max(ushort x, ushort y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max(short x, short y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max(uint x, uint y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int x, int y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max(ulong x, ulong y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max(long x, long y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float x, float y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(double x, double y)
        {
            return x >= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Min(byte x, byte y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min(sbyte x, sbyte y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Min(ushort x, ushort y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Min(short x, short y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Min(uint x, uint y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int x, int y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Min(ulong x, ulong y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Min(long x, long y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float x, float y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(double x, double y)
        {
            return x <= y ? x : y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(byte x, byte min, byte max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(sbyte x, sbyte min, sbyte max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(ushort x, ushort min, ushort max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(short x, short min, short max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(uint x, uint min, uint max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(int x, int min, int max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(ulong x, ulong min, ulong max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(long x, long min, long max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(float x, float min, float max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithin(double x, double min, double max)
        {
            return x >= min && x < max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(byte x, byte min, byte max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(sbyte x, sbyte min, sbyte max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(ushort x, ushort min, ushort max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(short x, short min, short max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(uint x, uint min, uint max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(int x, int min, int max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(ulong x, ulong min, ulong max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(long x, long min, long max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(float x, float min, float max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWithinInclusive(double x, double min, double max)
        {
            return x >= min && x <= max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNearlyEqual(float x, float y, float tolerance = NumberSmall)
        {
            return Abs(x - y) <= tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNearlyEqual(double x, double y, double tolerance = NumberSmall)
        {
            return Abs(x - y) <= tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNearlyZero(float x, float tolerance = NumberSmall)
        {
            return Abs(x) <= tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNearlyZero(double x, double tolerance = NumberSmall)
        {
            return Abs(x) <= tolerance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(byte x)
        {
            return (x & (x - 1)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(sbyte x)
        {
            return (x & (x - 1)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(ushort x)
        {
            return (x & (x - 1)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(short x)
        {
            return (x & (x - 1)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(uint x)
        {
            return (x & (x - 1u)) == 0u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(ulong x)
        {
            return (x & (x - 1UL)) == 0UL;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(long x)
        {
            return (x & (x - 1L)) == 0L;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Max3(byte x, byte y, byte z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Max3(sbyte x, sbyte y, sbyte z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Max3(ushort x, ushort y, ushort z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Max3(short x, short y, short z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Max3(uint x, uint y, uint z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max3(int x, int y, int z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Max3(ulong x, ulong y, ulong z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Max3(long x, long y, long z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max3(float x, float y, float z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max3(double x, double y, double z)
        {
            return Max(Max(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Min3(byte x, byte y, byte z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Min3(sbyte x, sbyte y, sbyte z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Min3(ushort x, ushort y, ushort z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Min3(short x, short y, short z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Min3(uint x, uint y, uint z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min3(int x, int y, int z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Min3(ulong x, ulong y, ulong z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Min3(long x, long y, long z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min3(float x, float y, float z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min3(double x, double y, double z)
        {
            return Min(Min(x, y), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Square(byte x)
        {
            return (byte)(x * x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Square(sbyte x)
        {
            return (sbyte)(x * x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Square(ushort x)
        {
            return (ushort)(x * x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Square(short x)
        {
            return (short)(x * x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Square(uint x)
        {
            return x * x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Square(int x)
        {
            return x * x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Square(ulong x)
        {
            return x * x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Square(long x)
        {
            return x * x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Square(float x)
        {
            return x * x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Square(double x)
        {
            return x * x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Clamp(byte x, byte min, byte max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Clamp(sbyte x, sbyte min, sbyte max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Clamp(ushort x, ushort min, ushort max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Clamp(short x, short min, short max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Clamp(uint x, uint min, uint max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int x, int min, int max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Clamp(ulong x, ulong min, ulong max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Clamp(long x, long min, long max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float x, float min, float max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(double x, double min, double max)
        {
            return x < min ? min : x < max ? x : max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Lerp(byte x, byte y, float t)
        {
            return (byte)Lerp(x, (float)y, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Lerp(sbyte x, sbyte y, float t)
        {
            return (sbyte)Lerp(x, (float)y, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Lerp(ushort x, ushort y, float t)
        {
            return (ushort)Lerp(x, (float)y, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Lerp(short x, short y, float t)
        {
            return (short)Lerp(x, (float)y, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Lerp(uint x, uint y, float t)
        {
            return (uint)Lerp(x, (float)y, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Lerp(int x, int y, float t)
        {
            return (int)Lerp(x, (float)y, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Lerp(ulong x, ulong y, float t)
        {
            return (ulong)Lerp(x, (float)y, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Lerp(long x, long y, float t)
        {
            return (long)Lerp(x, (float)y, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float x, float y, float t)
        {
            return (x * (1.0f - t)) + (y * t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Lerp(double x, double y, double t)
        {
            return (x * (1.0 - t)) + (y * t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep(float t)
        {
            return t <= 0.0f ? 0.0f : t >= 1.0f ? 1.0f : t * t * (3.0f - (2.0f * t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SmoothStep(double t)
        {
            return t <= 0.0 ? 0.0 : t >= 1.0 ? 1.0 : t * t * (3.0 - (2.0 * t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GridSnap(float x, float grid)
        {
            if (grid == 0.0f)
            {
                return x;
            }
            return FloorToFloat((x + (0.5f * grid)) / grid) * grid;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GridSnap(double x, double grid)
        {
            if (grid == 0.0)
            {
                return x;
            }
            return FloorToDouble((x + (0.5 * grid)) / grid) * grid;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RevolutionsToDegrees(float revolutions)
        {
            return revolutions * 360.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RevolutionsToDegrees(double revolutions)
        {
            return revolutions * 360.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RevolutionsToRadians(float revolutions)
        {
            return revolutions * TwoPi;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RevolutionsToRadians(double revolutions)
        {
            return revolutions * TwoPiDouble;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RevolutionsToGradians(float revolutions)
        {
            return revolutions * 400.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RevolutionsToGradians(double revolutions)
        {
            return revolutions * 400.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DegreesToRevolutions(float degrees)
        {
            return degrees / 360.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DegreesToRevolutions(double degrees)
        {
            return degrees / 360.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DegreesToRadians(float degrees)
        {
            return degrees * Pi / 180.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DegreesToRadians(double degrees)
        {
            return degrees * PiDouble / 180.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DegreesToGradians(float degrees)
        {
            return degrees * 10.0f / 9.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DegreesToGradians(double degrees)
        {
            return degrees * 10.0 / 9.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RadiansToRevolutions(float radians)
        {
            return radians / TwoPi;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RadiansToRevolutions(double radians)
        {
            return radians / TwoPiDouble;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RadiansToDegrees(float radians)
        {
            return radians * 180.0f / Pi;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RadiansToDegrees(double radians)
        {
            return radians * 180.0 / PiDouble;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RadiansToGradians(float radians)
        {
            return radians * 2000.0f / Pi;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RadiansToGradians(double radians)
        {
            return radians * 200.0 / PiDouble;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GradiansToRevolutions(float gradians)
        {
            return gradians / 400.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GradiansToRevolutions(double gradians)
        {
            return gradians / 400.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GradiansToDegrees(float gradians)
        {
            return gradians * 9.0f / 10.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GradiansToDegrees(double gradians)
        {
            return gradians * 9.0 / 10.0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GradiansToRadians(float gradians)
        {
            return gradians * Pi / 200.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GradiansToRadians(double gradians)
        {
            return gradians * PiDouble / 200.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LinearToSRgb(float x)
        {
            if (x < 0.0031308f)
            {
                return x * 12.92f;
            }
            return (1.055f * Pow(x, 1.0f / 2.4f)) - 0.055f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SRgbToLinear(float x)
        {
            if (x < 0.04045f)
            {
                return x / 12.92f;
            }
            return Pow((x + 0.055f) / 1.055f, 2.4f);
        }
    }
}
