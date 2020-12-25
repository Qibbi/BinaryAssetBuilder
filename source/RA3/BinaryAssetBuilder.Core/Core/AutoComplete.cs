using System;

namespace BinaryAssetBuilder.Core
{
    [Flags]
    public enum AutoComplete : uint
    {
        Default = 0,
        Filesystem = 1 << 0,
        UrlHistory = 1 << 1,
        UrlMru = 1 << 2,
        UrlAll = UrlHistory | UrlMru,
        UseTab = 1 << 3,
        FileSystemOnly = 1 << 4,
        FileSystemDirectories = 1 << 5,
        AutoSuggestForceOn = 1 << 28,
        AutoSuggestForceOff = 1 << 29,
        AutoAppendForceOn = 1 << 30,
        AutoAppendForceOff = 1u << 31
    }
}
