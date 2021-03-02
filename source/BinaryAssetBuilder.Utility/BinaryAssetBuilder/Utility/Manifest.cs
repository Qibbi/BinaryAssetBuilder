using AssetStream;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;

namespace BinaryAssetBuilder.Utility
{
    public class Manifest : IDisposable
    {
        private unsafe sbyte* _pBuffer;
        private unsafe AssetStream.ManifestHeader* _pHeader;
        private SortedDictionary<uint, string> _stringHashes;

        public unsafe bool IsLoaded => (IntPtr)_pBuffer != IntPtr.Zero;
        public Manifest PatchManifest { get; private set; }
        public ReferencedManifest[] ReferencedManifests { get; private set; }
        public string FileName { get; private set; }
        public Asset[] Assets { get; private set; }
        public unsafe bool IsBigEndian => (IntPtr)_pHeader != IntPtr.Zero && _pHeader->IsBigEndian;
        public unsafe bool IsLinked => (IntPtr)_pHeader != IntPtr.Zero && _pHeader->IsLinked;
        public unsafe int Version => (IntPtr)_pHeader != IntPtr.Zero ? _pHeader->Version : 0;
        public unsafe uint StreamChecksum => (IntPtr)_pHeader != IntPtr.Zero ? _pHeader->StreamChecksum : 0u;
        public unsafe uint AllTypesHash => (IntPtr)_pHeader != IntPtr.Zero ? _pHeader->AllTypesHash : 0u;
        public unsafe uint AssetCount => (IntPtr)_pHeader != IntPtr.Zero ? _pHeader->AssetCount : 0u;
        public unsafe uint TotalInstanceDataSize => (IntPtr)_pHeader != IntPtr.Zero ? _pHeader->TotalInstanceDataSize : 0u;
        public unsafe uint MaxInstanceChunkSize => (IntPtr)_pHeader != IntPtr.Zero ? _pHeader->MaxImportsChunkSize : 0u;
        public unsafe uint MaxRelocationChunkSize => (IntPtr)_pHeader != IntPtr.Zero ? _pHeader->MaxRelocationChunkSize : 0u;
        public unsafe uint MaxImportsChunkSize => (IntPtr)_pHeader != IntPtr.Zero ? _pHeader->MaxImportsChunkSize : 0u;
        public unsafe int ExternalReferenceBufferSize => (IntPtr)_pHeader != IntPtr.Zero ? (int)_pHeader->AssetReferenceBufferSize : 0;
        public unsafe int ExternalManifestNameBufferSize => (IntPtr)_pHeader != IntPtr.Zero ? (int)_pHeader->ReferenceManifestNameBufferSize : 0;
        public unsafe int AssetNameBufferSize => (IntPtr)_pHeader != IntPtr.Zero ? (int)_pHeader->AssetNameBufferSize : 0;
        public unsafe int SourceFileNameBufferSize => (IntPtr)_pHeader != IntPtr.Zero ? (int)_pHeader->SourceFileNameBufferSize : 0;

        public Manifest()
        {
            _stringHashes = new SortedDictionary<uint, string>();
            PatchManifest = null;
        }

        public static Manifest Create(string fileName)
        {
            Manifest result = new Manifest();
            return result.Load(fileName, null, true) ? result : null;
        }

        public static Manifest Create(string fileName, string[] patchSearchPaths)
        {
            Manifest result = new Manifest();
            return result.Load(fileName, patchSearchPaths, true) ? result : null;
        }

        public static Manifest Create(string fileName, string[] patchSearchPaths, bool validateAssets)
        {
            Manifest result = new Manifest();
            return result.Load(fileName, patchSearchPaths, validateAssets) ? result : null;
        }

        public static bool IsEquivalent(AssetEntry assetEntry, Asset asset)
        {
            return assetEntry.InstanceId == asset.InstanceId
                && assetEntry.InstanceHash == asset.InstanceHash
                && assetEntry.TypeId == asset.TypeId
                && (assetEntry.TypeHash == asset.TypeHash
#if !VERSION5
                    || asset.Tokenized
#endif
                    );
        }

        private unsafe void Free()
        {
            Assets = null;
            FileName = null;
            if ((IntPtr)_pBuffer == IntPtr.Zero)
            {
                return;
            }
            Marshal.FreeHGlobal((IntPtr)_pBuffer);
            _pBuffer = null;
        }

        public bool Reload()
        {
            return !string.IsNullOrEmpty(FileName) && Load(FileName, null, true);
        }

        public bool Load(string fileName)
        {
            return Load(fileName, null, true);
        }

        public bool Load(string fileName, string[] patchSearchPaths)
        {
            return Load(fileName, patchSearchPaths, true);
        }

        public bool Load(string fileName, bool validateAssets)
        {
            return Load(fileName, null, validateAssets);
        }

        public unsafe bool Load(string fileName, string[] patchSearchPaths, bool validateAssets)
        {
            Free();
            FileName = Path.GetFullPath(fileName);
            if (!File.Exists(FileName))
            {
                return false;
            }
            using (Stream stream = File.OpenRead(FileName))
            {
                uint length = (uint)stream.Length;
                _pBuffer = (sbyte*)Marshal.AllocHGlobal((int)length);
                byte[] buffer = new byte[length];
                stream.Read(buffer, 0, buffer.Length);
                fixed (byte* fpBuffer = &buffer[0])
                {
                    Native.MsVcRt.MemCpy((IntPtr)_pBuffer, (IntPtr)fpBuffer, new Native.SizeT(length));
                }
            }
            string basePath = Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileNameWithoutExtension(FileName));
            LoadStringHashes(basePath);
            sbyte* pBuffer = _pBuffer;
            _pHeader = (AssetStream.ManifestHeader*)_pBuffer;
            sbyte* assetEntries = pBuffer + 48;
            if (_pHeader->IsBigEndian)
            {
                _pHeader->Version = Endian.BigEndian(_pHeader->Version);
                _pHeader->StreamChecksum = Endian.BigEndian(_pHeader->StreamChecksum);
                _pHeader->AllTypesHash = Endian.BigEndian(_pHeader->AllTypesHash);
                _pHeader->AssetCount = Endian.BigEndian(_pHeader->AssetCount);
                _pHeader->TotalInstanceDataSize = Endian.BigEndian(_pHeader->TotalInstanceDataSize);
                _pHeader->MaxInstanceChunkSize = Endian.BigEndian(_pHeader->MaxInstanceChunkSize);
                _pHeader->MaxRelocationChunkSize = Endian.BigEndian(_pHeader->MaxRelocationChunkSize);
                _pHeader->MaxImportsChunkSize = Endian.BigEndian(_pHeader->MaxImportsChunkSize);
                _pHeader->AssetReferenceBufferSize = Endian.BigEndian(_pHeader->AssetReferenceBufferSize);
                _pHeader->ReferenceManifestNameBufferSize = Endian.BigEndian(_pHeader->ReferenceManifestNameBufferSize);
                _pHeader->AssetNameBufferSize = Endian.BigEndian(_pHeader->AssetNameBufferSize);
                _pHeader->SourceFileNameBufferSize = Endian.BigEndian(_pHeader->SourceFileNameBufferSize);
            }
#if VERSION5
            if (_pHeader->Version != 5)
#elif VERSION6
            if (_pHeader->Version != 6)
#endif
            {
                throw new ArgumentException("Can't read manifest. Unsupported file version");
            }
            Assets = new Asset[_pHeader->AssetCount];
            AssetStream.AssetEntry* currentAsset = (AssetStream.AssetEntry*)assetEntries;
            sbyte* assetReferenceBuffer = assetEntries + (_pHeader->AssetCount * sizeof(AssetStream.AssetEntry));
            sbyte* referenceManifestNameBuffer = assetReferenceBuffer + _pHeader->AssetReferenceBufferSize;
            sbyte* assetNameBuffer = referenceManifestNameBuffer + _pHeader->ReferenceManifestNameBufferSize;
            List<ReferencedManifest> referencedManifests = new List<ReferencedManifest>();
            string path;
            for (; referenceManifestNameBuffer < assetNameBuffer; referenceManifestNameBuffer += path.Length + 1)
            {
                bool isPatch = false;
                if (_pHeader->Version >= 4)
                {
                    if (*referenceManifestNameBuffer == 2)
                    {
                        isPatch = true;
                    }
                    ++referenceManifestNameBuffer;
                }
                path = new string(referenceManifestNameBuffer);
                referencedManifests.Add(new ReferencedManifest(path, isPatch));
            }
            ReferencedManifests = referencedManifests.ToArray();
            sbyte* sourceFileNameBuffer = assetNameBuffer + _pHeader->AssetNameBufferSize;
            int linkedInstanceOffset = 4;
            int linkedRelocationOffset = 4;
            int linkedImportsOffset = 4;
            int index = 0;
            while (index < AssetCount)
            {
                if (_pHeader->IsBigEndian)
                {
                    currentAsset->TypeId = Endian.BigEndian(currentAsset->TypeId);
                    currentAsset->InstanceId = Endian.BigEndian(currentAsset->InstanceId);
                    currentAsset->TypeHash = Endian.BigEndian(currentAsset->TypeHash);
                    currentAsset->InstanceHash = Endian.BigEndian(currentAsset->InstanceHash);
                    currentAsset->AssetReferenceOffset = Endian.BigEndian(currentAsset->AssetReferenceOffset);
                    currentAsset->AssetReferenceCount = Endian.BigEndian(currentAsset->AssetReferenceCount);
                    currentAsset->NameOffset = Endian.BigEndian(currentAsset->NameOffset);
                    currentAsset->SourceFileNameOffset = Endian.BigEndian(currentAsset->SourceFileNameOffset);
                    currentAsset->InstanceDataSize = Endian.BigEndian(currentAsset->InstanceDataSize);
                    currentAsset->RelocationDataSize = Endian.BigEndian(currentAsset->RelocationDataSize);
                    currentAsset->ImportsDataSize = Endian.BigEndian(currentAsset->ImportsDataSize);
                }
                ReferenceHandle[] externalReferences = new ReferenceHandle[currentAsset->AssetReferenceCount];
                AssetId* assetId = (AssetId*)(assetReferenceBuffer + currentAsset->AssetReferenceOffset);
                for (int idx = 0; idx < currentAsset->AssetReferenceCount; ++idx)
                {
                    if (_pHeader->IsBigEndian)
                    {
                        assetId->TypeId = Endian.BigEndian(assetId->TypeId);
                        assetId->InstanceId = Endian.BigEndian(assetId->InstanceId);
                    }
                    externalReferences[idx] = new ReferenceHandle
                    {
                        TypeId = assetId->TypeId,
                        InstanceId = assetId->InstanceId,
                        TypeName = StringFromHash(assetId->TypeId),
                        InstanceName = StringFromHash(assetId->InstanceId)
                    };
                    ReferenceHandle referenceHandle = externalReferences[idx];
                    externalReferences[idx].QualifiedName = $"{referenceHandle.TypeName}:{referenceHandle.InstanceName}";
                    ++assetId;
                }
                Asset asset = new Asset(index,
                                        basePath,
                                        currentAsset,
                                        assetNameBuffer + currentAsset->NameOffset,
                                        sourceFileNameBuffer + currentAsset->SourceFileNameOffset,
                                        externalReferences,
                                        this,
                                        linkedInstanceOffset,
                                        linkedRelocationOffset,
                                        linkedImportsOffset);
                Assets[index] = asset;
                if (validateAssets)
                {
                    Assets[index].Update();
                }
                linkedInstanceOffset += currentAsset->InstanceDataSize;
                linkedRelocationOffset += currentAsset->RelocationDataSize;
                linkedImportsOffset += currentAsset->ImportsDataSize;
                ++index;
                ++currentAsset;
            }
            List<string> fileNames = new List<string>
                {
                    Path.GetDirectoryName(fileName)
                };
            if (patchSearchPaths is not null)
            {
                foreach (string patchSearchPath in patchSearchPaths)
                {
                    fileNames.Add(patchSearchPath);
                }
            }
            Manifest patchManifest = null;
            foreach (ReferencedManifest referencedManifest in referencedManifests)
            {
                if (!referencedManifest.IsPatch)
                {
                    continue;
                }
                List<string>.Enumerator enumerator = fileNames.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string str = Path.Combine(enumerator.Current, referencedManifest.Path);
                    if (File.Exists(str))
                    {
                        patchManifest = new Manifest();
                        patchManifest.Load(str, patchSearchPaths);
                        break;
                    }
                }
                if (patchManifest is null)
                {
                    throw new ArgumentException($"Base patch manifest {referencedManifest.Path} does not exist.");
                }
            }
            if (patchManifest is not null)
            {
                SortedDictionary<AssetHandle, Asset> patchAssets = new SortedDictionary<AssetHandle, Asset>();
                foreach (Asset asset in patchManifest.Assets)
                {
                    patchAssets.Add(new AssetHandle(asset.TypeId, asset.InstanceId), asset);
                }
                for (int idx = 0; idx < Assets.Length; ++idx)
                {
                    Asset asset = Assets[idx];
                    if (asset.InstanceDataSize == 0 && asset.RelocationDataSize == 0 && asset.ImportsDataSize == 0)
                    {
                        if (patchAssets.TryGetValue(new AssetHandle(asset.TypeId, asset.InstanceId), out Asset patchAsset))
                        {
                            Assets[idx] = patchAsset;
                        }
                    }
                }
                PatchManifest = patchManifest;
            }
            return true;
        }

        public void LoadStringHashes(string basePath)
        {
            _stringHashes.Clear();
            string inputUri = string.Empty;
            for (; basePath is not null && basePath.Length > 3; basePath = Path.GetDirectoryName(basePath))
            {
                string path = Path.Combine(basePath, "StringHashes.xml");
                if (File.Exists(path))
                {
                    inputUri = path;
                    break;
                }
            }
            if (inputUri == string.Empty || !File.Exists(inputUri))
            {
                return;
            }
            XmlReader reader = XmlReader.Create(inputUri);
            try
            {
                while (reader.Read())
                {
                    if (reader.Name == "StringAndHash")
                    {
                        uint hash = Convert.ToUInt32(reader.GetAttribute("Hash"));
                        if (!_stringHashes.ContainsKey(hash))
                        {
                            _stringHashes.Add(hash, reader.GetAttribute("Text"));
                        }
                    }
                }
            }
            catch
            {
                _stringHashes.Clear();
            }
            reader.Close();
        }

        public int GetBaseStreamPosition(AssetEntry assetEntry)
        {
            for (int idx = 0; idx < Assets.Length; ++idx)
            {
                Asset asset = Assets[idx];
                if (IsEquivalent(assetEntry, asset))
                {
                    return idx;
                }
            }
            return -1;
        }

        public string StringFromHash(uint hash)
        {
            return !_stringHashes.TryGetValue(hash, out string result) ? hash.ToString("x8") : result;
        }

        public void Dispose()
        {
            Free();
        }
    }
}
