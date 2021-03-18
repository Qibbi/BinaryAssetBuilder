using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum PowerUpdateType
    {
        BACKUP_GENERATOR,
        INVALID
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PowerUpdateModuleData
    {
        public UpdateModuleData Base;
        public Time UpdatePeriod;
        public Time ReloadTime;
        public Time Duration;
        public PowerUpdateType Type;
    }
}
