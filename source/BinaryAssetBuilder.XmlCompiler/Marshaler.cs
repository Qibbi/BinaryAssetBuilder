using Relo;
using SageBinaryData;

public static class Marshaler
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
        node.Release();
    }

    private static unsafe void Marshal(Node node, BaseInheritableAsset* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(string text, AssetReference<LogicCommand>* reference, Tracker tracker)
    {
        int index = text.IndexOf('\\');
        if (index == -1)
        {
            return;
        }
        uint value = uint.Parse(text.Substring(index + 1));
        tracker.AddReference((void*)reference, value);
    }

    public static unsafe void Marshal(Value value, AssetReference<LogicCommand>* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Node node, AssetReference<LogicCommand>* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    public static unsafe void Marshal(List list, RList<AssetReference<LogicCommand>>* target, Tracker tracker)
    {
        if (list is null)
        {
            return;
        }
        uint count = (uint)list.GetCount();
        uint listCount = count;
        if (tracker.IsBigEndian)
        {
            tracker.ByteSwap32(&listCount);
        }
        target->Count = listCount;
        if (count != 0u)
        {
            tracker.Push((void**)&target->Target, 4u, count);
            for (uint idx = 0; idx < count; ++idx)
            {
                Marshal(list.GetNextNode(), &target->Target[idx], tracker);
            }
            tracker.Pop();
        }
    }

    public static unsafe void Marshal(Node node, LogicCommandSet* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes("Cmd"), &objT->Cmd, state);
    }
}
