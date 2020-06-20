using System;
using System.Collections.Generic;

namespace BinaryAssetBuilder.W3XCompiler
{
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
