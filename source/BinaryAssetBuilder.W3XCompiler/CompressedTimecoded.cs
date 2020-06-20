using BinaryAssetBuilder.W3XCompiler;
using Relo;
using SageBinaryData;
using System;

internal class CompressedTimecoded
{
    public static unsafe CompressedTimecoded Compress(AnimationChannelBase* srcChannel,
                                                      System.Collections.Generic.List<SrcFrame> srcFrames,
                                                      ref W3DAnimation.CompressionSetting settings)
    {
        throw new NotImplementedException();
    }

    public int EstimateSize()
    {
        throw new NotImplementedException();
    }

    public unsafe void WriteOut(Tracker state, AnimationChannelTimecoded** objT)
    {

    }
}
