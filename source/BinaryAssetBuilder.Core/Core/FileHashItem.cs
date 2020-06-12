using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class FileHashItem : IXmlSerializable
    {
        public delegate void KeepAliveDelegate();

        public static KeepAliveDelegate KeepAlive;

        private DateTime _lastDate = DateTime.MinValue;
        private string _path;
        private string _buildConfiguration;
        private TargetPlatform _targetPlatform;
        [NonSerialized] private FileState _state;
        private uint _hash;
        [NonSerialized] private bool _exists;

        [NonSerialized] public DateTime CurrentDate = DateTime.MaxValue;
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
                        CurrentDate = File.GetLastWriteTime(_path);
                    }
                    _state = FileState.DateValid;
                }
                return _lastDate != CurrentDate;
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

        public FileHashItem(string path, string configuration, TargetPlatform targetPlatform)
        {
            _path = path;
            _buildConfiguration = configuration;
            _targetPlatform = targetPlatform;
        }

        private void UpdateHash()
        {
            if (_path is null)
            {
                return;
            }
            AsynchronousFileReader asynchronousFileReader = new AsynchronousFileReader(_path);
            uint hash = asynchronousFileReader.FileSize;
            while (asynchronousFileReader.BeginRead())
            {
                if (asynchronousFileReader.CurrentChunk != null && asynchronousFileReader.CurrentChunk.Data != null)
                {
                    hash = FastHash.GetHashCode(hash, asynchronousFileReader.CurrentChunk.Data, asynchronousFileReader.CurrentChunk.BytesRead);
                }
                asynchronousFileReader.EndRead();
            }
            _hash = hash;
            _lastDate = CurrentDate;
        }

        public void Reset()
        {
            _state = FileState.AllInvalid;
            CurrentDate = DateTime.MaxValue;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToAttribute("d");
            string[] values = reader.Value.Split(';');
            _path = values[0];
            _hash = Convert.ToUInt32(values[1]);
            _lastDate = DateTime.FromBinary(Convert.ToInt64(values[2]));
            if (values.Length > 3)
            {
                _targetPlatform = values.Length <= 4 ? TargetPlatform.Win32 : (TargetPlatform)int.Parse(values[4]);
                _buildConfiguration = values[3];
            }
            else
            {
                _buildConfiguration = string.Empty;
                _targetPlatform = TargetPlatform.Win32;
            }
            CurrentDate = DateTime.MaxValue;
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("hi");
            writer.WriteAttributeString("d", $"{_path};{_hash};{_lastDate.ToBinary()};{_buildConfiguration};{(int)_targetPlatform}");
            writer.WriteEndElement();
        }
    }
}