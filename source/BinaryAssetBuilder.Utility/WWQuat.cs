using Mathematics;
using System.Collections.Generic;

public class WWQuat
{
    public float X;
    public float Y;
    public float Z;
    public float W;

    public static WWQuat operator *(in WWQuat x, in WWQuat y)
    {
        float xX = x.X;
        float xY = x.Y;
        float xZ = x.Z;
        float xW = x.W;
        float yX = y.X;
        float yY = y.Y;
        float yZ = y.Z;
        float yW = y.W;
        return new WWQuat
        {
            X = (xW * yX) + (xX * yW) + (xZ * yY) - (xY * yZ),
            Y = (xW * yY) + (xY * yW) + (xX * yZ) - (xZ * yX),
            Z = (xW * yZ) + (xZ * yW) + (xY * yX) - (xX * yY),
            W = (xW * yW) - (xX * yX) - (xY * yY) - (xZ * yZ)
        };
    }

    public static WWQuat GetQ(List<float> source)
    {
        return new WWQuat { X = source[0], Y = source[1], Z = source[2], W = source[3] };
    }

    public static float Dot(in WWQuat x, in WWQuat y)
    {
        return (x.X * y.X) + (x.Y * y.Y) + (x.Z * y.Z) + (x.W * y.W);
    }

    public static WWQuat SLerp(in WWQuat x, in WWQuat y, float t)
    {
        float opposite;
        float inverse;
        float dot = Dot(x, y);
        if (MathUtil.IsNearlyZero(dot, 1.0f - MathUtil.NumberSmall))
        {
            float acos = MathUtil.Acos(MathUtil.Abs(dot));
            float oneOverSin = 1.0f / MathUtil.Sin(acos);
            opposite = MathUtil.Sin(t * acos) * oneOverSin * MathUtil.Sign(dot);
            inverse = MathUtil.Sin((1.0f - t) * acos) * oneOverSin;
        }
        else
        {
            opposite = t * MathUtil.Sign(dot);
            inverse = 1.0f - t;
        }
        return new WWQuat
        {
            X = (inverse * x.X) + (opposite * y.X),
            Y = (inverse * x.Y) + (opposite * y.Y),
            Z = (inverse * x.Z) + (opposite * y.Z),
            W = (inverse * x.W) + (opposite * y.W)
        };
    }

    public float GetLengthSquared()
    {
        return (X * X) + (Y * Y) + (Z * Z) + (W * W);
    }

    public WWQuat Inverse()
    {
        float length = GetLengthSquared();
        if (!MathUtil.IsNearlyZero(length))
        {
            float oneOverLength = 1.0f / length;
            return new WWQuat { X = -X * oneOverLength, Y = -Y * oneOverLength, Z = -Z * oneOverLength, W = W * oneOverLength };
        }
        return null;
    }
}
