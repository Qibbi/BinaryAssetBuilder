using BinaryAssetBuilder.Core;
using Relo;
using SageBinaryData;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;

namespace BinaryAssetBuilder.W3XCompiler
{
    public class Plugin : IAssetBuilderPlugin
    {
        public unsafe delegate void MarshalDelegate<T>(Node node, T* objT, Tracker state) where T : unmanaged;

        private static readonly IDictionary<uint, MethodInfo> _handleMethods = new SortedDictionary<uint, MethodInfo>();
        private static readonly IDictionary<uint, Delegate> _marshalMethods = new SortedDictionary<uint, Delegate>();

        private TargetPlatform _platform;

        public uint AllTypesHash => 0xEB19D975u; // TW 1.09; 0x12B3E763u KW 1.02
        public uint VersionNumber => 8u;

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

        public void Initialize(TargetPlatform platform)
        {
            _platform = platform;
        }

        public void ReInitialize(TargetPlatform platform)
        {
            Initialize(platform);
        }

        public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
        {
            ExtendedTypeInformation result = new ExtendedTypeInformation
            {
                HasCustomData = false,
                TypeId = typeId
            };
            switch (typeId)
            {
                case 0x2448AE30u:
                    result.Type = typeof(W3DAnimation);
                    result.TypeName = nameof(W3DAnimation);
                    result.ProcessingHash = 0xC55CB6D8u;
                    result.TypeHash = 0xCC069193u;
                    break;
                case 0xC2B1A262u:
                    result.Type = typeof(W3DMesh);
                    result.TypeName = nameof(W3DMesh);
                    result.ProcessingHash = 1 ^ 0xC9D7E778u;
                    result.TypeHash = 0xC9D7E778u;
                    break;
            }
            return result;
        }

        public unsafe void HandleW3DAnimation(InstanceDeclaration declaration, AssetBuffer buffer)
        {
            W3DAnimation* animation;
            using Tracker tracker = new Tracker((void**)&animation, (uint)sizeof(W3DAnimation), false);
            bool isBigEndian = _platform == TargetPlatform.Xbox360;
            W3DAnimationRuntime* animationRuntime;
            using Tracker trackerRuntime = new Tracker((void**)&animationRuntime, (uint)sizeof(W3DAnimationRuntime), isBigEndian);
            XmlNamespaceManager namespaceManager = declaration.Document.NamespaceManager;
            XPathNavigator navigator = declaration.Node.CreateNavigator();
            Node node = new Node(navigator, namespaceManager);
            Marshaler.Marshal(node, animation, tracker);
            W3DAnimation.CompressionSetting compressionSettings = new W3DAnimation.CompressionSetting();
            if (animation->CompressionSettings != null)
            {
                Native.MsVcRt.MemCpy((IntPtr)(&compressionSettings), (IntPtr)animation->CompressionSettings, new Native.SizeT(sizeof(W3DAnimation.CompressionSetting)));
            }
            else
            {
                switch (_platform)
                {
                    case TargetPlatform.Win32:
                        compressionSettings.MaxTranslationError = 1.0f / 500.0f;
                        compressionSettings.MaxRotationError = 3.0f / 1000.0f;
                        compressionSettings.MaxVisibilityError = 0.01f;
                        compressionSettings.MaxAdaptiveDeltaError = 1.0f / 1000.0f;
                        compressionSettings.ForceReductionRate = 1.0f;
                        compressionSettings.AllowTimeCoded = true;
                        compressionSettings.AllowAdaptiveDelta = true;
                        break;
                    case TargetPlatform.Xbox360:
                        compressionSettings.MaxTranslationError = 1.0f / 500.0f;
                        compressionSettings.MaxRotationError = 3.0f / 1000.0f;
                        compressionSettings.MaxVisibilityError = 0.01f;
                        compressionSettings.MaxAdaptiveDeltaError = 1.0f / 1000.0f;
                        compressionSettings.ForceReductionRate = 1.0f;
                        compressionSettings.AllowTimeCoded = true;
                        compressionSettings.AllowAdaptiveDelta = true;
                        break;
                    default:
                        throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Unknown platform {0}", _platform);
                }
            }
            if (!compressionSettings.AllowAdaptiveDelta && !compressionSettings.AllowTimeCoded)
            {
                compressionSettings.AllowTimeCoded = true;
                compressionSettings.MaxTranslationError = 0.0f;
                compressionSettings.MaxRotationError = 0.0f;
                compressionSettings.MaxVisibilityError = 0.0f;
                compressionSettings.ForceReductionRate = 1.0f;
            }
            AssetReference<W3DHierarchy>* animationHierarchy = &animation->Hierarchy;
            AssetReference<W3DHierarchy>* animationRuntimeHierarchy = &animationRuntime->Hierarchy;
            trackerRuntime.AddReference((void*)animationRuntimeHierarchy, *(uint*)animationHierarchy);
            uint numFrames = animation->NumFrames;
            trackerRuntime.InplaceEndianToPlatform(&numFrames);
            animationRuntime->NumFrames = numFrames;
            uint frameRate = animation->FrameRate;
            trackerRuntime.InplaceEndianToPlatform(&frameRate);
            animationRuntime->FrameRate = frameRate;
            uint channelCount = animation->Channels.Count;
            AnimationChannelBaseRuntime*** channels = &animationRuntime->Channels.Items;
            using Tracker.Context context = trackerRuntime.Push((void**)channels, (uint)sizeof(IntPtr), channelCount);
            uint channelCountRuntime = channelCount;
            trackerRuntime.InplaceEndianToPlatform(&channelCountRuntime);
            animationRuntime->Channels.Count = channelCountRuntime;
            for (int currentChannel = 0; currentChannel < channelCount; ++currentChannel)
            {
                AnimationChannelBase* source = animation->Channels.Items[currentChannel];
                int firstFrame = (int)source->FirstFrame;
                System.Collections.Generic.List<SrcFrame> srcFrames = new System.Collections.Generic.List<SrcFrame>();
                switch (source->TypeId)
                {
                    case 0x50D28EF5u:
                        AnimationChannelScalar* channelScalar = (AnimationChannelScalar*)source;
                        SrcFrame srcFrame = new SrcFrame
                        {
                            Position = 0,
                            BinaryMove = false
                        };
                        switch (source->Type)
                        {
                            case AnimationChannelType.XTranslation:
                            case AnimationChannelType.YTranslation:
                            case AnimationChannelType.ZTranslation:
                                srcFrame.Values.Add(0.0f);
                                break;
                            case AnimationChannelType.Visibility:
                                srcFrame.Values.Add(1.0f);
                                break;
                            default:
                                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Unknown animation channel usage {0}", source->Type);
                        }
                        srcFrames.Capacity = (int)animation->NumFrames;
                        for (int idx = 0; idx < animation->NumFrames; ++idx)
                        {
                            SrcFrame frame = srcFrame.Clone() as SrcFrame;
                            frame.Position = idx;
                            srcFrames.Add(frame);
                        }
                        for (int idx = 0; idx < channelScalar->Frame.Count; ++idx)
                        {
                            AnimationChannelScalarFrame* scalarFrame = &channelScalar->Frame.Items[idx];
                            srcFrames[idx + firstFrame].Values = new System.Collections.Generic.List<float> { scalarFrame->Value };
                            srcFrames[idx + firstFrame].BinaryMove = scalarFrame->BinaryMove;
                        }
                        break;
                    case 0xF642DD20u:
                        AnimationChannelQuaternion* channelQuaternion = (AnimationChannelQuaternion*)source;
                        srcFrame = new SrcFrame
                        {
                            Position = 0,
                            Values = new System.Collections.Generic.List<float> { 0.0f, 0.0f, 0.0f, 1.0f },
                            BinaryMove = false
                        };
                        srcFrames.Capacity = (int)animation->NumFrames;
                        for (int idx = 0; idx < animation->NumFrames; ++idx)
                        {
                            SrcFrame frame = srcFrame.Clone() as SrcFrame;
                            frame.Position = idx;
                            srcFrames.Add(frame);
                        }
                        for (int idx = 0; idx < channelQuaternion->Frame.Count; ++idx)
                        {
                            AnimationChannelQuaternionFrame* quaternionFrame = &channelQuaternion->Frame.Items[idx];
                            srcFrames[idx + firstFrame].Values = new System.Collections.Generic.List<float>
                            {
                                quaternionFrame->Value.X,
                                quaternionFrame->Value.Y,
                                quaternionFrame->Value.Z,
                                quaternionFrame->Value.W
                            };
                            srcFrames[idx + firstFrame].BinaryMove = quaternionFrame->BinaryMove;
                        }
                        break;
                    default:
                        throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Unknown animation channel type {0}", source->TypeId);
                }
                CompressedTimecoded compressedTimecoded = null;
                CompressedAdaptiveDelta compressedAdaptiveDelta = null;
                if (compressionSettings.AllowAdaptiveDelta)
                {
                    compressedAdaptiveDelta = CompressedAdaptiveDelta.Compress(source, srcFrames, ref compressionSettings);
                }
                if (compressedAdaptiveDelta is null || compressionSettings.AllowTimeCoded)
                {
                    compressedTimecoded = CompressedTimecoded.Compress(source, srcFrames, ref compressionSettings);
                }
                if (compressedAdaptiveDelta is null || (compressedTimecoded != null && compressedTimecoded.EstimateSize() < compressedAdaptiveDelta.EstimateSize()))
                {
                    compressedTimecoded.WriteOut(trackerRuntime, (AnimationChannelTimecoded**)&animationRuntime->Channels.Items[currentChannel]);
                }
                else
                {
                    compressedAdaptiveDelta.WriteOut(trackerRuntime, (AnimationChannelDelta**)&animationRuntime->Channels.Items[currentChannel]);
                }
            }
            WriteAssetBuffer(buffer, trackerRuntime);
        }

        public unsafe void HandleType<T>(InstanceDeclaration declaration, AssetBuffer buffer) where T : unmanaged
        {
            bool isBigEndian = _platform == TargetPlatform.Xbox360;
            XmlNamespaceManager namespaceManager = declaration.Document.NamespaceManager;
            XPathNavigator navigator = declaration.Node.CreateNavigator();
            Node node = new Node(navigator, namespaceManager);
            T* objT;
            using Tracker tracker = new Tracker((void**)&objT, (uint)sizeof(T), isBigEndian);
            if (!_marshalMethods.TryGetValue(declaration.Handle.TypeId, out Delegate marshal))
            {
                MethodInfo method = typeof(Marshaler).GetMethod(nameof(Marshaler.Marshal), new[] { typeof(Node), typeof(T*), typeof(Tracker) });
                if (method is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot find marshal method for type '{0}'", typeof(T*).Name);
                }
                marshal = Delegate.CreateDelegate(typeof(MarshalDelegate<T>), method);
                if (marshal is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot convert marshal method to delegate for type '{0}'", typeof(T*).Name);
                }
                _marshalMethods.Add(declaration.Handle.TypeId, marshal);
            }
            (marshal as MarshalDelegate<T>)(node, objT, tracker);
            WriteAssetBuffer(buffer, tracker);
        }

        public unsafe AssetBuffer ProcessInstance(InstanceDeclaration declaration)
        {
            AssetBuffer result = new AssetBuffer();
            switch (declaration.Handle.TypeId)
            {
                case 0x2448AE30u:
                    HandleW3DAnimation(declaration, result);
                    break;
                default:
                    if (!_handleMethods.TryGetValue(declaration.Handle.TypeId, out MethodInfo handleType))
                    {
                        handleType = GetType().GetMethod(nameof(HandleType));
                        ExtendedTypeInformation extendedTypeInformation = GetExtendedTypeInformation(declaration.Handle.TypeId);
                        handleType = handleType.MakeGenericMethod(extendedTypeInformation.Type);
                        if (handleType is null)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Unable to find handle method for type '{0}", extendedTypeInformation.TypeName);
                        }
                        _handleMethods.Add(extendedTypeInformation.TypeId, handleType);
                    }
                    handleType.Invoke(this, new object[] { declaration, result });
                    break;
            }
            return result;
        }
    }
}
