using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.Hashing;
using BinaryAssetBuilder.Core.IO;
using Native;
using Relo;
using SageBinaryData;
using System;
using System.IO;

namespace BinaryAssetBuilder.AudioCompiler
{
    public class Plugin : IAssetBuilderPlugin
    {
        private class AutoInstanceCloser : IDisposable
        {
            private IntPtr _instance;

            public AutoInstanceCloser(IntPtr instance)
            {
                _instance = instance;
            }

            public void Dispose()
            {
                if (_instance != IntPtr.Zero)
                {
                    Audio.SIMEX_close(_instance);
                    _instance = IntPtr.Zero;
                }
            }
        }

        private class AutoInstanceWCloser : IDisposable
        {
            private IntPtr _instance;

            public AutoInstanceWCloser(IntPtr instance)
            {
                _instance = instance;
            }

            public void Dispose()
            {
                if (_instance != IntPtr.Zero)
                {
                    Audio.SIMEX_wclose(_instance);
                    _instance = IntPtr.Zero;
                }
            }
        }

        private class AutoInfoFreer : IDisposable
        {
            private IntPtr _info;

            public AutoInfoFreer(IntPtr info)
            {
                _info = info;
            }

            public void Dispose()
            {
                if (_info != IntPtr.Zero)
                {
                    Audio.SIMEX_freesinfo(_info);
                    _info = IntPtr.Zero;
                }
            }
        }

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(AudioCompiler), "Provides Audio processing functionality");
        private static readonly string _tempFilenameSuffix = "BinaryAssetBuilder.AudioCompiler.tempfile";

        private uint _hashCode = 0u;
        private TargetPlatform _targetPlatform = TargetPlatform.Win32;
        public uint AllTypesHash => 0xEB19D975u; // TW 1.09; 0x12B3E763u KW 1.02

        public uint VersionNumber
        {
            get
            {
                return _targetPlatform switch
                {
                    TargetPlatform.Win32 => 1001010U,
                    TargetPlatform.Xbox360 => 3001010U,
                    _ => throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Internal error: unknown platform {0}", _targetPlatform),
                };
            }
        }

        private string GetLastSIMEXError()
        {
            return Audio.SIMEX_getlasterr();
        }

        private unsafe void WriteAssetBuffer(AssetBuffer buffer, Tracker tracker)
        {
            Relo.Chunk chunk = new Relo.Chunk();
            tracker.MakeRelocatable(chunk);
            buffer.InstanceData = chunk.InstanceBuffer;
            if (chunk.RelocationBuffer.Length > 0)
            {
                buffer.RelocationData = chunk.RelocationBuffer;
            }
            else
            {
                buffer.RelocationData = Array.Empty<byte>();
            }
            if (chunk.ImportsBuffer.Length > 0)
            {
                buffer.ImportsData = chunk.ImportsBuffer;
            }
            else
            {
                buffer.ImportsData = Array.Empty<byte>();
            }
        }

        public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
        {
            ExtendedTypeInformation result = new ExtendedTypeInformation
            {
                HasCustomData = true,
                TypeId = typeId
            };
            switch (typeId)
            {
                case 0x166B084Du:
                    result.Type = typeof(AudioFile);
                    result.TypeName = nameof(AudioFile);
                    result.ProcessingHash = VersionNumber ^ 0x83398E45u;
                    result.TypeHash = 0x46410F77u;
                    break;
                case 0x15BDBF02u:
                    result.Type = typeof(AudioFileMP3Passthrough);
                    result.TypeName = nameof(AudioFileMP3Passthrough);
                    result.ProcessingHash = VersionNumber ^ 0x3520BB9Cu;
                    result.TypeHash = 0x610DB321u;
                    break;
            }
            return result;
        }

        public void Initialize(TargetPlatform platform)
        {
            _hashCode = HashProvider.GetTypeHash(GetType());
            _targetPlatform = platform;
            Audio.SIMEX_init();
        }

        public void ReInitialize(TargetPlatform platform)
        {
            Audio.SIMEX_shutdown();
            Initialize(platform);
        }

        public unsafe AssetBuffer ProcessMP3PassthroughInstance(InstanceDeclaration instance)
        {
            AssetBuffer result = new AssetBuffer();
            bool isBigEndian = _targetPlatform == TargetPlatform.Xbox360;
            Node node = new Node(instance.Node.CreateNavigator(), instance.Document.NamespaceManager);
            AudioFileMP3Passthrough* audioFile;
            using (Tracker tracker = new Tracker((void**)&audioFile, (uint)sizeof(AudioFileMP3Passthrough), false))
            {
                AudioFileMP3PassthroughRuntime* audioFileRuntime;
                using (Tracker trackerRuntime = new Tracker((void**)&audioFileRuntime, (uint)sizeof(AudioFileMP3PassthroughRuntime), isBigEndian))
                {
                    Marshaler.Marshal(node, audioFile, tracker);
                    audioFileRuntime->IsStreamed = audioFile->IsStreamed;
                    string file = instance.XmlNode.Attributes["File"].Value;
                    if ((IntPtr)audioFile->SubtitleStringName != IntPtr.Zero)
                    {
                        Marshaler.Marshal(audioFile->SubtitleStringName, &audioFileRuntime->SubtitleStringName, trackerRuntime);
                    }
                    else
                    {
                        string subTitle = $"DIALOGEVENT:{Path.GetFileNameWithoutExtension(file)}SubTitle";
                        Marshaler.Marshal(subTitle, &audioFileRuntime->SubtitleStringName, trackerRuntime);
                    }
                    if (Audio.SIMEX_id(file, 0L) != Audio.Type.LAYER3)
                    {
                        _tracer.TraceWarning("Passthrough is for MP3 format only. Cannot process \"{0}\"", file);
                        return null; // no further checking for now
                    }
                    if (File.Exists(instance.CustomDataPath))
                    {
                        _tracer.TraceNote("Deleting old output file {0}\n", instance.CustomDataPath);
                        File.Delete(instance.CustomDataPath);
                    }
                    _tracer.TraceNote("Copying {0} to {1}\n", file, instance.CustomDataPath);
                    File.Copy(file, instance.CustomDataPath);
                    WriteAssetBuffer(result, trackerRuntime);
                }
            }
            return result;
        }

        public unsafe AssetBuffer ProcessAudioFileInstance(InstanceDeclaration instance)
        {
            AssetBuffer result = new AssetBuffer();
            bool isBigEndian = _targetPlatform == TargetPlatform.Xbox360;
            Node node = new Node(instance.Node.CreateNavigator(), instance.Document.NamespaceManager);
            int* sampleRatePtr;
            int quality;
            Audio.Compression compression;
            bool isStreamed;
            AudioFile* audioFile;
            using (Tracker tracker = new Tracker((void**)&audioFile, (uint)sizeof(AudioFile), false))
            {
                AudioFileRuntime* audioFileRuntime;
                using (Tracker trackerRuntime = new Tracker((void**)&audioFileRuntime, (uint)sizeof(AudioFileRuntime), isBigEndian))
                {
                    Marshaler.Marshal(node, audioFile, tracker);
                    string file = instance.XmlNode.Attributes["File"].Value;
                    bool isSound = Path.GetDirectoryName(file).ToLower().EndsWith("\\sounds");
                    SageBool* isStreamedPtr;
                    switch (_targetPlatform)
                    {
                        case TargetPlatform.Win32:
                            isStreamedPtr = audioFile->IsStreamedOnPC;
                            sampleRatePtr = audioFile->PCSampleRate;
                            quality = audioFile->PCQuality;
                            if ((IntPtr)audioFile->PCCompression == IntPtr.Zero)
                            {
                                compression = !isSound ? Audio.Compression.S16B_INT : Audio.Compression.XAS_INT;
                                break;
                            }
                            switch (*audioFile->PCCompression)
                            {
                                case PCAudioCompressionSetting.NONE:
                                    compression = Audio.Compression.S16B_INT;
                                    break;
                                case PCAudioCompressionSetting.XAS:
                                    compression = Audio.Compression.XAS_INT;
                                    break;
                                case PCAudioCompressionSetting.EALAYER3:
#if VERSION5
                                    compression = Audio.Compression.EALAYER3_INT;
#else
                                    compression = Audio.Compression.EALAYER3PCM_INT;
#endif
                                    break;
                                default:
                                    throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                                          "Internal error: xml compiler returned bad PC audio compression of type {0}",
                                                                          *audioFile->PCCompression);
                            }
                            break;
                        case TargetPlatform.Xbox360:
                            isStreamedPtr = audioFile->IsStreamedOnXenon;
                            sampleRatePtr = audioFile->XenonSampleRate;
                            quality = audioFile->XenonQuality;
                            if ((IntPtr)audioFile->XenonCompression == IntPtr.Zero)
                            {
                                compression = Audio.Compression.EAXMA;
                                break;
                            }
                            switch (*audioFile->XenonCompression)
                            {
                                case XenonAudioCompressionSetting.NONE:
                                    compression = Audio.Compression.S16B_INT;
                                    break;
                                case XenonAudioCompressionSetting.XMA:
                                    compression = Audio.Compression.EAXMA;
                                    break;
                                case XenonAudioCompressionSetting.EALAYER3:
#if VERSION5
                                    compression = Audio.Compression.EALAYER3_INT;
#else
                                    compression = Audio.Compression.EALAYER3PCM_INT;
#endif
                                    break;
                                default:
                                    throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                                          "Internal error: xml compiler returned bad 360 audio compression of type {0}",
                                                                          *audioFile->PCCompression);
                            }
                            break;
                        case TargetPlatform.PlayStation3:
                            throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Internal error: PS3 not supported.");
                        default:
                            throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Internal error: unknown platform {0}", _targetPlatform);
                    }
                    isStreamed = (IntPtr)isStreamedPtr == IntPtr.Zero ? !isSound : *isStreamedPtr;
                    if ((IntPtr)audioFile->SubtitleStringName != IntPtr.Zero)
                    {
                        Marshaler.Marshal(audioFile->SubtitleStringName, &audioFileRuntime->SubtitleStringName, trackerRuntime);
                    }
                    else
                    {
                        string subTitle = $"DIALOGEVENT:{Path.GetFileNameWithoutExtension(file)}SubTitle";
                        Marshaler.Marshal(subTitle, &audioFileRuntime->SubtitleStringName, trackerRuntime);
                    }
                    audioFileRuntime->NumberOfChannels = 0;
                    audioFileRuntime->NumberOfSamples = 0;
                    audioFileRuntime->SampleRate = 0;
                    audioFileRuntime->HeaderData = 0;
                    audioFileRuntime->HeaderDataSize = 0;
                    using (FileStream stream = File.OpenRead(file))
                    {
                        if (stream is null)
                        {
                            _tracer.TraceWarning("Couldn't open audio file \"{0}\"", file);
                            return null;
                        }
                    }
                    Audio.Type type = Audio.SIMEX_id(file, 0L);
                    if ((int)type < 0)
                    {
                        _tracer.TraceWarning("Unable to identify format of \"{0}\"; cannot process. (Error: {1})", file, GetLastSIMEXError());
                        return null;
                    }
                    if (type != Audio.Type.WAVE)
                    {
                        _tracer.TraceWarning("Input files must be WAVE format. Cannot process \"{0}\"", file);
                        return null;
                    }
                    IntPtr simexInput = IntPtr.Zero;
                    int count = Audio.SIMEX_open(file, 0L, type, &simexInput);
                    using (new AutoInstanceCloser(simexInput))
                    {
                        if (count <= 0 || simexInput == IntPtr.Zero)
                        {
                            _tracer.TraceWarning("Could not begin audio processing of \"{0}\". (Error: {1})", file, GetLastSIMEXError());
                            return null;
                        }
                        string tempFile = Path.Combine(instance.CustomDataPath, _tempFilenameSuffix);
                        using (AutoCleanUpTempFiles tempFiles = new AutoCleanUpTempFiles(tempFile))
                        {
                            IntPtr simexOutput = IntPtr.Zero;
                            if (!Audio.SIMEX_create(tempFile, Audio.Type.LAYER3, &simexOutput))
                            {
                                throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                                      "Internal Error preparing audio output file \"{0}\" (SIMEX_create(): {1})",
                                                                      file,
                                                                      GetLastSIMEXError());
                            }
                            using (new AutoInstanceWCloser(simexOutput))
                            {
                                for (int idx = 0; idx < count; ++idx)
                                {
                                    IntPtr info = IntPtr.Zero;
                                    if (!Audio.SIMEX_info(simexInput, &info, idx))
                                    {
                                        throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                                              "Internal Error reading element {0} of \"{1}\" (SIMEX_info(): {2})",
                                                                              idx,
                                                                              file,
                                                                              GetLastSIMEXError());
                                    }
                                    using (new AutoInfoFreer(info))
                                    {
                                        if (info != IntPtr.Zero)
                                        {
                                            if (!Audio.SIMEX_read(simexInput, info, idx))
                                            {
                                                throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                                                      "Internal error reading element {0} of \"{1}\" (SIMEX_read(): {2})",
                                                                                      idx,
                                                                                      file,
                                                                                      GetLastSIMEXError());
                                            }
                                            if (isStreamed)
                                            {
                                                Audio.SIMEX_setplayloc(info, 4096);
                                                _tracer.TraceNote("Setting play location to streamed");
                                            }
                                            else
                                            {
                                                Audio.SIMEX_setplayloc(info, 2048);
                                                _tracer.TraceNote("Setting play location to RAM");
                                            }
                                            Audio.SIMEX_setcodec(info, compression);
                                            _tracer.TraceNote("Setting compression type to {0}", Audio.SIMEX_getsamplerepname(compression));
                                            if (compression == Audio.Compression.EAXMA
                                                || compression == Audio.Compression.EALAYER3_INT
                                                || compression == Audio.Compression.EALAYER3PCM_INT
                                                || compression == Audio.Compression.EALAYER3SPIKE_INT)
                                            {
                                                if (quality < 0 || quality > 100)
                                                {
                                                    throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument,
                                                                                          "Audio file {0}: Quality parameter must be between 0 and 100",
                                                                                          instance);
                                                }
                                                Audio.SIMEX_setvbrquality(info, quality);
                                                _tracer.TraceNote("Setting compression quality to {0}", quality);
                                            }
                                            if (sampleRatePtr != null)
                                            {
                                                int old = Audio.SIMEX_getsamplerate(info);
                                                int sampleRate = *sampleRatePtr;
                                                if (old != sampleRate)
                                                {
                                                    if (sampleRate < 400 || sampleRate > 96000)
                                                    {
                                                        throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument,
                                                                                              "Audio file {0}: Sample rate must be between 400 and 96000",
                                                                                              instance);
                                                    }
                                                    _tracer.TraceNote("Resampling from {0} to {1}", old, sampleRate);
                                                    Audio.SIMEX_resample(info, sampleRate);
                                                    old = Audio.SIMEX_getsamplerate(info);
                                                    if (old != sampleRate)
                                                    {
                                                        _tracer.TraceWarning("Downsampling of audio file {0} not completely sucessful. Wanted final sample of {1}Hz but got {2}Hz",
                                                                             instance,
                                                                             sampleRate,
                                                                             old);
                                                    }
                                                }
                                            }
                                            audioFileRuntime->NumberOfChannels = (byte)Audio.SIMEX_getchannelconfig(info);
                                            audioFileRuntime->NumberOfSamples = Audio.SIMEX_getnumsamples(info);
                                            audioFileRuntime->SampleRate = Audio.SIMEX_getsamplerate(info);
                                            if (audioFileRuntime->NumberOfChannels != 1
                                                && audioFileRuntime->NumberOfChannels != 2
                                                && audioFileRuntime->NumberOfChannels == 4
                                                && audioFileRuntime->NumberOfChannels == 6)
                                            {
                                                _tracer.TraceWarning("Audio file {0} has {1} channel(s). The only supported channel counts are 1, 2, 4, and 6; sample will probably use only the first channel in the engine",
                                                    instance,
                                                    audioFileRuntime->NumberOfChannels);
                                            }
                                            if (!Audio.SIMEX_write(simexOutput, info, idx))
                                            {
                                                throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                                                      "Internal error writing element {0} of \"{1}\" (SIMEX_write(): {2})",
                                                                                      idx,
                                                                                      tempFile,
                                                                                      GetLastSIMEXError());
                                            }
                                        }
                                    }
                                }
                            }
                            string snr = tempFile + ".snr";
                            if (File.Exists(instance.CustomDataPath))
                            {
                                _tracer.TraceNote("Deleting old output file {0}\n", instance.CustomDataPath);
                                File.Delete(instance.CustomDataPath);
                            }
                            _tracer.TraceNote("Creating output file {0}\n", instance.CustomDataPath);
                            if (isStreamed)
                            {
                                File.Move(tempFile + ".sns", instance.CustomDataPath);
                                byte[] buffer;
                                using (Stream stream = File.Open(snr, FileMode.Open, FileAccess.Read, FileShare.Read))
                                {
                                    buffer = new byte[stream.Length];
                                    stream.Read(buffer, 0, buffer.Length);
                                }
                                audioFileRuntime->HeaderDataSize = buffer.Length;
                                fixed (byte* pBuffer = &buffer[0])
                                {
                                    using (Tracker.Context context = trackerRuntime.Push((void**)&audioFileRuntime->HeaderData, 1u, (uint)buffer.Length))
                                    {
                                        MsVcRt.MemCpy(new IntPtr(audioFileRuntime->HeaderData), new IntPtr(pBuffer), new SizeT(buffer.Length));
                                    }
                                }
                            }
                            else
                            {
                                File.Move(snr, instance.CustomDataPath);
                            }
                            WriteAssetBuffer(result, trackerRuntime);
                        }
                    }
                }
            }
            return result;
        }

        public AssetBuffer ProcessInstance(InstanceDeclaration instance)
        {
            AssetBuffer result;
            switch (instance.Handle.TypeId)
            {
                case 0x166B084Du:
                    result = ProcessAudioFileInstance(instance);
                    break;
                case 0x15BDBF02u:
                    result = ProcessMP3PassthroughInstance(instance);
                    break;
                default:
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Couldn't process {0}. No matching handler found.", instance);
            }
            return result;
        }
    }
}
