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
        private readonly IDictionary<uint, string> _stringHashes;

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

        public static bool IsEquivalent(AssetEntry assetEntry, Asset asset)
        {
            return assetEntry.InstanceId == asset.InstanceId
                && assetEntry.InstanceHash == asset.InstanceHash
                && assetEntry.TypeId == asset.TypeId
                && (assetEntry.TypeHash == asset.TypeHash
                || asset.IsTokenized);
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

        public bool Load(string fileName)
        {
            return Load(fileName, null, true);
        }

        public bool Load(string fileName, string[] patchSearchPaths)
        {
            return Load(fileName, patchSearchPaths, true);
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
                _pHeader->Version = EA.Endian.BigEndian(_pHeader->Version);
                _pHeader->StreamChecksum = EA.Endian.BigEndian(_pHeader->StreamChecksum);
                _pHeader->AllTypesHash = EA.Endian.BigEndian(_pHeader->AllTypesHash);
                _pHeader->AssetCount = EA.Endian.BigEndian(_pHeader->AssetCount);
                _pHeader->TotalInstanceDataSize = EA.Endian.BigEndian(_pHeader->TotalInstanceDataSize);
                _pHeader->MaxInstanceChunkSize = EA.Endian.BigEndian(_pHeader->MaxInstanceChunkSize);
                _pHeader->MaxRelocationChunkSize = EA.Endian.BigEndian(_pHeader->MaxRelocationChunkSize);
                _pHeader->MaxImportsChunkSize = EA.Endian.BigEndian(_pHeader->MaxImportsChunkSize);
                _pHeader->AssetReferenceBufferSize = EA.Endian.BigEndian(_pHeader->AssetReferenceBufferSize);
                _pHeader->ReferenceManifestNameBufferSize = EA.Endian.BigEndian(_pHeader->ReferenceManifestNameBufferSize);
                _pHeader->AssetNameBufferSize = EA.Endian.BigEndian(_pHeader->AssetNameBufferSize);
                _pHeader->SourceFileNameBufferSize = EA.Endian.BigEndian(_pHeader->SourceFileNameBufferSize);
            }
            if (_pHeader->Version < 4)
            {
                throw new ArgumentException("Can't read manifest. Unsupported file version");
            }
            Assets = new Asset[_pHeader->AssetCount];
            AssetStream.AssetEntry* currentAsset = (AssetStream.AssetEntry*)assetEntries;
            sbyte* ptr3 = assetEntries + (_pHeader->AssetCount * sizeof(AssetStream.AssetEntry));
            sbyte* ptr4 = ptr3;
            sbyte* referenceManifestNameBuffer = ptr3 + _pHeader->AssetReferenceBufferSize;
            sbyte* referenceManifestNameBufferPosition = referenceManifestNameBuffer;
            sbyte* ptr7 = referenceManifestNameBuffer + _pHeader->ReferenceManifestNameBufferSize;
            List<ReferencedManifest> referencedManifests = new List<ReferencedManifest>();
            string path;
            for (; referenceManifestNameBufferPosition < ptr7; referenceManifestNameBufferPosition += path.Length + 1)
            {
                bool isPatch = false;
                if (_pHeader->Version >= 4)
                {
                    if (*referenceManifestNameBufferPosition == 2)
                    {
                        isPatch = true;
                    }
                    ++referenceManifestNameBufferPosition;
                }
                path = new string(referenceManifestNameBufferPosition);
                referencedManifests.Add(new ReferencedManifest(path, isPatch));
            }
            ReferencedManifests = referencedManifests.ToArray();
            sbyte* ptr8 = ptr7;
            sbyte* ptr9 = ptr7 + _pHeader->AssetNameBufferSize;
            int linkedInstanceOffset = 4;
            int linkedRelocationOffset = 4;
            int linkedImportsOffset = 4;
            int index = 0;
            while (index < AssetCount)
            {
                if (_pHeader->IsBigEndian)
                {
                    currentAsset->TypeId = EA.Endian.BigEndian(currentAsset->TypeId);
                    currentAsset->InstanceId = EA.Endian.BigEndian(currentAsset->InstanceId);
                    currentAsset->TypeHash = EA.Endian.BigEndian(currentAsset->TypeHash);
                    currentAsset->InstanceHash = EA.Endian.BigEndian(currentAsset->InstanceHash);
                    currentAsset->AssetReferenceOffset = EA.Endian.BigEndian(currentAsset->AssetReferenceOffset);
                    currentAsset->AssetReferenceCount = EA.Endian.BigEndian(currentAsset->AssetReferenceCount);
                    currentAsset->NameOffset = EA.Endian.BigEndian(currentAsset->NameOffset);
                    currentAsset->SourceFileNameOffset = EA.Endian.BigEndian(currentAsset->SourceFileNameOffset);
                    currentAsset->InstanceDataSize = EA.Endian.BigEndian(currentAsset->InstanceDataSize);
                    currentAsset->RelocationDataSize = EA.Endian.BigEndian(currentAsset->RelocationDataSize);
                    currentAsset->ImportsDataSize = EA.Endian.BigEndian(currentAsset->ImportsDataSize);
                    currentAsset->IsTokenized = EA.Endian.BigEndian(currentAsset->IsTokenized);
                }
                ReferenceHandle[] externalReferences = new ReferenceHandle[currentAsset->AssetReferenceCount];
                AssetId* assetId = (AssetId*)(ptr4 + currentAsset->AssetReferenceOffset);
                for (int idx = 0; idx < currentAsset->AssetReferenceCount; ++idx)
                {
                    if (_pHeader->IsBigEndian)
                    {
                        assetId->TypeId = EA.Endian.BigEndian(assetId->TypeId);
                        assetId->InstanceId = EA.Endian.BigEndian(assetId->InstanceId);
                    }
                    externalReferences[idx] = new ReferenceHandle
                    {
                        TypeId = assetId->TypeId,
                        InstanceId = assetId->InstanceId,
                        TypeName = StringFromHash(assetId->TypeId),
                        InstanceName = StringFromHash(assetId->InstanceId)
                    };
                    externalReferences[idx].QualifiedName = $"{externalReferences[idx].TypeName}:{externalReferences[idx].InstanceName}";
                    ++assetId;
                }
                Asset asset = new Asset(index,
                                        basePath,
                                        currentAsset,
                                        ptr8 + currentAsset->NameOffset,
                                        ptr9 + currentAsset->SourceFileNameOffset,
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
            if (patchSearchPaths != null)
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
                        patchManifest.Load(str, patchSearchPaths, validateAssets);
                        break;
                    }
                }
                if (patchManifest is null)
                {
                    throw new ArgumentException($"Base patch manifest {referencedManifest.Path} does not exist.");
                }
            }
            if (patchManifest != null)
            {
                IDictionary<AssetHandle, Asset> patchAssets = new SortedDictionary<AssetHandle, Asset>();
                foreach (Asset asset in patchManifest.Assets)
                {
                    patchAssets.Add(new AssetHandle(asset.TypeId, asset.InstanceId), asset);
                }
                for (int idx = 0; idx < Assets.Length; ++idx)
                {
                    Asset asset = Assets[idx];
                    if (asset.InstanceDataSize != 0 || asset.RelocationDataSize != 0 || asset.ImportsDataSize != 0)
                    {
                        continue;
                    }
                    if (patchAssets.TryGetValue(new AssetHandle(asset.TypeId, asset.InstanceId), out Asset patchAsset))
                    {
                        Assets[idx] = patchAsset;
                    }
                }
                PatchManifest = patchManifest;
            }
            return true;
        }

        public bool Reload()
        {
            return !string.IsNullOrEmpty(FileName) && Load(FileName, null, true);
        }

        public void LoadStringHashes(string basePath)
        {
            _stringHashes.Clear();
            string inputUri = string.Empty;
            for (; basePath != null && basePath.Length > 3; basePath = Path.GetDirectoryName(basePath))
            {
                string path = Path.Combine(basePath, "StringHashes.xml");
                if (File.Exists(path))
                {
                    inputUri = path;
                    break;
                }
            }
            if (inputUri == string.Empty)
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
                        _stringHashes.Add(Convert.ToUInt32(reader.GetAttribute("Hash")), reader.GetAttribute("Text"));
                    }
                }
            }
            catch
            {
                _stringHashes.Clear();
            }
            reader.Close();
        }

        public string StringFromHash(uint hash)
        {
            return !_stringHashes.TryGetValue(hash, out string result) ? hash.ToString("x8") : result;
        }

        public int GetBaseStreamPosition(AssetEntry assetEntry)
        {
            Asset[] assets = Assets;
            for (int idx = 0; idx < assets.Length; ++idx)
            {
                if (IsEquivalent(assetEntry, assets[idx]))
                {
                    return idx;
                }
            }
            return -1;
        }

        public void Dispose()
        {
            Free();
        }
    }
}
