public class Crc
{
    private static uint[] _crcTable = GetCrcTable();

    public uint Hash { get; private set; }

    public Crc()
    {
        Hash = 0u;
    }

    private static uint[] GetCrcTable()
    {
        uint[] result = new uint[256];
        const uint polynormal = 0xEDB88320u;
        for (uint idx = 0u; idx < 256u; ++idx)
        {
            uint remainder = idx;
            for (uint bit = 8; bit > 0; --bit)
            {
                if ((remainder & 1) != 0)
                {
                    remainder = (remainder >> 1) ^ polynormal;
                }
                else
                {
                    remainder >>= 1;
                }
            }
            result[idx] = remainder;
        }
        return result;
    }

    public static uint GetCrc(byte[] data, uint crc)
    {
        crc = ~crc;
        for (int idx = 0; idx < data.Length; ++idx)
        {
            crc = _crcTable[(data[idx] ^ crc) & 0x000000FFu] ^ (crc >> 8);
        }
        return ~crc;
    }

    public void Compute(byte[] data)
    {
        if (data is null)
        {
            return;
        }
        for (int idx = 0; idx < data.Length; ++idx)
        {
            Hash = data[idx] + (Hash >> 31) + (2 * Hash);
        }
    }
}
