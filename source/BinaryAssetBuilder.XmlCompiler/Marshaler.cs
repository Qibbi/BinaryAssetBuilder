using Relo;
using SageBinaryData;
using System;
using SMarshal = System.Runtime.InteropServices.Marshal;

public static partial class Marshaler
{
    public const float PI = 3.14159265359f;
    public const float RADS_PER_DEGREE = PI / 180.0f;
    public const float LOGICFRAMES_PER_SECOND = 5;
    public const float MSEC_PER_SECOND = 1000;
    public const float LOGICFRAMES_PER_MSEC_REAL = LOGICFRAMES_PER_SECOND / MSEC_PER_SECOND;
    public const float LOGICFRAMES_PER_SECONDS_REAL = LOGICFRAMES_PER_SECOND;
    public const float SECONDS_PER_LOGICFRAME_REAL = 1.0f / LOGICFRAMES_PER_SECONDS_REAL;

    private static unsafe void Marshal(string text, uint* objT, Tracker state)
    {
        if (text.Length == 0)
        {
            return;
        }
        uint result;
        if (text.Length == 10 && text[0] == '0' && text[1] == 'x')
        {
            result = uint.Parse(text.Substring(2), System.Globalization.NumberStyles.HexNumber);
        }
        else
        {
            result = uint.Parse(text);
        }
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform(&result);
        }
        *objT = result;
    }

    private static unsafe void Marshal(Value value, uint* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(string text, int* objT, Tracker state)
    {
        if (text.Length == 0)
        {
            return;
        }
        int result;
        if (text.Length == 10 && text[0] == '0' && text[1] == 'x')
        {
            result = int.Parse(text.Substring(2), System.Globalization.NumberStyles.HexNumber);
        }
        else
        {
            result = int.Parse(text);
        }
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&result);
        }
        *objT = result;
    }

    private static unsafe void Marshal(Value value, int* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(string text, float* objT, Tracker state)
    {
        float result = float.Parse(text);
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&result);
        }
        *objT = result;
    }

    private static unsafe void Marshal(Value value, float* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(string text, String<sbyte>* objT, Tracker state)
    {
        uint length = (uint)text.Length;
        uint textLength = length;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform(&textLength);
        }
        objT->Length = (int)textLength;
        using Tracker.Context context = state.Push((void**)&objT->Target, 1u, length);
        sbyte* str = objT->Target;
        IntPtr hText = SMarshal.StringToHGlobalAnsi(text);
        sbyte* pText = (sbyte*)hText;
        int c;
        do
        {
            *str = *pText;
            ++pText;
            c = *str;
            ++str;
        }
        while (c != 0);
        SMarshal.FreeHGlobal(hText);
    }

    private static unsafe void Marshal<T>(string text, T* objT, Tracker state) where T : unmanaged, Enum
    {
        T result = (T)Enum.Parse(typeof(T), text, false);
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&result);
        }
        *objT = result;
    }

    private static unsafe void Marshal<T>(Value value, T* objT, Tracker state) where T : unmanaged, Enum
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(Value value, String<sbyte>* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

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

    private static unsafe void Marshal(Node node, RandomVariable* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RandomVariable.Type), nameof(DistributionType.UNIFORM)), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(RandomVariable.Low), null), &objT->Low, state);
        Marshal(node.GetAttributeValue(nameof(RandomVariable.High), null), &objT->High, state);
    }

    private static unsafe void Marshal(Node node, LogicRandomVariable* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (RandomVariable*)objT, state);
    }

    private static unsafe void Marshal(Node node, ClientRandomVariable* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (RandomVariable*)objT, state);
    }

    private static unsafe void Marshal(Node node, ClientRandomVariable** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ClientRandomVariable), 1u);
        Marshal(node, *objT, state);
    }
}
