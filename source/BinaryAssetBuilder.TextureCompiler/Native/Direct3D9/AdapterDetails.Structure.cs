using BinaryAssetBuilder.Native;
using System;
using System.Runtime.InteropServices;

namespace Native.Direct3D9
{
    public partial class AdapterDetails
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct Native
        {
            public unsafe fixed byte Driver[512];
            public unsafe fixed byte Description[512];
            public unsafe fixed byte DeviceName[32];
            public long RawDriverVersion;
            public int VendorId;
            public int DeviceId;
            public int SubsystemId;
            public int Revision;
            public Guid DeviceIdentifier;
            public int WhqlLevel;
        }

        public string Driver;
        public string Description;
        public string DeviceName;
        public int VendorId;
        public int DeviceId;
        public int SubsystemId;
        public int Revision;
        public Guid DeviceIdentifier;
        public int WhqlLevel;

        internal long _rawDriverVersion;

        internal unsafe void MarshalFrom(ref Native objT)
        {
            fixed (Native* pNative = &objT)
            {
                Driver = Marshal.PtrToStringAnsi((IntPtr)pNative->Driver, 512);
                Description = Marshal.PtrToStringAnsi((IntPtr)pNative->Description, 512);
                DeviceName = Marshal.PtrToStringAnsi((IntPtr)pNative->DeviceName, 32);
            }
            _rawDriverVersion = objT.RawDriverVersion;
            VendorId = objT.VendorId;
            DeviceId = objT.DeviceId;
            SubsystemId = objT.SubsystemId;
            Revision = objT.Revision;
            DeviceIdentifier = objT.DeviceIdentifier;
            WhqlLevel = objT.WhqlLevel;
        }

        internal unsafe void MarshalTo(ref Native objT)
        {
            fixed (Native* pNative = &objT)
            {
                IntPtr ptr = Marshal.StringToHGlobalAnsi(Driver);
                MsVcRt.MemSet((IntPtr)pNative->Driver, 0, new SizeT(512));
                MsVcRt.MemCpy((IntPtr)pNative->Driver, ptr, new SizeT(Driver.Length));
                Marshal.FreeHGlobal(ptr);
                ptr = Marshal.StringToHGlobalAnsi(Description);
                MsVcRt.MemSet((IntPtr)pNative->Description, 0, new SizeT(512));
                MsVcRt.MemCpy((IntPtr)pNative->Description, ptr, new SizeT(Description.Length));
                Marshal.FreeHGlobal(ptr);
                ptr = Marshal.StringToHGlobalAnsi(DeviceName);
                MsVcRt.MemSet((IntPtr)pNative->DeviceName, 0, new SizeT(32));
                MsVcRt.MemCpy((IntPtr)pNative->DeviceName, ptr, new SizeT(DeviceName.Length));
                Marshal.FreeHGlobal(ptr);
            }
            objT.RawDriverVersion = _rawDriverVersion;
            objT.VendorId = VendorId;
            objT.DeviceId = DeviceId;
            objT.SubsystemId = SubsystemId;
            objT.Revision = Revision;
            objT.DeviceIdentifier = DeviceIdentifier;
            objT.WhqlLevel = WhqlLevel;
        }
    }
}
