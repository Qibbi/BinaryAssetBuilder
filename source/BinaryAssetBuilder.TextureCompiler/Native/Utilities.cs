using System;
using System.Reflection;

namespace Native
{
    public static class Utilities
    {
        public static unsafe int SizeOf<T>() where T : unmanaged
        {
            return sizeof(T);
        }

        public static Guid GetGuidFromType(Type type)
        {
            return type.GetTypeInfo().GUID;
        }
    }
}