using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Utility
{
    public class Asset
    {
        private readonly unsafe AssetStream.AssetEntry* _assetEntry;
        private readonly string[] _id;

        public ReferenceHandle[] ExternalReferences { get; }
        public string FileBasePath { get; }
        public string CDataPath { get; }
        public bool HasErrors { get; private set; }
        public string Source { get; }
        public string Message { get; private set; }
        public string TypeName => _id[0];
        public string InstanceName => _id[1];
        public int Index { get; }
        public unsafe uint TypeId => _assetEntry->TypeId;
        public unsafe uint InstanceId => _assetEntry->InstanceId;
        public unsafe uint TypeHash => _assetEntry->TypeHash;
        public unsafe uint InstanceHash => _assetEntry->InstanceHash;
        public unsafe int InstanceDataSize => _assetEntry->InstanceDataSize;
        public unsafe int RelocationDataSize => _assetEntry->RelocationDataSize;
        public unsafe int ImportsDataSize => _assetEntry->ImportsDataSize;
        public unsafe bool IsTokenized => _assetEntry->IsTokenized != 0u;
        public int LinkedInstanceOffset { get; }
        public int LinkedRelocationOffset { get; }
        public int LinkedImportsOffset { get; }
        public Manifest SourceManifest { get; }

        public unsafe Asset(int index,
                            string basePath,
                            AssetStream.AssetEntry* assetEntry,
                            sbyte* assetName,
                            sbyte* assetSource,
                            ReferenceHandle[] externalReferences,
                            Manifest sourceManifest,
                            int linkedInstanceOffset,
                            int linkedRelocationOffset,
                            int linkedImportsOffset)
        {
            _assetEntry = assetEntry;
            ExternalReferences = externalReferences;
            _id = Marshal.PtrToStringAnsi(new IntPtr((void*)assetName)).Split(':');
            HasErrors = false;
            Message = string.Empty;
            Source = new string(assetSource);
            Index = index;
            LinkedInstanceOffset = linkedInstanceOffset;
            LinkedRelocationOffset = linkedRelocationOffset;
            LinkedImportsOffset = linkedImportsOffset;
            SourceManifest = sourceManifest;
            string path = $"{_assetEntry->TypeId:x8}.{_assetEntry->TypeHash:x8}.{_assetEntry->InstanceId:x8}.{_assetEntry->InstanceHash:x8}";
            FileBasePath = Path.Combine(Path.Combine(basePath, "assets"), path);
            CDataPath = Path.Combine(Path.Combine(basePath, "cdata"), path + ".cdata");
            Update();
        }

        public void Update()
        {
            if (File.Exists(FileBasePath + ".asset"))
            {
                return;
            }
            HasErrors = true;
            Message += "Asset file missing. ";
        }

        public void Delete()
        {
            if (File.Exists(FileBasePath + ".asset"))
            {
                File.Delete(FileBasePath + ".asset");
            }
            Update();
        }
    }
}
