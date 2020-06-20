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
        public unsafe fixed byte Values[17];
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
    private short _pivot; // 4
    private float _scale; // 8
    private System.Collections.Generic.List<float> _values = new System.Collections.Generic.List<float>(); // 12-28
    private int _numBits; // 28
    private System.Collections.Generic.List<Frame> _frames = new System.Collections.Generic.List<Frame>(); // 32 - 48
    private int _vectorLen; // 48

    static CompressedAdaptiveDelta()
    {
        for (int idx = 0; idx < 240; ++idx)
        {
            float num = idx;
            num = (float)(num / 240.0);
            _filterTable[idx + 16] = (float)(1.0 - Math.Sin(90.0 * num * Marshaler.PI / 180.0));
        }
    }

    private unsafe float CompressFrame(Frame* dest, int filter, float[] values, float* curPrevValue, bool* excessError, float maxError)
    {
        dest->Values[0] = (byte)filter;
        int maxScale = _numBits != 4 ? 128 : 8;
        float currentValue = values[0];
        float comulativeDelta = 0.0f;
        float filterScale = _filterTable[filter] * _scale;
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
            dest->Values[idx] = (byte)currentDelta;
            currentValue += currentDelta * filterScale;
            comulativeDelta += delta;
            if (excessError != null && delta > maxError)
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

    public static unsafe CompressedAdaptiveDelta Compress(AnimationChannelBase* srcChannel,
                                                          System.Collections.Generic.List<SrcFrame> srcFrames,
                                                          ref W3DAnimation.CompressionSetting settings)
    {
        if (srcFrames.Count < 2)
        {
            return null;
        }
        CompressedAdaptiveDelta compressed = new CompressedAdaptiveDelta
        {
            _type = srcChannel->Type,
            _pivot = (short)srcChannel->Pivot
        };
        float maxDelta = 0.0f;
        SrcFrame lastFrame = srcFrames[^1];
        foreach (SrcFrame srcFrame in srcFrames)
        {
            if (srcFrame != lastFrame)
            {
                for (int pos = 0; pos < srcFrame.Values.Count; ++pos)
                {
                    float delta = (float)Math.Abs((double)(srcFrame.Values[pos] - lastFrame.Values[pos]));
                    if (delta > maxDelta)
                    {
                        maxDelta = delta;
                    }
                }
            }
        }
        compressed._scale = maxDelta / 7.0f;
        int frameSize = srcFrames[0].Values.Count;
        compressed._vectorLen = frameSize;
        for (int pos = 0; pos < frameSize; ++pos)
        {
            compressed._values.Add(srcFrames[0].Values[pos]);
        }
        bool excessDelta = false;
        for (int idx = 0; idx < 2; ++idx)
        {
            compressed._numBits = (idx * 4) + 4;
            compressed._frames.Clear();
            float[] frameValues = new float[4];
            for (int pos = 0; pos < frameSize; ++pos)
            {
                frameValues[pos] = compressed._values[pos];
            }
            excessDelta = false;
            int num2 = 1;
            int num3 = (srcFrames.Count + 15) / 16;
            while (true)
            {
                int num5 = num3--;
                if (num5 != 0)
                {
                    for (int pos = 0; pos < frameSize; ++pos)
                    {
                        float[] array = new float[17];
                        array[0] = frameValues[pos];
                        for (int idy = 0; idy < 16; ++idy)
                        {
                            int num6 = srcFrames.Count;
                            if (num2 + idy >= num6)
                            {
                                array[idy + 1] = array[idy];
                            }
                            else
                            {
                                array[idy + 1] = srcFrames[num2 + idy].Values[pos];
                            }
                        }
                        int selectedFilter = -1;
                        float blockDelta = float.MaxValue;
                        for (int idf = 0; idf < 256; ++idf)
                        {
                            Frame frame;
                            float delta = compressed.CompressFrame(&frame, idf, array, null, null, 0.0f);
                            if ((double)delta < blockDelta)
                            {
                                selectedFilter = idf;
                                blockDelta = delta;
                            }
                        }
                        Frame finalFrame;
                        fixed (float* pFrameValues = &frameValues[0])
                        {
                            compressed.CompressFrame(&finalFrame, selectedFilter, array, &pFrameValues[pos], &excessDelta, settings.MaxAdaptiveDeltaError);
                            compressed._frames.Add(finalFrame);
                        }
                    }
                    num2 += 16;
                }
                else
                {
                    break;
                }
            }
            if (!excessDelta)
            {
                break;
            }
        }
        if (excessDelta)
        {
            return null;
        }
        return compressed;
    }

    public int EstimateSize()
    {
        int frameSize = _values.Count * (_numBits / 8);
        int numValues = _values.Count;
        int numFrames = _frames.Count;
        return (numValues * 4) + (frameSize * numFrames);
    }

    public unsafe void WriteOut(Tracker state, AnimationChannelDelta** objT)
    {
        using (Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AnimationChannelDelta), 1u))
        {

        }
    }
}
