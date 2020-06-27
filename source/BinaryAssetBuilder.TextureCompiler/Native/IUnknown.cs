using System;

namespace Native
{
    public interface IUnknown
    {
        Result QueryInterface(ref Guid guid, out IntPtr comObject);

        int AddReference();

        int Release();
    }
}
