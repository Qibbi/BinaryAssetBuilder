using BinaryAssetBuilder.Core.Hashing;
using Relo;
using SageBinaryData;
using System;
using AnsiString = Relo.String<sbyte>;
using SMarshal = System.Runtime.InteropServices.Marshal;
using WideString = Relo.String<char>;

public static partial class Marshaler
{
    public const float PI = 3.14159265359f;
    public const float RADS_PER_DEGREE = PI / 180.0f;
    public const float LOGICFRAMES_PER_SECOND = 5;
    public const float MSEC_PER_SECOND = 1000;
    public const float LOGICFRAMES_PER_MSEC_REAL = LOGICFRAMES_PER_SECOND / MSEC_PER_SECOND;
    public const float LOGICFRAMES_PER_SECONDS_REAL = LOGICFRAMES_PER_SECOND;
    public const float SECONDS_PER_LOGICFRAME_REAL = 1.0f / LOGICFRAMES_PER_SECONDS_REAL;

    private static unsafe void Marshal(string text, SageBool* objT, Tracker state)
    {
        bool result = bool.Parse(text);
        objT->Value = result;
    }

    public static unsafe void Marshal(Value value, SageBool* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Node node, SageBool* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, byte* objT, Tracker state)
    {
        *objT = byte.Parse(text);
    }

    private static unsafe void Marshal(Value value, byte* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(string text, sbyte* objT, Tracker state)
    {
        *objT = sbyte.Parse(text);
    }

    private static unsafe void Marshal(Value value, sbyte* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(string text, ushort* objT, Tracker state)
    {
        ushort result = ushort.Parse(text);
        state.InplaceEndianToPlatform(&result);
        *objT = result;
    }

    private static unsafe void Marshal(Value value, ushort* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(Node node, ushort* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

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
        else if (text.Contains('.')) // This is a fix because some default to 0.0 in the schema
        {
            result = (uint)float.Parse(text);
        }
        else
        {
            result = uint.Parse(text);
        }
        state.InplaceEndianToPlatform(&result);
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
        state.InplaceEndianToPlatform((uint*)&result);
        *objT = result;
    }

    public static unsafe void Marshal(Value value, int* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Node node, int* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(Value value, int** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(int), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal(Node node, int** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, List<int>* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        uint objectCount = (uint)tokens.Length;
        uint num = objectCount;
        state.InplaceEndianToPlatform(&num);
        objT->Count = num;
        using Tracker.Context context = state.Push((void**)&objT->Items, (uint)sizeof(int), objectCount);
        for (int idx = 0; idx < objectCount; ++idx)
        {
            Marshal(tokens[idx], &objT->Items[idx], state);
        }
    }

    private static unsafe void Marshal(Value value, List<int>* objT, Tracker state)
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
        state.InplaceEndianToPlatform((uint*)&result);
        *objT = result;
    }

    public static unsafe void Marshal(Value value, float* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Node node, float* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(Value value, float** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(float), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal(Node node, float** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, Percentage* objT, Tracker state)
    {
        int index = text.IndexOf('%');
        if (index >= 0)
        {
            text = text.Substring(0, index);
        }
        float result = float.Parse(text);
        result *= 0.01f;
        state.InplaceEndianToPlatform((uint*)&result);
        objT->Value = result;
    }

    private static unsafe void Marshal(Value value, Percentage* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(Value value, Percentage** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Percentage), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal(Node node, Percentage** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, List<Percentage>* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        uint objectCount = (uint)tokens.Length;
        uint num = objectCount;
        state.InplaceEndianToPlatform(&num);
        objT->Count = num;
        using Tracker.Context context = state.Push((void**)&objT->Items, (uint)sizeof(Percentage), objectCount);
        for (int idx = 0; idx < objectCount; ++idx)
        {
            Marshal(tokens[idx], &objT->Items[idx], state);
        }
    }

    private static unsafe void Marshal(Value value, List<Percentage>* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private const int _angleMaxPostfixes = 2;
    private static readonly char[] _anglePostFixes = new[] { 'r', 'd' };
    private static readonly float[] _angleMultipliers = new[] { 1.0f, PI / 180.0f };

    private static unsafe void Marshal(string text, Angle* objT, Tracker state)
    {
        float multiplier = 1.0f;
        int index = -1;
        for (int idx = 0; idx < _angleMaxPostfixes; ++idx)
        {
            index = text.IndexOf(_anglePostFixes[idx]);
            if (index >= 0)
            {
                multiplier = _angleMultipliers[idx];
                break;
            }
        }
        if (index >= 0)
        {
            text = text.Substring(0, index);
        }
        float result = float.Parse(text);
        result *= multiplier;
        state.InplaceEndianToPlatform((uint*)&result);
        objT->Value = result;
    }

    private static unsafe void Marshal(Value value, Angle* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(Value value, Angle** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Angle), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal(Node node, Angle** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private const int _timeMaxPostfixes = 2;
    private static readonly string[] _timePostFixes = new[] { "ms", "s" };
    private static readonly float[] _timeMultipliers = new[] { 0.001f, 1.0f };

    private static unsafe void Marshal(string text, Time* objT, Tracker state)
    {
        float multiplier = 1.0f;
        int index = -1;
        for (int idx = 0; idx < _timeMaxPostfixes; ++idx)
        {
            index = text.IndexOf(_timePostFixes[idx]);
            if (index >= 0)
            {
                multiplier = _timeMultipliers[idx];
                break;
            }
        }
        if (index >= 0)
        {
            text = text.Substring(0, index);
        }
        float result = float.Parse(text);
        result *= multiplier;
        state.InplaceEndianToPlatform((uint*)&result);
        objT->Value = result;
    }

    private static unsafe void Marshal(Value value, Time* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(Value value, Time** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Time), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal(Node node, Time** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, Duration* objT, Tracker state)
    {
        uint result = uint.Parse(text);
        result = (uint)Math.Ceiling(result * LOGICFRAMES_PER_MSEC_REAL);
        state.InplaceEndianToPlatform(&result);
        objT->Value = result;
    }

    private static unsafe void Marshal(Value value, Duration* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(string text, Velocity* objT, Tracker state)
    {
        float result = float.Parse(text);
        result *= SECONDS_PER_LOGICFRAME_REAL;
        state.InplaceEndianToPlatform((uint*)&result);
        objT->Value = result;
    }

    private static unsafe void Marshal(Value value, Velocity* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal<T>(string text, T* objT, Tracker state) where T : unmanaged, Enum
    {
        if (Enum.TryParse(text, false, out T value))
        {
            T result = (T)Enum.Parse(typeof(T), text, false);
            state.InplaceEndianToPlatform((uint*)&result);
            *objT = result;
        }
    }

    private static unsafe void Marshal<T>(Value value, T* objT, Tracker state) where T : unmanaged, Enum
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal<T>(Node node, T* objT, Tracker state) where T : unmanaged, Enum
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal<T>(Value value, T** objT, Tracker state) where T : unmanaged, Enum
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(T), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal<T>(Node node, T** objT, Tracker state) where T : unmanaged, Enum
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, AnsiString* objT, Tracker state)
    {
        uint length = (uint)text.Length;
        uint textLength = length;
        state.InplaceEndianToPlatform(&textLength);
        objT->Length = (int)textLength;
        using Tracker.Context context = state.Push((void**)&objT->Target, 1u, length + 1);
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

    private static unsafe void Marshal(Value value, AnsiString* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Node node, AnsiString* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, AnsiString** objT, Tracker state)
    {
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AnsiString), 1u);
        Marshal(text, *objT, state);
    }

    private static unsafe void Marshal(Value value, AnsiString** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(Node node, AnsiString** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, List<AnsiString>* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        uint objectCount = (uint)tokens.Length;
        uint num = objectCount;
        state.InplaceEndianToPlatform(&num);
        objT->Count = num;
        using Tracker.Context context = state.Push((void**)&objT->Items, (uint)sizeof(AnsiString), objectCount);
        for (int idx = 0; idx < objectCount; ++idx)
        {
            Marshal(tokens[idx], &objT->Items[idx], state);
        }
    }

    private static unsafe void Marshal(Value value, List<AnsiString>* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(string text, List<AnsiString>** objT, Tracker state)
    {
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(List<AnsiString>), 1u);
        Marshal(text, *objT, state);
    }

    private static unsafe void Marshal(Value value, List<AnsiString>** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(Node node, List<AnsiString>** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, WideString* objT, Tracker state)
    {
        uint length = (uint)text.Length;
        uint textLength = length;
        state.InplaceEndianToPlatform(&textLength);
        objT->Length = (int)textLength;
        using Tracker.Context context = state.Push((void**)&objT->Target, 2u, length + 2);
        char* str = objT->Target;
        IntPtr hText = SMarshal.StringToHGlobalUni(text);
        char* pText = (char*)hText;
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

    private static unsafe void Marshal(Value value, WideString* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(string text, WideString** objT, Tracker state)
    {
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(WideString), 1u);
        Marshal(text, *objT, state);
    }

    private static unsafe void Marshal(Value value, WideString** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal(Node node, WideString** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(Node node, RGBColor* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RGBColor.R), null), &objT->R, state);
        Marshal(node.GetAttributeValue(nameof(RGBColor.G), null), &objT->G, state);
        Marshal(node.GetAttributeValue(nameof(RGBColor.B), null), &objT->B, state);
    }

    private static unsafe void Marshal(Node node, RGBAColor* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RGBAColor.A), null), &objT->A, state);
        Marshal(node, (RGBColor*)objT, state);
    }

    private static unsafe void Marshal(Node node, Color3f* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Color3f.r), null), &objT->r, state);
        Marshal(node.GetAttributeValue(nameof(Color3f.g), null), &objT->g, state);
        Marshal(node.GetAttributeValue(nameof(Color3f.b), null), &objT->b, state);
    }

    public static unsafe void Marshal(Node node, Color3f** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Color3f), 1u);
        Marshal(node, *objT, state);
    }

    private static unsafe void Marshal(Node node, Color4f* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Color4f.r), null), &objT->r, state);
        Marshal(node.GetAttributeValue(nameof(Color4f.g), null), &objT->g, state);
        Marshal(node.GetAttributeValue(nameof(Color4f.b), null), &objT->b, state);
        Marshal(node.GetAttributeValue(nameof(Color4f.a), null), &objT->a, state);
    }

    private static unsafe void Marshal(Node node, RealRange* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RealRange.Low), null), &objT->Low, state);
        Marshal(node.GetAttributeValue(nameof(RealRange.High), null), &objT->High, state);
    }

    private static unsafe void Marshal(Node node, RealRange** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(RealRange), 1u);
        Marshal(node, *objT, state);
    }

    private static unsafe void Marshal(Node node, IntRange* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(IntRange.Low), null), &objT->Low, state);
        Marshal(node.GetAttributeValue(nameof(IntRange.High), null), &objT->High, state);
    }

    private static unsafe void Marshal(Node node, IntRange** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(IntRange), 1u);
        Marshal(node, *objT, state);
    }

    private static unsafe void Marshal(Node node, Coord2D* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Coord2D.x), "0.0"), &objT->x, state);
        Marshal(node.GetAttributeValue(nameof(Coord2D.y), "0.0"), &objT->y, state);
    }

    private static unsafe void Marshal(Node node, ICoord2D* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ICoord2D.x), "0.0"), &objT->x, state);
        Marshal(node.GetAttributeValue(nameof(ICoord2D.y), "0.0"), &objT->y, state);
    }

    private static unsafe void Marshal(Node node, Coord2D** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Coord2D), 1u);
        Marshal(node, *objT, state);
    }

    private static unsafe void Marshal(Node node, Coord3D* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Coord3D.x), "0.0"), &objT->x, state);
        Marshal(node.GetAttributeValue(nameof(Coord3D.y), "0.0"), &objT->y, state);
        Marshal(node.GetAttributeValue(nameof(Coord3D.z), "0.0"), &objT->z, state);
    }

    private static unsafe void Marshal(Node node, Coord3D** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Coord3D), 1u);
        Marshal(node, *objT, state);
    }

    private static unsafe void Marshal(Node node, Color* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Color.R), "0"), &objT->R, state);
        Marshal(node.GetAttributeValue(nameof(Color.G), "0"), &objT->G, state);
        Marshal(node.GetAttributeValue(nameof(Color.B), "0"), &objT->B, state);
        Marshal(node.GetAttributeValue(nameof(Color.A), "255"), &objT->A, state);
    }

    private static unsafe void Marshal(Node node, Color** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Color), 1u);
        Marshal(node, *objT, state);
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

    public static unsafe void Marshal(Node node, ReplaceTexture* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ReplaceTexture.Original), null), &objT->Original, state);
        Marshal(node.GetAttributeValue(nameof(ReplaceTexture.New), null), &objT->New, state);
    }

    private static unsafe void Marshal<T>(string text, TypedAssetId<T>* objT, Tracker state) where T : unmanaged
    {
        HashProvider.RecordHash("POID", text);
        uint id = FastHash.GetHashCode(text.ToLower());
        state.InplaceEndianToPlatform(&id);
        objT->InstanceId = id;
    }

    private static unsafe void Marshal<T>(Value value, TypedAssetId<T>* objT, Tracker state) where T : unmanaged
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    private static unsafe void Marshal<T>(Node node, TypedAssetId<T>* objT, Tracker state) where T : unmanaged
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal<T>(Value value, TypedAssetId<T>** objT, Tracker state) where T : unmanaged
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(TypedAssetId<T>), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal<T>(Node node, TypedAssetId<T>** objT, Tracker state) where T : unmanaged
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(string text, StringHash* objT, Tracker state)
    {
        HashProvider.RecordHash("STRINGHASH", text);
        uint id = FastHash.GetHashCode(text);
        state.InplaceEndianToPlatform(&id);
        objT->InstanceId = id;
    }

    private static unsafe void Marshal(Value value, StringHash* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Node node, StringHash* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    private static unsafe void Marshal(Value value, StringHash** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(StringHash), 1u);
        Marshal(value, *objT, state);
    }

    private static unsafe void Marshal(Node node, StringHash** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
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
}
