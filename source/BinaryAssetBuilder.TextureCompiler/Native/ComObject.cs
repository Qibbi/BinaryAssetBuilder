using BinaryAssetBuilder.Core;
using System;
using System.Runtime.InteropServices;

namespace Native
{
    public class ComObject : CppObject, IUnknown
    {
        public static Action<string> LogMemoryLeakWarning = (warning) => Tracer.GetTracer(nameof(ComObject), "Provides com interop.").TraceWarning(warning);

        public ComObject(object iUnknownObject)
        {
            NativePointer = Marshal.GetIUnknownForObject(iUnknownObject);
        }

        protected ComObject()
        {
        }

        internal static T AsUnsafe<T>(IntPtr iUnknownPtr)
        {
            using ComObject tempObject = new ComObject(iUnknownPtr);
            return tempObject.QueryInterfaceUnsafe<T>();
        }

        public static bool EqualsComObject<T>(T x, T y) where T : ComObject
        {
            if (Equals(x, y))
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }
            return x.NativePointer == y.NativePointer;
        }

        public static T As<T>(object comObject) where T : ComObject
        {
            using ComObject tempObject = new ComObject(Marshal.GetIUnknownForObject(comObject));
            return tempObject.QueryInterface<T>();
        }

        public static T As<T>(IntPtr iUnknownPtr) where T : ComObject
        {
            using ComObject tempObject = new ComObject(iUnknownPtr);
            return tempObject.QueryInterface<T>();
        }

        public static T QueryInterface<T>(object comObject) where T : ComObject
        {
            using ComObject tempObject = new ComObject(Marshal.GetIUnknownForObject(comObject));
            return tempObject.QueryInterface<T>();
        }

        public static T QueryInterfaceOrNull<T>(IntPtr comPointer) where T : ComObject
        {
            if (comPointer == IntPtr.Zero)
            {
                return null;
            }
            Guid guid = Utilities.GetGuidFromType(typeof(T));
            Result result = Marshal.QueryInterface(comPointer, ref guid, out IntPtr pointerT);
            return result.Failure ? null : FromPointerUnsafe<T>(pointerT);
        }

        protected void QueryInterfaceFrom<T>(T fromObject) where T : ComObject
        {
            fromObject.QueryInterface(Utilities.GetGuidFromType(GetType()), out IntPtr parentPtr);
            NativePointer = parentPtr;
        }

        protected override unsafe void Dispose(bool disposing)
        {
            if (NativePointer != IntPtr.Zero)
            {
                if (!disposing && Configuration.EnableTrackingReleaseOnFinalizer && !Configuration.EnableReleaseOnFinalizer)
                {
                    ObjectReference reference = ObjectTracker.Find(this);
                    LogMemoryLeakWarning?.Invoke($"Live ComObject [0x{NativePointer.ToInt64():X16}], potential memory leak: {reference}");
                }
                if (disposing || Configuration.EnableReleaseOnFinalizer)
                {
                    ((IUnknown)this).Release();
                }
                if (Configuration.EnableObjectTracking)
                {
                    ObjectTracker.UnTrack(this);
                }
                _nativePointer = null;
            }
            base.Dispose(disposing);
        }

        protected override void NativePointerUpdating()
        {
            if (Configuration.EnableObjectTracking)
            {
                ObjectTracker.UnTrack(this);
            }
        }

        protected override void NativePointerUpdated(IntPtr oldNativePointer)
        {
            if (Configuration.EnableObjectTracking)
            {
                ObjectTracker.Track(this);
            }
        }

        internal virtual T QueryInterfaceUnsafe<T>()
        {
            QueryInterface(Utilities.GetGuidFromType(typeof(T)), out IntPtr parentPtr);
            return FromPointerUnsafe<T>(parentPtr);
        }

        public virtual void QueryInterface(Guid guid, out IntPtr outPtr)
        {
            ((IUnknown)this).QueryInterface(ref guid, out outPtr).CheckError();
        }

        public virtual IntPtr QueryInterfaceOrNull(Guid guid)
        {
            ((IUnknown)this).QueryInterface(ref guid, out IntPtr outPtr);
            return outPtr;
        }

        public virtual T QueryInterface<T>() where T : ComObject
        {
            QueryInterface(Utilities.GetGuidFromType(typeof(T)), out IntPtr parentPtr);
            return FromPointer<T>(parentPtr);
        }

        public virtual T QueryInterfaceOrNull<T>() where T : ComObject
        {
            return FromPointer<T>(QueryInterfaceOrNull(Utilities.GetGuidFromType(typeof(T))));
        }

        Result IUnknown.QueryInterface(ref Guid guid, out IntPtr comObject)
        {
            return Marshal.QueryInterface(NativePointer, ref guid, out comObject);
        }

        int IUnknown.AddReference()
        {
            if (NativePointer == IntPtr.Zero)
            {
                throw new InvalidOperationException("COM Pointer is null");
            }
            return Marshal.AddRef(NativePointer);
        }

        int IUnknown.Release()
        {
            if (NativePointer == IntPtr.Zero)
            {
                throw new InvalidOperationException("COM Pointer is null");
            }
            return Marshal.Release(NativePointer);
        }
    }
}
