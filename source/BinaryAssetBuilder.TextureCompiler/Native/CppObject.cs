using System;

namespace Native
{
    public class CppObject : ADisposeBase, ICallbackable
    {
        protected internal unsafe void* _nativePointer;

        public object Tag { get; set; }
        public unsafe IntPtr NativePointer
        {
            get => (IntPtr)_nativePointer;
            set
            {
                void* newNativePointer = (void*)value;
                if (_nativePointer != newNativePointer)
                {
                    NativePointerUpdating();
                    void* oldNativePointer = _nativePointer;
                    _nativePointer = newNativePointer;
                    NativePointerUpdated((IntPtr)oldNativePointer);
                }
            }
        }
        IDisposable ICallbackable.Shadow
        {
            get => throw new InvalidOperationException("Invalid access to Callback. This is used internally.");
            set => throw new InvalidOperationException("Invalid access to Callback. This is used internally.");
        }

        protected CppObject()
        {
        }

        public CppObject(IntPtr pointer)
        {
            NativePointer = pointer;
        }

        public static explicit operator IntPtr(CppObject x)
        {
            return x is null ? IntPtr.Zero : x.NativePointer;
        }

        internal static T FromPointerUnsafe<T>(IntPtr comObjPtr)
        {
            return (comObjPtr == IntPtr.Zero) ? (T)(object)null : (T)Activator.CreateInstance(typeof(T), comObjPtr);
        }

        public static T FromPointer<T>(IntPtr comObjPtr) where T : CppObject
        {
            return (comObjPtr == IntPtr.Zero) ? null : (T)Activator.CreateInstance(typeof(T), comObjPtr);
        }

        public static IntPtr ToCallbackPtr<TCallback>(ICallbackable callback) where TCallback : ICallbackable
        {
            if (callback is null)
            {
                return IntPtr.Zero;
            }
            if (callback is CppObject comObjPtr)
            {
                return comObjPtr.NativePointer;
            }
            ShadowContainer shadowContainer = callback.Shadow as ShadowContainer;
            if (shadowContainer is null)
            {
                shadowContainer = new ShadowContainer();
                shadowContainer.Initialize(callback);
            }
            return shadowContainer.Find(typeof(TCallback));
        }

        protected void FromTemp(CppObject temp)
        {
            NativePointer = temp.NativePointer;
            temp.NativePointer = IntPtr.Zero;
        }

        protected void FromTemp(IntPtr temp)
        {
            NativePointer = temp;
        }

        protected virtual void NativePointerUpdating()
        {
        }

        protected virtual void NativePointerUpdated(IntPtr oldNativePointer)
        {
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
