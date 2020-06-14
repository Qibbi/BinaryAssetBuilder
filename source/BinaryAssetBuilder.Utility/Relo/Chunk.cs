namespace Relo
{
    public class Chunk
    {
        public byte[] InstanceBuffer;
        public byte[] RelocationBuffer;
        public byte[] ImportsBuffer;

        public Chunk()
        {
            InstanceBuffer = new byte[0];
            RelocationBuffer = new byte[0];
            ImportsBuffer = new byte[0];
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
