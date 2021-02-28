using Relo;
using System;
using System.IO;

public static partial class Marshaler
{
    public static unsafe void Marshal(string text, DataBlob* objT, Tracker state)
    {
        if (!File.Exists(text))
        {
            return;
        }
        using Stream stream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read);
        int fileSize = (int)stream.Length;
        uint size = (uint)fileSize;
        state.InplaceEndianToPlatform(&size);
        objT->Size = size;
        using Tracker.Context context = state.Push(&objT->Data, 1u, (uint)fileSize);
        Span<byte> span = new Span<byte>(objT->Data, fileSize);
        if (stream.Read(span) != fileSize)
        {
            objT->Size = 0u;
        }
    }

    public static unsafe void Marshal(Value value, DataBlob* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }
}
