using System;
using System.Runtime.InteropServices;

namespace Native
{
    public class Direct3D : IDisposable
    {
        private class Vtbl
        {
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public unsafe delegate uint ReleaseDelegate([In] IDirect3D* self);

            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public unsafe delegate uint CreateDeviceDelegate([In] IDirect3D* self,
                                                             uint adapter,
                                                             D3DDeviceType deviceType,
                                                             IntPtr hFocusWindow,
                                                             int behaviorFlags,
                                                             D3DPresentParameters* pPresentationParameters,
                                                             D3DDevice.ID3DDevice** ppReturnedDeviceInterface);

            public ReleaseDelegate Release;
            public CreateDeviceDelegate CreateDevice;

            public unsafe Vtbl(void** vtbl)
            {
                Release = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(new IntPtr(vtbl[2]));
                CreateDevice = Marshal.GetDelegateForFunctionPointer<CreateDeviceDelegate>(new IntPtr(vtbl[16]));
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 4)]
        private struct IDirect3D
        {
        }

        private unsafe IDirect3D* _struct;
        private readonly Vtbl _vtbl;

        public unsafe Direct3D()
        {
            _struct = (IDirect3D*)D3D9.Direct3DCreate9(0u);
            _vtbl = new Vtbl((void**)*(void**)_struct);
        }

        public unsafe uint Release()
        {
            uint result = 0xFFFFFFFFu;
            if (_struct != null)
            {
                result = _vtbl.Release(_struct);
                _struct = null;
            }
            return result;
        }

        public unsafe uint CreateDevice(uint adapter,
                                        D3DDeviceType deviceType,
                                        IntPtr hFocusWindow,
                                        int behaviorFlags,
                                        IntPtr presentationParameters,
                                        out D3DDevice returnedDevice)
        {
            D3DDevice.ID3DDevice* pDeviceInterface;
            uint result = _vtbl.CreateDevice(_struct, adapter, deviceType, hFocusWindow, behaviorFlags, (D3DPresentParameters*)presentationParameters, &pDeviceInterface);
            returnedDevice = new D3DDevice((IntPtr)pDeviceInterface);
            return result;
        }

        public void Dispose()
        {
            Release();
        }
    }
}
