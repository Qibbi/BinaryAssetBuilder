using System;

namespace Native.Direct3D9
{
    public partial class AdapterDetails
    {
        public bool Certified => WhqlLevel != 0;
        public Version DriverVersion => new Version((int)(_rawDriverVersion >> 48) & 0xFFFF,
                                                    (int)(_rawDriverVersion >> 32) & 0xFFFF,
                                                    (int)(_rawDriverVersion >> 16) & 0xFFFF,
                                                    (int)_rawDriverVersion & 0xFFFF);
        public DateTime CertificationDate => WhqlLevel == 0 ? DateTime.MaxValue : (WhqlLevel == 1 ? DateTime.MinValue : new DateTime(1999 + (WhqlLevel >> 16),
                                                                                                                                     (WhqlLevel >> 8) & 0xFF,
                                                                                                                                     WhqlLevel & 0xFF));
    }
}
