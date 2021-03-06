using BinaryAssetBuilder.W3XCompiler;
using Relo;
using SageBinaryData;
using System;

internal class CompressedAdaptiveDelta
{
    public class Frame
    {
        public sbyte[] Values = new sbyte[17];
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

    private AnimationChannelType _type;
    private short _pivot;
    private float _scale;
    private readonly System.Collections.Generic.List<float> _init = new System.Collections.Generic.List<float>();
    private int _numBits;
    private readonly System.Collections.Generic.List<Frame> _compressedValues = new System.Collections.Generic.List<Frame>();
    private int _vectorLen;

    static CompressedAdaptiveDelta()
    {
        for (int idx = 0; idx < 240; ++idx)
        {
            float num = idx;
            num = (float)(num / 240.0);
            _filterTable[idx + 16] = (float)(1.0 - Math.Sin(90.0 * num * Marshaler.PI / 180.0));
        }
    }

    private unsafe float CompressFrame(Frame dest, int filter, float[] values, float* curPrevValue, bool* excessError, float maxError)
    {
        dest.Values[0] = (sbyte)filter;
        int maxScale = _numBits != 4 ? 128 : 8;
        float currentValue = values[0];
        float comulativeDelta = 0.0f;
        float filterScale = _filterTable[filter] * _scale;
        if (maxScale == 128)
        {
            filterScale /= 16.0f;
        }
        float oneOverScale = 1.0f / filterScale;
        for (int idx = 1; idx <= 16; ++idx)
        {
            int currentDelta = (int)(float)Math.Floor((Math.Abs((double)(values[idx] - currentValue)) * oneOverScale) + 0.5);
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
            dest.Values[idx] = (sbyte)currentDelta;
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
        CompressedAdaptiveDelta result = new CompressedAdaptiveDelta
        {
            _type = srcChannel->Type,
            _pivot = (short)srcChannel->Pivot
        };
        float maxDelta = 0.0f;
        for (int idx = 0; idx < srcFrames.Count - 1; ++idx)
        {
            SrcFrame frame = srcFrames[idx];
            SrcFrame nextFrame = srcFrames[idx + 1];
            for (int pos = 0; pos < frame.Values.Count; ++pos)
            {
                float delta = Math.Abs(nextFrame.Values[pos] - frame.Values[pos]);
                if (delta > maxDelta)
                {
                    maxDelta = delta;
                }
            }
        }
        result._scale = maxDelta / 7.0f;
        int frameSize = srcFrames[0].Values.Count;
        result._vectorLen = frameSize;
        for (int pos = 0; pos < frameSize; ++pos)
        {
            result._init.Add(srcFrames[0].Values[pos]);
        }
        bool excessDelta = false;
        for (int idx = 0; idx < 2; ++idx)
        {
            result._numBits = (idx * 4) + 4;
            result._compressedValues.Clear();
            float[] animationState = new float[4];
            for (int pos = 0; pos < frameSize; ++pos)
            {
                animationState[pos] = result._init[pos];
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
                        array[0] = animationState[pos];
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
                            Frame frame = new Frame();
                            float delta = result.CompressFrame(frame, idf, array, null, null, 0.0f);
                            if ((double)delta < blockDelta)
                            {
                                selectedFilter = idf;
                                blockDelta = delta;
                            }
                        }
                        Frame finalFrame = new Frame();
                        fixed (float* pFrameValues = &animationState[0])
                        {
                            result.CompressFrame(finalFrame, selectedFilter, array, &pFrameValues[pos], &excessDelta, settings.MaxAdaptiveDeltaError);
                            result._compressedValues.Add(finalFrame);
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
        return result;
    }

    public int EstimateSize()
    {
        int frameSize = _init.Count * (_numBits / 8);
        int numValues = _init.Count;
        int numFrames = _compressedValues.Count;
        return (numValues * 4) + (frameSize * numFrames);
    }

    public unsafe void WriteOut(Tracker state, AnimationChannelDelta** objT)
    {
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AnimationChannelDelta), 1u);
        uint typeId = 0x77F97305u;
        state.InplaceEndianToPlatform(&typeId);
        AnimationChannelDelta* result = *objT;
        result->Base.TypeId = typeId;
        uint type = (uint)_type;
        state.InplaceEndianToPlatform(&type);
        result->Base.Type = (AnimationChannelType)type;
        System.Collections.Generic.List<Frame> frames = _compressedValues;
        uint numFrames = (uint)(frames.Count / _vectorLen * 16);
        state.InplaceEndianToPlatform(&numFrames);
        result->Base.NumFrames = numFrames;
        uint vectorLen = (uint)_vectorLen;
        state.InplaceEndianToPlatform(&vectorLen);
        result->Base.VectorLen = vectorLen;
        ushort pivot = (ushort)_pivot;
        state.InplaceEndianToPlatform(&pivot);
        result->Base.Pivot = pivot;
        float scale = _scale;
        state.InplaceEndianToPlatform((uint*)&scale);
        result->Scale = scale;
        uint numBits = (uint)_numBits;
        state.InplaceEndianToPlatform(&numBits);
        result->NumBits = numBits;
        uint initCount = (uint)_init.Count;
        state.InplaceEndianToPlatform(&initCount);
        result->Init.Count = initCount;
        int initLength = _init.Count;
        using (Tracker.Context contextInit = state.Push((void**)&result->Init.Items, sizeof(float), (uint)initLength))
        {
            for (int idx = 0; idx < initLength; ++idx)
            {
                float init = _init[idx];
                state.InplaceEndianToPlatform((uint*)&init);
                result->Init.Items[idx] = init;
            }
        }
        int blockSize = _numBits != 4 ? 17 : 9;
        System.Collections.Generic.List<Frame> compressedValues = _compressedValues;
        uint bufferSize = (uint)(_compressedValues.Count * blockSize);
        uint resultBufferSize = bufferSize;
        state.InplaceEndianToPlatform(&resultBufferSize);
        result->CompressedValues.Count = resultBufferSize;
        using Tracker.Context contextValues = state.Push((void**)&result->CompressedValues.Items, sizeof(sbyte), bufferSize);
        byte* values = result->CompressedValues.Items;
        foreach (Frame frame in compressedValues)
        {
            *values = (byte)frame.Values[0];
            ++values;
            if (_numBits != 4)
            {
                fixed (sbyte* pFrame = &frame.Values[0])
                {
                    Native.MsVcRt.MemCpy((IntPtr)values, (IntPtr)pFrame + 1, new Native.SizeT(16));
                    values += 16;
                }
            }
            else
            {
                for (int idx = 0; idx < 16; idx += 2)
                {
                    *values = (byte)((frame.Values[idx + 1] & 0xF) | (frame.Values[idx + 2] << 4));
                    ++values;
                }
            }
        }
    }
}
