using System;

namespace Native.Direct3D9
{
    [Flags]
    public enum CreateFlags
    {
        None,
        FpuPreserve = 0x00000002,
        Multithreaded = 0x00000004,
        PureDevice = 0x00000010,
        SoftwareVertexProcessing = 0x00000020,
        HardwareVertexProcessing = 0x00000040,
        MixedVertexProcessing = 0x00000080,
        DisableDriverManagement = 0x00000100,
        AdapterGroupDevice = 0x00000200,
        DisableExtendedDriverManagement = 0x00000400,
        NoWindowChanges = 0x00000800,
        DisablePsgpThreading = 0x00002000,
        EnablePresentationStatistics = 0x00004000,
        DisablePrintScreen = 0x00008000,
        AllowScreensavers = 0x10000000
    }
}
