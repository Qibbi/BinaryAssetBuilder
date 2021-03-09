using System.Runtime.InteropServices;

namespace Relo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct String<T> where T : unmanaged
    {
        public int Length;
        public unsafe T* Target;

        public unsafe override string ToString()
        {
            if (typeof(T) == typeof(sbyte))
            {
                return new string((sbyte*)Target, 0, Length);
            }
            return base.ToString();
        }
    }
}
