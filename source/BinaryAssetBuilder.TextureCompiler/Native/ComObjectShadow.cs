using System;
using System.Runtime.InteropServices;

namespace Native
{
    internal abstract class AComObjectShadow : ACppObjectShadow
    {
        internal class ComObjectVtbl : CppObjectVtbl
        {
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate int QueryInterfaceDelegate(IntPtr thisObject, IntPtr guid, out IntPtr output);

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate int AddRefDelegate(IntPtr thisObject);

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate int ReleaseDelegate(IntPtr thisObject);

            public unsafe ComObjectVtbl(int numberOfCallbackMethods) : base(numberOfCallbackMethods + 3)
            {
                AddMethod(new QueryInterfaceDelegate(QueryInterfaceImpl));
                AddMethod(new AddRefDelegate(AddRefImpl));
                AddMethod(new ReleaseDelegate(ReleaseImpl));
            }

            protected static unsafe int QueryInterfaceImpl(IntPtr thisObject, IntPtr guid, out IntPtr output)
            {
                AComObjectShadow shadow = ToShadow<AComObjectShadow>(thisObject);
                if (shadow is null)
                {
                    output = IntPtr.Zero;
                    return Result.NoInterface.Code;
                }
                return shadow.QueryInterfaceImpl(ref *(Guid*)guid, out output);
            }

            protected static int AddRefImpl(IntPtr thisObject)
            {
                AComObjectShadow shadow = ToShadow<AComObjectShadow>(thisObject);
                if (shadow is null)
                {
                    return 0;
                }
                return shadow.AddRefImpl();
            }

            protected static int ReleaseImpl(IntPtr thisObject)
            {
                AComObjectShadow shadow = ToShadow<AComObjectShadow>(thisObject);
                if (shadow is null)
                {
                    return 0;
                }
                return shadow.ReleaseImpl();
            }
        }

        public static Guid IID_Unknown = new Guid("00000000-0000-0000-C000-000000000046");

        protected int QueryInterfaceImpl(ref Guid guid, out IntPtr output)
        {
            AComObjectShadow shadow = (AComObjectShadow)((ShadowContainer)Callback.Shadow).FindShadow(guid);
            if (!(shadow is null))
            {
                ((IUnknown)Callback).AddReference();
                output = shadow.NativePointer;
                return Result.Ok.Code;
            }
            output = IntPtr.Zero;
            return Result.NoInterface.Code;
        }

        protected virtual int AddRefImpl()
        {
            return ((IUnknown)Callback).AddReference();
        }

        protected virtual int ReleaseImpl()
        {
            return ((IUnknown)Callback).Release();
        }
    }
}
