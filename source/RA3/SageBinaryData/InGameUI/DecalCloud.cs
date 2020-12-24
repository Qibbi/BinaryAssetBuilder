using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIDecalCloudSettings
    {
        public AssetReference<Texture> BuildTexture;
        public AssetReference<Texture> DefenseTexture;
        public AssetReference<Texture> SpecialPowerRestrictionTexture;
    }
}
