using BinaryAssetBuilder.Core.Hashing;
using BinaryAssetBuilder.Core.IO;
using BinaryAssetBuilder.Core.Xml;
using System;
using System.IO;
using System.Xml;

namespace BinaryAssetBuilder.Core
{
    public class FileHashItem : ISerializable
    {
        public delegate void KeepAliveDelegate();

        public static KeepAliveDelegate KeepAlive;

        private string _path;
        private string _buildConfiguration;
        private TargetPlatform _targetPlatform;
        private FileState _state;
        private uint _hash;
        private DateTime _lastDate = DateTime.MinValue;
        private DateTime _currentDate = DateTime.MaxValue;
        private bool _exists;

        public string Path => _path;
        public string BuildConfiguration => _buildConfiguration;
        public TargetPlatform TargetPlatform => _targetPlatform;
        public bool Exists
        {
            get
            {
                if (_state < FileState.ExistsValid)
                {
                    _exists = File.Exists(_path);
                    _state = FileState.ExistsValid;
                }
                return _exists;
            }
        }
        public bool IsDirty
        {
            get
            {
                if (_state < FileState.DateValid)
                {
                    if (Exists)
                    {
                        _currentDate = File.GetLastWriteTime(_path);
                    }
                    _state = FileState.DateValid;
                }
                return _lastDate != _currentDate;
            }
        }
        public uint Hash
        {
            get
            {
                if (_state < FileState.HashValid)
                {
                    if (IsDirty)
                    {
                        if (Exists)
                        {
                            UpdateHash();
                        }
                        else
                        {
                            _hash = 0u;
                        }
                    }
                    _state |= FileState.HashValid;
                }
                return _hash;
            }
        }

        public FileHashItem()
        {
        }

        public FileHashItem(string path, string configuration, TargetPlatform platform)
        {
            _path = path;
            _buildConfiguration = configuration;
            _targetPlatform = platform;
        }

        private void UpdateHash()
        {
            AsynchronousFileReader asynchronousFileReader = new AsynchronousFileReader(_path);
            uint hash = asynchronousFileReader.FileSize;
            while (asynchronousFileReader.BeginRead())
            {
                hash = FastHash.GetHashCode(hash, asynchronousFileReader.CurrentChunk.Data, asynchronousFileReader.CurrentChunk.BytesRead);
                asynchronousFileReader.EndRead();
            }
            _hash = hash;
            _lastDate = _currentDate;
        }

        public void Reset()
        {
            _state = FileState.AllInvalid;
            _currentDate = DateTime.MaxValue;
        }

        public void ReadXml(Node node)
        {
            string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
            _path = values[0];
            _hash = Convert.ToUInt32(values[1]);
            _lastDate = DateTime.FromBinary(Convert.ToInt64(values[2]));
            if (values.Length > 3)
            {
                _buildConfiguration = values[3];
                _targetPlatform = values.Length <= 4 ? TargetPlatform.Win32 : Enum.Parse<TargetPlatform>(values[4]);
            }
            else
            {
                _buildConfiguration = string.Empty;
                _targetPlatform = TargetPlatform.Win32;
            }
            _currentDate = DateTime.MaxValue;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("d", $"{_path};{_hash};{_lastDate.ToBinary()};{_buildConfiguration};{_targetPlatform}");
        }
    }
}
