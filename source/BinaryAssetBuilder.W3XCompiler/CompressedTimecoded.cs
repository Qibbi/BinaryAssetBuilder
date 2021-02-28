using BinaryAssetBuilder.W3XCompiler;
using Relo;
using SageBinaryData;
using System;

internal class CompressedTimecoded
{
    private AnimationChannelType _type;
    private short _pivot;
    private System.Collections.Generic.List<SrcFrame> _frames = new System.Collections.Generic.List<SrcFrame>();

    private static int FindUselessPacketScalar(System.Collections.Generic.List<SrcFrame> anim, float delta)
    {
        if (anim.Count < 2)
        {
            return -1;
        }
        if (anim.Count == 2)
        {
            if (anim[1].BinaryMove)
            {
                return -1;
            }
            else
            {
                if (delta >= 0.0)
                {
                    delta *= anim[1].Position - anim[0].Position;
                    for (int idx = 0; idx < anim[0].Values.Count; ++idx)
                    {
                        if (Math.Abs(anim[1].Values[idx] - anim[0].Values[idx]) > delta) // BUG in TW's dll: it uses anim[1] - anim[1]
                        {
                            return -1;
                        }
                    }
                }
            }
            return 1;
        }
        int uselessIdx = 0;
        float maxDelta = float.MaxValue;
        for (int idx = 0; idx < anim.Count - 2; ++idx)
        {
            if (anim[idx].BinaryMove && anim[idx + 2].BinaryMove)
            {
                continue;
            }
            SrcFrame start = anim[idx];
            SrcFrame middle = anim[idx + 1];
            SrcFrame end = anim[idx + 2];
            float ratio = (middle.Position - start.Position) / (end.Position - start.Position);
            float maxTestDelta = 0.0f;
            for (int idy = 0; idy < start.Values.Count; ++idy)
            {
                float testDelta = Math.Abs(start.Values[idy] + (ratio * (end.Values[idy] - start.Values[idy])) - end.Values[idy]);
                if (testDelta > maxTestDelta)
                {
                    maxTestDelta = testDelta;
                }
            }
            if (maxTestDelta >= delta)
            {
                if (maxTestDelta < maxDelta)
                {
                    uselessIdx = idx + 1;
                    maxDelta = maxTestDelta;
                }
            }
            else
            {
                return idx + 1;
            }
        }
        return delta >= 0.0 || uselessIdx == 0 ? -1 : uselessIdx;
    }

    private static int FindUselessPacketQuaternion(System.Collections.Generic.List<SrcFrame> anim, float delta)
    {
        if (anim.Count < 2)
        {
            return -1;
        }
        if (anim.Count == 2)
        {
            if (anim[1].BinaryMove)
            {
                return -1;
            }
            else
            {
                if (delta >= 0.0)
                {
                    WWQuat start = WWQuat.GetQ(anim[0].Values);
                    WWQuat end = WWQuat.GetQ(anim[1].Values);
                    WWQuat test = start.Inverse() * end;
                    if (Math.Abs(test.W) < 1.0 && Math.Acos(Math.Abs(test.W)) * 2.0 > delta)
                    {
                        return -1;
                    }
                }
            }
            return 1;
        }
        int uselessIdx = 0;
        float maxDelta = float.MaxValue;
        for (int idx = 0; idx < anim.Count - 2; ++idx)
        {
            if (anim[idx].BinaryMove && anim[idx + 2].BinaryMove)
            {
                continue;
            }
            SrcFrame start = anim[idx];
            SrcFrame middle = anim[idx + 1];
            SrcFrame end = anim[idx + 2];
            WWQuat qStart = WWQuat.GetQ(start.Values);
            WWQuat qMiddle = WWQuat.GetQ(middle.Values);
            WWQuat qEnd = WWQuat.GetQ(end.Values);
            float ratio = (middle.Position - start.Position) / (end.Position - start.Position);
            WWQuat qTest = WWQuat.SLerp(qStart, qEnd, ratio);
            WWQuat qDelta = qMiddle.Inverse() * qTest;
            if (Math.Abs(qDelta.W) < 1.0f)
            {
                float testDelta = (float)Math.Acos(Math.Abs(qDelta.W)) * 2.0f;
                if (testDelta > delta)
                {
                    if (testDelta < maxDelta)
                    {
                        uselessIdx = idx + 1;
                        maxDelta = testDelta;
                    }
                }
            }
            else
            {
                return idx + 1;
            }
        }
        return delta >= 0.0 || uselessIdx == 0 ? -1 : uselessIdx;
    }

    public static unsafe CompressedTimecoded Compress(AnimationChannelBase* srcChannel,
                                                      System.Collections.Generic.List<SrcFrame> srcFrames,
                                                      ref W3DAnimation.CompressionSetting settings)
    {
        CompressedTimecoded result = new CompressedTimecoded
        {
            _type = srcChannel->Type,
            _pivot = (short)srcChannel->Pivot,
            _frames = srcFrames
        };
        uint reductionLength = (uint)(srcFrames.Count * (double)settings.ForceReductionRate);
        if (reductionLength < 1u)
        {
            reductionLength = 1u;
        }
        if (result._type == AnimationChannelType.Orientation)
        {
            float delta = settings.MaxRotationError;
            while (srcFrames.Count > reductionLength || delta >= 0.0)
            {
                int uselessPacket = FindUselessPacketQuaternion(result._frames, delta);
                if (uselessPacket < 0)
                {
                    break;
                }
                else
                {
                    srcFrames.RemoveAt(uselessPacket);
                }
            }
        }
        else
        {
            float delta = result._type != AnimationChannelType.Visibility ? settings.MaxTranslationError : settings.MaxVisibilityError;
            while (srcFrames.Count > reductionLength || delta >= 0.0)
            {
                int uselessPacket = FindUselessPacketScalar(result._frames, delta);
                if (uselessPacket < 0)
                {
                    if (delta >= 0.0)
                    {
                        delta = -1.0f;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {

                    srcFrames.RemoveAt(uselessPacket);
                }
            }
        }
        return result;
    }

    public int EstimateSize()
    {
        if (_frames.Count == 0)
        {
            return 0;
        }
        return _frames.Count * ((_frames.Count * 4) + 2);
    }

    public unsafe void WriteOut(Tracker state, AnimationChannelTimecoded** objT)
    {
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AnimationChannelTimecoded), 1u);
        uint typeId = 0x60D8CF69;
        state.InplaceEndianToPlatform(&typeId);
        AnimationChannelTimecoded* result = *objT;
        result->Base.TypeId = typeId;
        uint type = (uint)_type;
        state.InplaceEndianToPlatform(&type);
        result->Base.Type = (AnimationChannelType)type;
        System.Collections.Generic.List<SrcFrame> frames = _frames;
        uint numFrames = (uint)frames.Count;
        state.InplaceEndianToPlatform(&numFrames);
        result->Base.NumFrames = numFrames;
        uint vectorLen;
        if (frames.Count == 0)
        {
            vectorLen = 1u;
        }
        else
        {
            vectorLen = (uint)frames[0].Values.Count;
        }
        uint vectorSize = vectorLen;
        state.InplaceEndianToPlatform(&vectorLen);
        result->Base.VectorLen = vectorLen;
        ushort pivot = (ushort)_pivot;
        state.InplaceEndianToPlatform(&pivot);
        result->Base.Pivot = pivot;
        uint numValues = numFrames;
        state.InplaceEndianToPlatform(&numValues);
        result->FrameAndBinaryFlag.Count = numValues;
        result->Values.Count = numValues;
        if (frames.Count != 0)
        {
            state.Push((void**)&result->Values.Items, sizeof(float), numFrames);
            state.Pop();
            state.Push((void**)&result->FrameAndBinaryFlag.Items, sizeof(ushort), numFrames);
            state.Pop();
            ushort* pFrameAndBinaryFlag = result->FrameAndBinaryFlag.Items;
            float* pValues = result->Values.Items;
            foreach (SrcFrame frame in frames)
            {
                ushort frameAndBinaryFlag = (ushort)frame.Position;
                if (frame.BinaryMove)
                {
                    frameAndBinaryFlag |= 0x8000;
                }
                state.InplaceEndianToPlatform(&frameAndBinaryFlag);
                *pFrameAndBinaryFlag = frameAndBinaryFlag;
                ++pFrameAndBinaryFlag;
                for (int idx = 0; idx < vectorSize; ++idx)
                {
                    float value = frame.Values[idx];
                    state.InplaceEndianToPlatform((uint*)&value);
                    *pValues = value;
                    ++pValues;
                }
            }
        }
    }
}
