using BinaryAssetBuilder.W3XCompiler;
using Relo;
using SageBinaryData;
using System;
using System.Runtime.InteropServices;

internal class CompressedAdaptiveDelta
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Frame
    {
        public unsafe fixed sbyte Values[17];
    }

    private static readonly float[] _filterTable = new[]
    {
        1.0e-08f,  1.0e-07f, 1.0e-06f, 1.0e-05f,
        0.0001f, 0.001f, 0.01f, 0.1f,
        1.0f, 10.0f, 100.0f, 1000.0f,
        10000.0f, 100000.0f, 1000000.0f, 10000000.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f, 0.0f
    };

    private AnimationChannelType _type; // 0
    private ushort _pivot; // 4
    private float _scale; // 8
    private System.Collections.Generic.List<float> _values = new System.Collections.Generic.List<float>(); // 12-28
    private int _numBytes; // 28
    private System.Collections.Generic.List<Frame> _frames = new System.Collections.Generic.List<Frame>(); // 32 - 48
    private int _count; // 48

    static CompressedAdaptiveDelta()
    {
        for (int idx = 0; idx < 240; ++idx)
        {
            float num = idx;
            num = (float)(num / 240.0);
            _filterTable[idx + 16] = (float)(1.0 - Math.Sin(90.0 * num * Marshaler.PI / 180.0));
        }
    }

    private unsafe float CompressFrame(Frame* dest, sbyte filter, float[] values, float* curPrevValue, bool* excessError, float maxError)
    {
        dest->Values[0] = filter;
        int maxScale = _numBytes != 4 ? 128 : 8;
        float currentValue = values[0];
        float comulativeDelta = 0.0f;
        float filterScale = _filterTable[filter * 4] * _scale;
        if (maxScale == 128)
        {
            filterScale /= 16.0f;
        }
        float num5 = 1.0f / filterScale;
        for (int idx = 1; idx <= 16; ++idx)
        {
            int currentDelta = (int)(float)Math.Floor((Math.Abs((double)(values[idx] - currentValue)) * num5) + 0.5);
            if ((double)values[idx] < currentValue)
            {
                currentDelta = -currentDelta;
                if (currentDelta < -maxScale)
                {
                    currentDelta = -maxScale;
                }
            }
            else if (currentDelta >= maxScale)
            {
                currentDelta = maxScale - 1;
            }
            float delta = (float)Math.Abs((double)(currentValue + (currentDelta * filterScale) - values[idx]));
            dest->Values[idx] = (sbyte)currentDelta;
            currentValue += currentDelta * filterScale;
            comulativeDelta += delta;
            if ((IntPtr)excessError != IntPtr.Zero && delta > maxError)
            {
                *excessError = true;
            }
        }
        if (curPrevValue != null)
        {
            *curPrevValue = currentValue;
        }
        return comulativeDelta;
    }

    public static unsafe CompressedAdaptiveDelta Compress(AnimationChannelBase* srcChannel, SrcFrame srcFrame, ref W3DAnimation.CompressionSetting settings)
    {
        if (srcFrame.Values.Count < 2)
        {
            return null;
        }
        CompressedAdaptiveDelta result = new CompressedAdaptiveDelta
        {
            _type = srcChannel->Type,
            _pivot = srcChannel->Pivot
        };
        float maxDelta = 0.0f;
        int valuesCount = srcFrame.Values.Count;
        for (int idx = 0; idx < srcFrame.Values.Count - 1; ++idx)
        {
            int vCount = srcFrame.Values[idx].V.Count;
            for (int idy = 0; idx < vCount; ++idy)
            {
                float delta = Math.Abs(srcFrame.Values[idx].V[idy] - srcFrame.Values[idx + 1].V[idy]);
                if (delta > maxDelta)
                {
                    maxDelta = delta;
                }
            }
        }
        result._scale = maxDelta / 7.0f;
        result._count = valuesCount;
        for (int idx = 0; idx < result._count; ++idx)
        {
            result._values.Add(srcFrame.Values[idx].V[)
        }
        bool flag;
        for (int idx = 0; idx < 2; ++idx)
        {
            result._numBytes = (idx * 4) + 4;
            int num2 = 1;
            for (int idy = srcFrame.Values.Count; idy > 0; --idy)
            {
                for (int idz = 0; idz < valuesCount; ++idz)
                {
                    for (int idw = 0; idw < 16; ++idw)
                    {
                        int num6 = valuesCount;
                        if (num2 + idw >= num6)
                        {

                        }
                    }
                }
            }
        }

        float[] values = new float[17];

        int selectedFilter = -1;
        float delta = float.MaxValue;
        for (int filter = 0; filter < 256; ++filter)
        {
            Frame frame;
            float currentDelta = result.CompressFrame(&frame, (sbyte)filter, values, null, null, 0.0f);
            if (currentDelta < delta)
            {
                selectedFilter = filter;
                delta = currentDelta;
            }
        }
        Frame newFrame = new Frame();
        result.CompressFrame(newFrame, selectedFilter, values, values[pos], &flag, settings.MaxAdaptiveDeltaError);
        result._frames.Add(newFrame);
    }

    public int EstimateSize()
    {

    }

    public unsafe void WriteOut(Tracker state, AnimationChannelDelta** objT)
    {

    }
}
