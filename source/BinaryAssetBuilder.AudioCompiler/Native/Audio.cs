using System;
using System.Runtime.InteropServices;

namespace Native
{
    public static class Audio
    {
        public enum Compression
        {
            /// <summary>
            /// Signed 16-Bit Big-Endian Interleaved
            /// </summary>
            S16B_INT = 1,

            /// <summary>
            /// EA-XMA
            /// </summary>
            EAXMA = 28,

            /// <summary>
            /// XAS Interleaved (Version 1)
            /// </summary>
            XAS_INT,

            /// <summary>
            /// EALayer3 Interleaved (Version 1)
            /// </summary>
            EALAYER3_INT,

            /// <summary>
            /// EALayer3 Interleaved (Version 2) PCM
            /// </summary>
            EALAYER3PCM_INT,

            /// <summary>
            /// EALayer3 Interleaved (Version 2) Spike
            /// </summary>
            EALAYER3SPIKE_INT
        }

        public enum Type
        {
            WAVE = 1,
            LAYER3 = 34,
            SND = 39
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SIMEX_initDelegate();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SIMEX_shutdownDelegate();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate Type SIMEX_idDelegate([In, MarshalAs(UnmanagedType.LPStr)] string fileName, long offset);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int SIMEX_openDelegate([In, MarshalAs(UnmanagedType.LPStr)] string fileName, long offset, Type type, IntPtr* instance);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public unsafe delegate bool SIMEX_createDelegate([In, MarshalAs(UnmanagedType.LPStr)] string fileName, Type type, IntPtr* instance);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SIMEX_closeDelegate(IntPtr instance);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SIMEX_wcloseDelegate(IntPtr instance);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public unsafe delegate bool SIMEX_infoDelegate(IntPtr instance, IntPtr* info, int element);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SIMEX_freesinfoDelegate(IntPtr info);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool SIMEX_readDelegate(IntPtr instance, IntPtr info, int element);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool SIMEX_writeDelegate(IntPtr instance, IntPtr info, int element);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SIMEX_setplaylocDelegate(IntPtr info, int playloc);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SIMEX_setcodecDelegate(IntPtr info, Compression codec);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public delegate string SIMEX_getsamplerepnameDelegate(Compression codec);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SIMEX_setvbrqualityDelegate(IntPtr info, int quality);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SIMEX_getsamplerateDelegate(IntPtr info);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SIMEX_resampleDelegate(IntPtr info, int sampleRate);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SIMEX_getchannelconfigDelegate(IntPtr info);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SIMEX_getnumsamplesDelegate(IntPtr info);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public delegate string SIMEX_getlasterrDelegate();

        private const string _moduleName = "audio.dll";

        public static readonly IntPtr HModule;

        public static readonly SIMEX_initDelegate SIMEX_init;
        public static readonly SIMEX_shutdownDelegate SIMEX_shutdown;
        public static readonly SIMEX_idDelegate SIMEX_id;
        public static readonly SIMEX_openDelegate SIMEX_open;
        public static readonly SIMEX_createDelegate SIMEX_create;
        public static readonly SIMEX_closeDelegate SIMEX_close;
        public static readonly SIMEX_wcloseDelegate SIMEX_wclose;
        public static readonly SIMEX_infoDelegate SIMEX_info;
        public static readonly SIMEX_freesinfoDelegate SIMEX_freesinfo;
        public static readonly SIMEX_readDelegate SIMEX_read;
        public static readonly SIMEX_writeDelegate SIMEX_write;
        public static readonly SIMEX_setplaylocDelegate SIMEX_setplayloc;
        public static readonly SIMEX_setcodecDelegate SIMEX_setcodec;
        public static readonly SIMEX_getsamplerepnameDelegate SIMEX_getsamplerepname;
        public static readonly SIMEX_setvbrqualityDelegate SIMEX_setvbrquality;
        public static readonly SIMEX_getsamplerateDelegate SIMEX_getsamplerate;
        public static readonly SIMEX_resampleDelegate SIMEX_resample;
        public static readonly SIMEX_getchannelconfigDelegate SIMEX_getchannelconfig;
        public static readonly SIMEX_getnumsamplesDelegate SIMEX_getnumsamples;
        public static readonly SIMEX_getlasterrDelegate SIMEX_getlasterr;

        static Audio()
        {
            HModule = NativeLibrary.Load(_moduleName);
            SIMEX_init = Marshal.GetDelegateForFunctionPointer<SIMEX_initDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_init)));
            SIMEX_shutdown = Marshal.GetDelegateForFunctionPointer<SIMEX_shutdownDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_shutdown)));
            SIMEX_id = Marshal.GetDelegateForFunctionPointer<SIMEX_idDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_id)));
            SIMEX_open = Marshal.GetDelegateForFunctionPointer<SIMEX_openDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_open)));
            SIMEX_create = Marshal.GetDelegateForFunctionPointer<SIMEX_createDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_create)));
            SIMEX_close = Marshal.GetDelegateForFunctionPointer<SIMEX_closeDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_close)));
            SIMEX_wclose = Marshal.GetDelegateForFunctionPointer<SIMEX_wcloseDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_wclose)));
            SIMEX_info = Marshal.GetDelegateForFunctionPointer<SIMEX_infoDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_info)));
            SIMEX_freesinfo = Marshal.GetDelegateForFunctionPointer<SIMEX_freesinfoDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_freesinfo)));
            SIMEX_read = Marshal.GetDelegateForFunctionPointer<SIMEX_readDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_read)));
            SIMEX_write = Marshal.GetDelegateForFunctionPointer<SIMEX_writeDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_write)));
            SIMEX_setplayloc = Marshal.GetDelegateForFunctionPointer<SIMEX_setplaylocDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_setplayloc)));
            SIMEX_setcodec = Marshal.GetDelegateForFunctionPointer<SIMEX_setcodecDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_setcodec)));
            SIMEX_getsamplerepname = Marshal.GetDelegateForFunctionPointer<SIMEX_getsamplerepnameDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_getsamplerepname)));
            SIMEX_setvbrquality = Marshal.GetDelegateForFunctionPointer<SIMEX_setvbrqualityDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_setvbrquality)));
            SIMEX_getsamplerate = Marshal.GetDelegateForFunctionPointer<SIMEX_getsamplerateDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_getsamplerate)));
            SIMEX_resample = Marshal.GetDelegateForFunctionPointer<SIMEX_resampleDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_resample)));
            SIMEX_getchannelconfig = Marshal.GetDelegateForFunctionPointer<SIMEX_getchannelconfigDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_getchannelconfig)));
            SIMEX_getnumsamples = Marshal.GetDelegateForFunctionPointer<SIMEX_getnumsamplesDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_getnumsamples)));
            SIMEX_getlasterr = Marshal.GetDelegateForFunctionPointer<SIMEX_getlasterrDelegate>(NativeLibrary.GetExport(HModule, nameof(SIMEX_getlasterr)));
        }
    }
}
