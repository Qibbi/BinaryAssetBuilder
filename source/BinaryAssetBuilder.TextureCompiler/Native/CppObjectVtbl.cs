using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Native
{
    internal class CppObjectVtbl
    {
        private readonly List<Delegate> _methods;
        private readonly IntPtr _vtbl;

        public IntPtr Pointer => _vtbl;

        public CppObjectVtbl(int numberOfCallbackMethods)
        {
            _vtbl = Marshal.AllocHGlobal(IntPtr.Size * numberOfCallbackMethods);
            _methods = new List<Delegate>();
        }

        public unsafe void AddMethod(Delegate method)
        {
            int index = _methods.Count;
            _methods.Add(method);
            *((IntPtr*)_vtbl + index) = Marshal.GetFunctionPointerForDelegate(method);
        }
    }
}