namespace EA
{
    internal static class Endian
    {
        public static ushort BigEndian(ushort x)
        {
            return (ushort)(((x & 0xFF) << 8) | ((x >> 8) & 0xFF));
        }

        public static short BigEndian(short x)
        {
            return (short)(((x & 0xFF) << 8) | ((x >> 8) & 0xFF));
        }

        public static uint BigEndian(uint x)
        {
            return (uint)((((int)x & 0xFF) << 24) | (((int)x & 0xFF00) << 8) | ((int)(x >> 8) & 0xFF00) | ((int)(x >> 24) & 0xFF));
        }

        public static int BigEndian(int x)
        {
            return ((x & 0xFF) << 24) | ((x & 0xFF00) << 8) | ((x >> 8) & 0xFF00) | ((x >> 24) & 0xFF);
        }
    }
}
