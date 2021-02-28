using System;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Core
{
    public class FastHash
    {
        public static unsafe uint FastHashFn(byte* pBuffer, uint length)
        {
            if (length == 0)
            {
                return 0x1337C0DEu;
            }
            uint hash = length;
            uint extra = length & 3u;
            length >>= 2;
            while (length > 0u)
            {
                hash += *(ushort*)pBuffer;
                hash ^= (*(ushort*)(pBuffer + 2) ^ (hash << 5)) << 11;
                hash += hash >> 11;
                pBuffer += 4;
                --length;
            }
            switch (extra)
            {
                case 1:
                    hash += *pBuffer;
                    hash ^= hash << 10;
                    hash += hash >> 1;
                    break;
                case 2:
                    hash += *(ushort*)pBuffer;
                    hash ^= hash << 11;
                    hash += hash >> 17;
                    break;
                case 3:
                    hash += *(ushort*)pBuffer;
                    hash ^= hash << 16;
                    hash ^= (uint)pBuffer[2] << 18;
                    hash += hash >> 11;
                    break;
            }
            hash ^= hash << 3;
            hash += hash >> 5;
            hash ^= hash << 2;
            hash += hash >> 15;
            hash ^= hash << 10;
            return hash;
        }

        private static unsafe uint FastHashFn(uint hash, byte* pBuffer, uint length)
        {
            if (length <= 0u || (IntPtr)pBuffer == IntPtr.Zero)
            {
                return 0u;
            }
            uint extra = length & 3u;
            length >>= 2;
            while (length > 0u)
            {
                hash += *(ushort*)pBuffer;
                hash ^= (*(ushort*)(pBuffer + 2) ^ (hash << 5)) << 11;
                hash += hash >> 11;
                pBuffer += 4;
                --length;
            }
            switch (extra)
            {
                case 1:
                    hash += *pBuffer;
                    hash ^= hash << 10;
                    hash += hash >> 1;
                    break;
                case 2:
                    hash += *(ushort*)pBuffer;
                    hash ^= hash << 11;
                    hash += hash >> 17;
                    break;
                case 3:
                    hash += *(ushort*)pBuffer;
                    hash ^= hash << 16;
                    hash ^= (uint)pBuffer[2] << 18;
                    hash += hash >> 11;
                    break;
            }
            hash ^= hash << 3;
            hash += hash >> 5;
            hash ^= hash << 2;
            hash += hash >> 15;
            hash ^= hash << 10;
            return hash;
        }

        private static unsafe uint FastHashFnLauncher(uint hash, byte* pBuffer, uint length)
        {
            if (length <= 0u || (IntPtr)pBuffer == IntPtr.Zero)
            {
                return 0u;
            }
            uint extra = length & 3u;
            length >>= 2;
            while (length > 0u)
            {
                hash += *(ushort*)pBuffer;
                hash ^= (*(ushort*)(pBuffer + 2) ^ (hash << 5)) << 11;
                hash += hash >> 11;
                pBuffer += 4;
                --length;
            }
            switch (extra)
            {
                case 1:
                    hash += *pBuffer;
                    hash ^= hash << 10;
                    hash += hash >> 1;
                    break;
                case 2:
                    hash += *(ushort*)pBuffer;
                    hash ^= hash << 11;
                    hash += hash >> 17;
                    break;
                case 3:
                    hash += *(ushort*)pBuffer;
                    hash ^= hash << 16;
                    hash ^= (uint)pBuffer[2] << 18;
                    hash += hash >> 11;
                    break;
            }
            hash ^= hash << 3;
            hash += hash >> 5;
            hash ^= hash << 4;
            hash += hash >> 17;
            hash ^= hash << 25;
            hash += hash >> 6;
            return hash;
        }

        public static unsafe uint GetHashCode(uint hash, byte[] buffer, int length)
        {
            fixed (byte* pBuffer = &buffer[0])
            {
                return FastHashFn(hash, pBuffer, (uint)length);
            }
        }

        public static unsafe uint GetHashCodeLauncher(uint hash, byte[] buffer, int length)
        {
            fixed (byte* pBuffer = &buffer[0])
            {
                if (length <= 0x4000)
                {
                    return FastHashFnLauncher(hash, pBuffer, (uint)length);
                }
                byte* pBuffer2 = pBuffer;
                while (length > 0x4000)
                {
                    hash = FastHashFnLauncher(hash, pBuffer2, 0x4000);
                    pBuffer2 += 0x4000;
                    length -= 0x4000;
                }
                return FastHashFnLauncher(hash, pBuffer2, (uint)length);
            }
        }

        public static unsafe uint GetHashCode(uint hash, byte[] buffer)
        {
            fixed (byte* pBuffer = &buffer[0])
            {
                return FastHashFn(hash, pBuffer, (uint)buffer.Length);
            }
        }

        public static unsafe uint GetHashCodeLauncher(uint hash, byte[] buffer)
        {
            int length = buffer.Length;
            fixed (byte* pBuffer = &buffer[0])
            {
                if (length <= 0x4000)
                {
                    return FastHashFnLauncher(hash, pBuffer, (uint)length);
                }
                byte* pBuffer2 = pBuffer;
                while (length > 0x4000)
                {
                    hash = FastHashFnLauncher(hash, pBuffer2, 0x4000);
                    pBuffer2 += 0x4000;
                    length -= 0x4000;
                }
                return FastHashFnLauncher(hash, pBuffer2, (uint)length);
            }
        }

        public static unsafe uint GetHashCode(byte[] buffer, int length)
        {
            fixed (byte* pBuffer = &buffer[0])
            {
                return FastHashFn((uint)buffer.Length, pBuffer, (uint)length);
            }
        }

        public static unsafe uint GetHashCodeLauncher(byte[] buffer, int length)
        {
            uint hash = (uint)buffer.Length;
            fixed (byte* pBuffer = &buffer[0])
            {
                if (length <= 0x4000)
                {
                    return FastHashFnLauncher(hash, pBuffer, (uint)length);
                }
                byte* pBuffer2 = pBuffer;
                while (length > 0x4000)
                {
                    hash = FastHashFnLauncher(hash, pBuffer2, 0x4000);
                    pBuffer2 += 0x4000;
                    length -= 0x4000;
                }
                return FastHashFnLauncher(hash, pBuffer2, (uint)length);
            }
        }

        public static unsafe uint GetHashCode(byte[] buffer)
        {
            fixed (byte* pBuffer = &buffer[0])
            {
                return FastHashFn((uint)buffer.Length, pBuffer, (uint)buffer.Length);
            }
        }

        public static unsafe uint GetHashCodeLauncher(byte[] buffer)
        {
            uint hash = (uint)buffer.Length;
            int length = buffer.Length;
            fixed (byte* pBuffer = &buffer[0])
            {
                if (length <= 0x4000)
                {
                    return FastHashFnLauncher(hash, pBuffer, (uint)length);
                }
                byte* pBuffer2 = pBuffer;
                while (length > 0x4000)
                {
                    hash = FastHashFnLauncher(hash, pBuffer2, 0x4000);
                    pBuffer2 += 0x4000;
                    length -= 0x4000;
                }
                return FastHashFnLauncher(hash, pBuffer2, (uint)length);
            }
        }

        public static unsafe uint GetHashCode(uint hash, string text)
        {
            IntPtr hglobalAnsi = Marshal.StringToHGlobalAnsi(text);
            hash = FastHashFn(hash, (byte*)hglobalAnsi.ToPointer(), (uint)text.Length);
            Marshal.FreeHGlobal(hglobalAnsi);
            return hash;
        }

        public static unsafe uint GetHashCode(string text)
        {
            IntPtr hglobalAnsi = Marshal.StringToHGlobalAnsi(text);
            uint hash = FastHashFn((uint)text.Length, (byte*)hglobalAnsi.ToPointer(), (uint)text.Length);
            Marshal.FreeHGlobal(hglobalAnsi);
            return hash;
        }
    }
}
