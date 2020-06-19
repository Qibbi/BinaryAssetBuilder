using System.Collections.Generic;

namespace BinaryAssetBuilder.W3XCompiler
{
    internal class SrcFrame
    {
        public class Value
        {
            public List<float> V = new List<float>();
            public bool BinaryMove;
        }

        public List<Value> Values { get; } = new List<Value>();
    }
}
