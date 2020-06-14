using System;
using System.Runtime.InteropServices;

namespace Relo
{
    public class Chunk : IDisposable
    {
        public IntPtr InstanceBuffer;
        public int InstanceBufferSize;
        public IntPtr RelocationBuffer;
        public int RelocationBufferSize;
        public IntPtr ImportsBuffer;
        public int ImportsBufferSize;

        public Chunk()
        {
            InstanceBuffer = IntPtr.Zero;
            InstanceBufferSize = 0;
            RelocationBuffer = IntPtr.Zero;
            RelocationBufferSize = 0;
            ImportsBuffer = IntPtr.Zero;
            ImportsBufferSize = 0;
        }

        internal bool Allocate(uint instanceBufferSize, uint relocationBufferSize, uint importsBufferSize)
        {
            InstanceBufferSize = (int)instanceBufferSize;
            RelocationBufferSize = (int)relocationBufferSize;
            ImportsBufferSize = (int)importsBufferSize;
            if (RelocationBufferSize > 0)
            {
                RelocationBuffer = Marshal.AllocHGlobal(RelocationBufferSize);
            }
            if (ImportsBufferSize > 0)
            {
                ImportsBuffer = Marshal.AllocHGlobal(ImportsBuffer);
            }
            InstanceBuffer = Marshal.AllocHGlobal(InstanceBufferSize);
            return true;
        }

        internal void Free()
        {
            if (RelocationBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(RelocationBuffer);
                RelocationBuffer = IntPtr.Zero;
            }
            if (ImportsBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(ImportsBuffer);
                ImportsBuffer = IntPtr.Zero;
            }
            if (InstanceBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(InstanceBuffer);
                InstanceBuffer = IntPtr.Zero;
            }
        }
        public void Dispose()
        {
            Free();
        }
    }
}
