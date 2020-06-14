using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Relo
{
    public class Tracker
    {
        internal class Bookmark
        {
            public uint Index;
            public uint From;
            public uint To;
        }

        internal class Block
        {
            public IntPtr Data;
            public uint Size;

            public Block(uint size)
            {
                Data = Marshal.AllocHGlobal((int)size);
                Size = size;
                BinaryAssetBuilder.Native.MsVcRt.ClearMemory(Data, 0, (int)size);
            }
        }

        private static Tracker _nullTracker;
        private static bool _hasNullTracker;

        private uint _instanceBufferSize;
        private readonly List<uint> _stack;
        private readonly List<Block> _blocks;
        private readonly List<Bookmark> _relocations;
        private readonly List<Bookmark> _imports;

        public bool IsBigEndian { get; private set; }

        private Tracker()
        {
            _stack = new List<uint>();
            _blocks = new List<Block>();
            _relocations = new List<Bookmark>();
            _imports = new List<Bookmark>();
        }

        public static unsafe Tracker Create<T>(T** rootPointer, [MarshalAs(UnmanagedType.U1)] bool isBigEndian) where T : unmanaged
        {
            Tracker result = new Tracker
            {
                IsBigEndian = isBigEndian
            };
            uint index = result.Allocate(1u, (uint)sizeof(T));
            result._stack.Add(index);
            *(IntPtr*)rootPointer = result._blocks[(int)index].Data;
            return result;
        }

        internal static unsafe Tracker NullTracker()
        {
            if (!_hasNullTracker)
            {
                _hasNullTracker = true;
                _nullTracker = new Tracker();
            }
            return _nullTracker;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        internal static unsafe bool BookmarkCompare(Bookmark x, Bookmark y)
        {
            return x.Index < y.Index || (x.Index <= y.Index && x.To < y.To);
        }

        private unsafe uint Allocate(uint count, uint elementSize)
        {
            uint blockSize = (uint)((((int)count * (int)elementSize) + 3) & -4);
            Block block = new Block(blockSize);
            _blocks.Add(block);
            _instanceBufferSize += blockSize;
            return (uint)(_blocks.Count - 1);
        }

        public unsafe void ByteSwap32(uint* value)
        {
            byte* pValue = (byte*)value;
            uint result;
            byte* pResult = (byte*)&result;
            *pResult = pValue[3];
            pResult[1] = pValue[2];
            pResult[2] = pValue[1];
            pResult[3] = *pValue;
            *value = result;
        }

        public unsafe void* Push(void** pointerLocation, uint objectSize, uint objectCount)
        {
            uint index = _stack[^1];
            uint newIndex = Allocate(objectCount, objectSize);
            _stack.Add(newIndex);
            if ((IntPtr)pointerLocation == IntPtr.Zero)
            {
                return (void*)IntPtr.Zero;
            }
            Bookmark bookmark = new Bookmark
            {
                Index = index,
                From = (uint)((byte*)pointerLocation - (byte*)_blocks[(int)index].Data),
                To = newIndex
            };
            *(IntPtr*)pointerLocation = _blocks[(int)newIndex].Data;
            _relocations.Add(bookmark);
            return *pointerLocation;
        }

        public void Pop()
        {
            _stack.RemoveAt(_stack.Count - 1);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe bool MakeRelocatable(Chunk chunk)
        {
            uint importsBufferSize = 0;
            if (_imports.Count > 0)
            {
                importsBufferSize = ((uint)_imports.Count + 1u) * 4u;
            }
            uint relocationBufferSize = 0;
            if (_relocations.Count > 0)
            {
                relocationBufferSize = ((uint)_relocations.Count + 1u) * 4u;
            }
            if (!chunk.Allocate(_instanceBufferSize, relocationBufferSize, importsBufferSize))
            {
                return false;
            }
            byte* instanceBuffer = (byte*)chunk.InstanceBuffer;
            byte* instanceBufferPosition = instanceBuffer;
            int blockCount = _blocks.Count;
            uint* bookmarks = (uint*)Marshal.AllocHGlobal(blockCount > 0x3FFFFFFF ? int.MaxValue : blockCount * 4);
            int idx = 0;
            foreach (Block block in _blocks)
            {
                BinaryAssetBuilder.Native.MsVcRt.MemCpy((IntPtr)instanceBufferPosition, block.Data, new BinaryAssetBuilder.Native.SizeT(block.Size));
                bookmarks[idx++] = (uint)(instanceBufferPosition - instanceBuffer);
                instanceBufferPosition += block.Size;
            }
            if (relocationBufferSize > 0)
            {
                uint* relocationBuffer = (uint*)chunk.RelocationBuffer;
                _relocations.Sort(new Comparison<Bookmark>((x, y) => BookmarkCompare(x, y) ? -1 : 1));
                foreach (Bookmark relocation in _relocations)
                {
                    uint from = bookmarks[relocation.Index] + relocation.From;
                    *relocationBuffer = from;
                    if (IsBigEndian)
                    {
                        ByteSwap32(relocationBuffer);
                    }
                    uint to = bookmarks[(int)relocation.To];
                    if (IsBigEndian)
                    {
                        ByteSwap32(&to);
                    }
                    *(uint*)(instanceBuffer + from) = to;
                    relocationBuffer++;
                }
                *relocationBuffer = uint.MaxValue;
            }
            if (importsBufferSize > 0u)
            {
                uint* importsBuffer = (uint*)chunk.ImportsBuffer;
                _imports.Sort(new Comparison<Bookmark>((x, y) => BookmarkCompare(x, y) ? -1 : 1));
                foreach (Bookmark import in _imports)
                {
                    uint from = bookmarks[import.Index] + (import.From * 4);
                    *importsBuffer = from;
                    if (IsBigEndian)
                    {
                        ByteSwap32(importsBuffer);
                    }
                    uint to = import.To;
                    if (IsBigEndian)
                    {
                        ByteSwap32(&to);
                    }
                    *(uint*)(instanceBuffer + from) = to;
                    importsBuffer++;
                }
                *importsBuffer = uint.MaxValue;
            }
            return true;
        }

        public unsafe void AddReference(void* location, uint value)
        {
            uint index = _stack[^1];
            Bookmark bookmark = new Bookmark
            {
                Index = index,
                From = (uint)((byte*)location - (byte*)_blocks[(int)index].Data),
                To = value
            };
            *(uint*)location = value;
            _imports.Add(bookmark);
        }

        public void Dispse()
        {
            while (_blocks.Count != 0)
            {
                Marshal.FreeHGlobal(_blocks[^1].Data);
                _blocks.RemoveAt(_blocks.Count - 1);
            }
            _imports.Clear();
            _relocations.Clear();
            _blocks.Clear();
            _stack.Clear();
        }
    }
}
