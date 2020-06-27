using BinaryAssetBuilder.Native;
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct NVVector<T> : IDisposable where T : unmanaged, IDisposable
{
    public unsafe T* Buffer;
    public uint Size;
    public uint BufferSize;

    public unsafe T* First => Size > 0u ? &(Buffer[0]) : null;
    public unsafe T* Last => Size > 0u ? &(Buffer[Size - 1]) : null;
    public unsafe T* this[uint index]
    {
        get
        {
            if (index < Size)
            {
                return &(Buffer[index]);
            }
            return null;
        }
    }

    public unsafe NVVector(NVVector<T>* x)
    {
        Buffer = null;
        Size = 0;
        BufferSize = 0;
        Copy(x->Buffer, x->Size);
    }

    public unsafe NVVector(T* ptr, uint size)
    {
        Buffer = null;
        Size = 0;
        BufferSize = 0;
        Copy(ptr, size);
    }

    private unsafe void Allocate(uint size)
    {
        uint oldBufferSize = BufferSize;
        BufferSize = size;
        if (BufferSize == 0u)
        {
            if (Buffer != null)
            {
                Marshal.FreeHGlobal((IntPtr)Buffer);
                Buffer = null;
            }
        }
        else
        {
            if (Buffer != null)
            {
                IntPtr oldBuffer = (IntPtr)Buffer;
                Buffer = (T*)Marshal.AllocHGlobal((int)(size * sizeof(T)));
                MsVcRt.MemCpy((IntPtr)Buffer, oldBuffer, new SizeT(oldBufferSize * sizeof(T)));
                Marshal.FreeHGlobal(oldBuffer);
            }
            else
            {
                Buffer = (T*)Marshal.AllocHGlobal((int)(size * sizeof(T)));
            }
        }
    }

    private unsafe void Copy(T* ptr, uint num)
    {
        Resize(num);
        for (int idx = 0; idx < Size; ++idx)
        {
            Buffer[idx] = ptr[idx];
        }
    }

    public unsafe void Add(T* val)
    {
        uint newSize = Size + 1;
        Resize(newSize);
        Buffer[newSize - 1] = *val;
    }

    public unsafe void Remove()
    {
        Resize(Size - 1);
    }

    public unsafe void Resize(uint size)
    {
        uint oldSize = Size;
        Size = size;
        for (uint idx = 0u; idx < oldSize; ++idx)
        {
            Buffer[idx].Dispose();
        }
        if (Size == 0)
        {
        }
        else if (Size <= BufferSize && Size > (BufferSize >> 1))
        {
        }
        else
        {
            uint newBufferSize;
            if (BufferSize == 0)
            {
                newBufferSize = Size;
            }
            else
            {
                newBufferSize = Size + (Size >> 2);
            }
            Allocate(newBufferSize);
        }
        for (uint idx = oldSize; idx < size; ++idx)
        {
            Buffer[idx] = new T();
        }
    }

    public unsafe void Resize(uint size, T* elem)
    {
        uint oldSize = Size;
        Size = size;
        for (uint idx = 0u; idx < oldSize; ++idx)
        {
            Buffer[idx].Dispose();
        }
        if (Size == 0)
        {
        }
        else if (Size <= BufferSize && Size > (BufferSize >> 1))
        {
        }
        else
        {
            uint newBufferSize;
            if (BufferSize == 0)
            {
                newBufferSize = Size;
            }
            else
            {
                newBufferSize = Size + (Size >> 2);
            }
            Allocate(newBufferSize);
        }
        for (uint idx = oldSize; idx < size; ++idx)
        {
            Buffer[idx] = *elem;
        }
    }

    public void Clear()
    {
        Resize(0u);
    }

    public void Shrink()
    {
        if (Size < BufferSize)
        {
            Allocate(Size);
        }
    }

    public void Reserve(uint desiredSize)
    {
        if (desiredSize > BufferSize)
        {
            Allocate(desiredSize);
        }
    }

    public void Realloc(uint size)
    {
        Resize(size);
    }

    public void Dispose()
    {
        Clear();
        Allocate(0);
    }
}
