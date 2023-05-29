using System;

namespace Relo
{
    public class Chunk
    {
        public byte[] InstanceBuffer;
        public byte[] RelocationBuffer;
        public byte[] ImportsBuffer;

        public Chunk()
        {
            InstanceBuffer = Array.Empty<byte>();
            RelocationBuffer = Array.Empty<byte>();
            ImportsBuffer = Array.Empty<byte>();
        }

        internal bool Allocate(uint instanceBufferSize, uint relocationBufferSize, uint importsBufferSize)
        {
            InstanceBuffer = new byte[instanceBufferSize];
            if (relocationBufferSize > 0)
            {
                RelocationBuffer = new byte[relocationBufferSize];
            }
            if (importsBufferSize > 0)
            {
                ImportsBuffer = new byte[importsBufferSize];
            }
            return true;
        }
    }
}
