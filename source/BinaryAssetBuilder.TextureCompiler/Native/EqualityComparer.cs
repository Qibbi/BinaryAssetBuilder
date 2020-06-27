using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Native
{
    internal static class EqualityComparer
    {
        internal class IntPtrComparer : EqualityComparer<IntPtr>
        {
            public override bool Equals([AllowNull] IntPtr x, [AllowNull] IntPtr y)
            {
                return x == y;
            }

            public override int GetHashCode([DisallowNull] IntPtr obj)
            {
                return obj.GetHashCode();
            }
        }

        public static readonly IEqualityComparer<IntPtr> DefaultIntPtr = new IntPtrComparer();
    }
}
