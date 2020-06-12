using BinaryAssetBuilder.Utility;
using System;

namespace BinaryAssetBuilder.Core
{
    // TODO:
    public class BinaryAsset
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(BinaryAsset), "Provides output management for assets");
        private static byte[] _copyBuffer = new byte[0x100000];

        private InstanceDeclaration _instance;
        private string _assetOutputDirectory;
        private string _customDataOutputDirectory;
        private AssetBuffer _buffer;
        private AssetHeader _assetHeader;

        public AssetBuffer Buffer
        {
            get => _buffer;
            set
            {
                _buffer = value;
                UpdateMemoryAvailability(true);
            }
        }
        public bool IsOutputAsset { get; set; }
        public string FileBase => _instance.Handle.FileBase;
        public InstanceDeclaration Instance { get; set; }
        public int InstanceFileSize
        {
            get
            {
                if (_assetHeader is null)
                {
                    UpdateAssetHeader(false);
                }
                return _assetHeader.InstanceDataSize;
            }
        }
        public int RelocationFileSize
        {
            get
            {
                if (_assetHeader is null)
                {
                    UpdateAssetHeader(false);
                }
                return _assetHeader.RelocationDataSize;
            }
        }
        public int ImportsFileSize
        {
            get
            {
                if (_assetHeader is null)
                {
                    UpdateAssetHeader(false);
                }
                return _assetHeader.ImportsDataSize;
            }
        }
        public string AssetOutputDirectory => _assetOutputDirectory;
        public string CustomDataOutputDirectory => _customDataOutputDirectory;

        private void UpdateMemoryAvailability(bool forceUpdate)
        {
            throw new NotImplementedException();
        }

        private void UpdateAssetHeader(bool forceUpdate)
        {
            throw new NotImplementedException();
        }

        public AssetLocation GetLocation(AssetLocation locationFilter, AssetLocationOption options)
        {
            throw new NotImplementedException();
        }

        public AssetLocation Commit()
        {
            throw new NotImplementedException();
        }
    }
}