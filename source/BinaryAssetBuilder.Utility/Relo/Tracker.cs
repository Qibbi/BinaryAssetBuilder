using System;
using System.Runtime.InteropServices;

namespace Relo
{
    public class Tracker : IDisposable
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
                BinaryAssetBuilder.Native.MsVcRt.MemSet(Data, 0, new BinaryAssetBuilder.Native.SizeT(size));
                Console.WriteLine($"Allocated block at 0x{Data:x8}, size: {size}");
            }
        }

        public class Context : IDisposable
        {
            private Tracker _parent;

            internal Context(Tracker parent)
            {
                _parent = parent;
            }

            public void Dispose()
            {
                if (_parent != null)
                {
                    _parent.Pop();
                    _parent = null;
                }
            }
        }

        private uint _instanceBufferSize;
        private readonly System.Collections.Generic.List<uint> _stack;
        private readonly System.Collections.Generic.List<Block> _blocks;
        private readonly System.Collections.Generic.List<Bookmark> _relocations;
        private readonly System.Collections.Generic.List<Bookmark> _imports;

        public bool IsBigEndian { get; private set; }

        private Tracker()
        {
            _stack = new System.Collections.Generic.List<uint>();
            _blocks = new System.Collections.Generic.List<Block>();
            _relocations = new System.Collections.Generic.List<Bookmark>();
            _imports = new System.Collections.Generic.List<Bookmark>();
        }

        public unsafe Tracker(void** rootPointer, uint size, bool isBigEndian) : this()
        {
            uint index = Allocate(1u, size);
            _stack.Add(index);
            *(IntPtr*)rootPointer = _blocks[(int)index].Data;
        }

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

        public unsafe void InplaceEndianToPlatform(uint* value)
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

        public unsafe Context Push(void** pointerLocation, uint objectSize, uint objectCount)
        {
            uint index = _stack[^1];
            uint newIndex = Allocate(objectCount, objectSize);
            _stack.Add(newIndex);
            if ((IntPtr)pointerLocation == IntPtr.Zero)
            {
                return null;
            }
            Bookmark bookmark = new Bookmark
            {
                Index = index,
                From = (uint)((byte*)pointerLocation - (byte*)_blocks[(int)index].Data),
                To = newIndex
            };
            *(IntPtr*)pointerLocation = _blocks[(int)newIndex].Data;
            _relocations.Add(bookmark);
            Console.WriteLine($"Pushing new objects, ptr: 0x{(IntPtr)(pointerLocation):x8}, target: 0x{(IntPtr)(*pointerLocation):x8}");
            return new Context(this);
        }

        public void Pop()
        {
            _stack.RemoveAt(_stack.Count - 1);
        }

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
            fixed (byte* instanceBuffer = &chunk.InstanceBuffer[0])
            {
                byte* instanceBufferPosition = instanceBuffer;
                int blockCount = _blocks.Count;
                uint[] bookmarks = new uint[blockCount];
                int idx = 0;
                foreach (Block block in _blocks)
                {
                    BinaryAssetBuilder.Native.MsVcRt.MemCpy((IntPtr)instanceBufferPosition, block.Data, new BinaryAssetBuilder.Native.SizeT(block.Size));
                    bookmarks[idx++] = (uint)(instanceBufferPosition - instanceBuffer);
                    instanceBufferPosition += block.Size;
                }
                if (relocationBufferSize > 0)
                {
                    _relocations.Sort(new Comparison<Bookmark>((x, y) => BookmarkCompare(x, y) ? -1 : 1));
                    fixed (byte* pRelocationBuffer = &chunk.RelocationBuffer[0])
                    {
                        uint* relocationBuffer = (uint*)pRelocationBuffer;
                        foreach (Bookmark relocation in _relocations)
                        {
                            uint from = bookmarks[relocation.Index] + relocation.From;
                            *relocationBuffer = from;
                            if (IsBigEndian)
                            {
                                InplaceEndianToPlatform(relocationBuffer);
                            }
                            uint to = bookmarks[(int)relocation.To];
                            if (IsBigEndian)
                            {
                                InplaceEndianToPlatform(&to);
                            }
                            *(uint*)(instanceBuffer + from) = to;
                            relocationBuffer++;
                        }
                        *relocationBuffer = uint.MaxValue;
                    }
                }
                if (importsBufferSize > 0u)
                {
                    _imports.Sort(new Comparison<Bookmark>((x, y) => BookmarkCompare(x, y) ? -1 : 1));
                    fixed (byte* pImportsBuffer = &chunk.ImportsBuffer[0])
                    {
                        uint* importsBuffer = (uint*)pImportsBuffer;
                        foreach (Bookmark import in _imports)
                        {
                            uint from = bookmarks[import.Index] + import.From;
                            *importsBuffer = from;
                            if (IsBigEndian)
                            {
                                InplaceEndianToPlatform(importsBuffer);
                            }
                            uint to = import.To;
                            if (IsBigEndian)
                            {
                                InplaceEndianToPlatform(&to);
                            }
                            *(uint*)(instanceBuffer + from) = to;
                            importsBuffer++;
                        }
                        *importsBuffer = uint.MaxValue;
                    }
                }
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

        public void Dispose()
        {
            while (_blocks.Count != 0)
            {
                Console.WriteLine($"Free'd block at 0x{_blocks[^1].Data:x8}");
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
