using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BinaryAssetBuilder.W3XCompiler
{
    [DebuggerDisplay("{Position}: {Values[0]} {BinaryMove}")]
    internal class SrcFrame : ICloneable
    {
        public int Position;
        public List<float> Values = new List<float>();
        public bool BinaryMove;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
