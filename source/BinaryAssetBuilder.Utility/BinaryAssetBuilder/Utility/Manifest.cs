using System;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Utility
{
    public class Manifest : IDisposable
    {
        private Asset[] _assets;

        public Asset[] Assets => _assets;

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe bool Load(string fileName, string[] pathSearchPaths)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
