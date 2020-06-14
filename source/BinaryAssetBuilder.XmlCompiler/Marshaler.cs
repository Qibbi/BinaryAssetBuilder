using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public const float PI = 3.14159265359f;
    public const float RADS_PER_DEGREE = PI / 180.0f;
    public const float LOGICFRAMES_PER_SECOND = 5;
    public const float MSEC_PER_SECOND = 1000;
    public const float LOGICFRAMES_PER_MSEC_REAL = LOGICFRAMES_PER_SECOND / MSEC_PER_SECOND;
    public const float LOGICFRAMES_PER_SECONDS_REAL = LOGICFRAMES_PER_SECOND;
    public const float SECONDS_PER_LOGICFRAME_REAL = 1.0f / LOGICFRAMES_PER_SECONDS_REAL;

    private static unsafe void Marshal(Node node, BaseAssetType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    private static unsafe void Marshal(Node node, BaseInheritableAsset* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
