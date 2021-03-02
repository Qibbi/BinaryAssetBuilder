using System;

namespace BinaryAssetBuilder.Core
{
    public class ExtendedTypeInformation
    {
        public string TypeName { get; set; }
        public uint TypeId { get; set; }
        public uint TypeHash { get; set; }
        public uint ProcessingHash { get; set; }
        public bool HasCustomData { get; set; }
        public bool Tokenized { get; set; }
        public bool UseBuildCache { get; set; }
        public Type Type { get; set; }
    }
}
