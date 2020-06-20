using BinaryAssetBuilder.Core;
using Relo;
using SageBinaryData;
using System;
using System.Xml;
using System.Xml.XPath;

namespace BinaryAssetBuilder.W3XCompiler
{
    public class Plugin : IAssetBuilderPlugin
    {
        private static readonly int _w3xPluginVersion = 8;
        private TargetPlatform _platform;

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
                buffer.RelocationData = new byte[0];
            }
            if (chunk.ImportsBuffer.Length > 0)
            {
                buffer.ImportsData = chunk.ImportsBuffer;
            }
            else
            {
                buffer.ImportsData = new byte[0];
            }
        }

        public void Initialize(object configObject, TargetPlatform targetPlatform)
        {
            _platform = targetPlatform;
        }

        public uint GetAllTypesHash()
        {
            // return 0x12B3E763u; // KW 1.02
            return 0xEB19D975u; // TW 1.09
        }

        public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
        {
            ExtendedTypeInformation result = new ExtendedTypeInformation
            {
                HasCustomData = false,
                TypeId = typeId
            };
            if (typeId == 0x2448AE30u)
            {
                result.Type = typeof(W3DAnimation);
                result.TypeName = nameof(W3DAnimation);
                result.ProcessingHash = 0xC55CB6D8u;
                result.TypeHash = 0xCC069193;
            }
            return result;
        }

        public unsafe AssetBuffer ProcessInstance(InstanceDeclaration declaration)
        {
            if (declaration.Handle.TypeId != 0x2448AE30u)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Unable to find handle method for asset '{0}", declaration);
            }
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
                        compressionSettings.MaxTranslationError = 0.001f; // 1.0f / 500.0f;
                        compressionSettings.MaxRotationError = 0.01f; // 3.0f / 1000.0f;
                        compressionSettings.MaxVisibilityError = 0.01f;
                        compressionSettings.MaxAdaptiveDeltaError = 0.03f; // 1.0f / 1000.0f;
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
                            srcFrames[idx].Values = new System.Collections.Generic.List<float> { scalarFrame->Value };
                            srcFrames[idx].BinaryMove = scalarFrame->BinaryMove;
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
                            srcFrames[idx].Values = new System.Collections.Generic.List<float>
                            {
                                quaternionFrame->Value.X,
                                quaternionFrame->Value.Y,
                                quaternionFrame->Value.Z,
                                quaternionFrame->Value.W
                            };
                            srcFrames[idx].BinaryMove = quaternionFrame->BinaryMove;
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
                if (compressedAdaptiveDelta is null || compressedTimecoded != null && compressedTimecoded.EstimateSize() < compressedAdaptiveDelta.EstimateSize())
                {
                    compressedTimecoded.WriteOut(trackerRuntime, (AnimationChannelTimecoded**)&animationRuntime->Channels.Items[currentChannel]);
                }
                else
                {
                    compressedAdaptiveDelta.WriteOut(trackerRuntime, (AnimationChannelDelta**)&animationRuntime->Channels.Items[currentChannel]);
                }
            }
            AssetBuffer result = new AssetBuffer();
            WriteAssetBuffer(result, trackerRuntime);
            return result;
        }
    }
}
