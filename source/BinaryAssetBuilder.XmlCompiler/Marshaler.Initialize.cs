using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    private static unsafe void Initialize(RGBColor* objT, Tracker state, float r, float g, float b)
    {
        float value = r;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&value);
        }
        objT->R = value;
        value = g;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&value);
        }
        objT->G = value;
        value = b;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&value);
        }
        objT->B = value;
    }

    private static unsafe void Initialize(RandomVariable* objT, Tracker state, float low, float high, DistributionType type)
    {
        float fValue = low;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&fValue);
        }
        objT->Low = fValue;
        fValue = high;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&fValue);
        }
        objT->High = fValue;
        DistributionType tValue = type;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&tValue);
        }
        objT->Type = tValue;
    }
}
