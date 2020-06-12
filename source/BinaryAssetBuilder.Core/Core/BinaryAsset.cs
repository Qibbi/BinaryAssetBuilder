using BinaryAssetBuilder.Utility;
using System;

namespace BinaryAssetBuilder.Core
{
    // TODO:
    public class BinaryAsset
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(BinaryAsset), "Provides output management for assets");

        private AssetHeader _assetHeader;

        public bool IsOutputAsset { get; set; }
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

        private void UpdateAssetHeader(bool forceUpdate)
        {
            throw new NotImplementedException();
        }

        public AssetLocation GetLocation(AssetLocation locationFilter, AssetLocationOption options)
        {
            throw new NotImplementedException();
        }
    }
}