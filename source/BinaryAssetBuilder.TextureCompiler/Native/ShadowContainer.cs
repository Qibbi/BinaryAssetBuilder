using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Native
{
    internal class ShadowContainer : ADisposeBase
    {
        private static readonly Dictionary<Type, List<Type>> _typeToShadowTypes = new Dictionary<Type, List<Type>>();

        private readonly Dictionary<Guid, ACppObjectShadow> _guidToShadow = new Dictionary<Guid, ACppObjectShadow>();
        private IntPtr _guidPtr;

        public IntPtr[] Guids { get; private set; }

        internal ACppObjectShadow FindShadow(Guid guidType)
        {
            _guidToShadow.TryGetValue(guidType, out ACppObjectShadow shadow);
            return shadow;
        }

        internal IntPtr Find(Guid guidType)
        {
            ACppObjectShadow shadow = FindShadow(guidType);
            return shadow is null ? IntPtr.Zero : shadow.NativePointer;
        }

        internal IntPtr Find(Type type)
        {
            return Find(Utilities.GetGuidFromType(type));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (ACppObjectShadow comObjectCallbackNative in _guidToShadow.Values)
                {
                    comObjectCallbackNative.Dispose();
                }
                _guidToShadow.Clear();
                if (_guidPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(_guidPtr);
                    _guidPtr = IntPtr.Zero;
                }
            }
        }

        public unsafe void Initialize(ICallbackable callback)
        {
            callback.Shadow = this;
            Type type = callback.GetType();
            List<Type> slimInterfaces;
            lock (_typeToShadowTypes)
            {
                if (!_typeToShadowTypes.TryGetValue(type, out slimInterfaces))
                {
                    IEnumerable<Type> interfaces = type.GetTypeInfo().ImplementedInterfaces;
                    slimInterfaces = new List<Type>();
                    slimInterfaces.AddRange(interfaces);
                    _typeToShadowTypes.Add(type, slimInterfaces);
                    foreach (Type item in interfaces)
                    {
                        ShadowAttribute attribute = ShadowAttribute.Get(item);
                        if (attribute is null)
                        {
                            slimInterfaces.Remove(item);
                            continue;
                        }
                        IEnumerable<Type> inheritList = item.GetTypeInfo().ImplementedInterfaces;
                        foreach (Type inheritInterface in inheritList)
                        {
                            slimInterfaces.Remove(inheritInterface);
                        }
                    }
                }
            }
            ACppObjectShadow iUnknownShadow = null;
            foreach (Type item in slimInterfaces)
            {
                ShadowAttribute attribute = ShadowAttribute.Get(item);
                ACppObjectShadow shadow = (ACppObjectShadow)Activator.CreateInstance(attribute.Type);
                shadow.Initialize(callback);
                if (iUnknownShadow is null)
                {
                    iUnknownShadow = shadow;
                    _guidToShadow.Add(AComObjectShadow.IID_Unknown, iUnknownShadow);
                }
                _guidToShadow.Add(Utilities.GetGuidFromType(item), shadow);
                IEnumerable<Type> inheritList = item.GetTypeInfo().ImplementedInterfaces;
                foreach (Type inheritInterface in inheritList)
                {
                    ShadowAttribute inheritAttribute = ShadowAttribute.Get(inheritInterface);
                    if (inheritAttribute is null)
                    {
                        continue;
                    }
                    _guidToShadow.Add(Utilities.GetGuidFromType(inheritInterface), shadow);
                }
            }
            int countGuids = 0;
            foreach (Guid guidKey in _guidToShadow.Keys)
            {
                if (guidKey != Utilities.GetGuidFromType(typeof(IInspectable)) && guidKey != Utilities.GetGuidFromType(typeof(IUnknown)))
                {
                    ++countGuids;
                }
            }
            _guidPtr = Marshal.AllocHGlobal(Utilities.SizeOf<Guid>() * countGuids);
            Guids = new IntPtr[countGuids];
            int idx = 0;
            Guid* pGuid = (Guid*)_guidPtr;
            foreach (Guid guidKey in _guidToShadow.Keys)
            {
                if (guidKey == Utilities.GetGuidFromType(typeof(IInspectable)) || guidKey == Utilities.GetGuidFromType(typeof(IUnknown)))
                {
                    continue;
                }
                pGuid[idx] = guidKey;
                Guids[idx] = new IntPtr(pGuid + idx);
                ++idx;
            }
        }
    }
}