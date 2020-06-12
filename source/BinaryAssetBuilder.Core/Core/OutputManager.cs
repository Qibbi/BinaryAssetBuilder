using System;
using System.Collections.Generic;

namespace BinaryAssetBuilder.Core
{
    public class OutputManager
    {
        private IDictionary<string, BinaryAsset> _assets = new SortedDictionary<string, BinaryAsset>();

        public IDictionary<string, BinaryAsset> Assets => _assets;

        public BinaryAsset GetBinaryAsset(InstanceDeclaration instance, bool isOutputAsset)
        {
            throw new NotImplementedException();
        }

    }
}