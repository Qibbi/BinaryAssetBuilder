using BinaryAssetBuilder.Core.Xml;
using System.Xml;

namespace BinaryAssetBuilder.Project
{
    public class StreamConfiguration : ISerializable
    {
        private string[] _baseStreamSearchPaths;
        private StreamReference[] _streamReferences;
        private string _name;
        private bool _default;
        private string _patchStream;
        private string _relativeBasePath;

        public string[] BaseStreamSearchPaths { get => _baseStreamSearchPaths; set => _baseStreamSearchPaths = value; }
        public StreamReference[] StreamReferences { get => _streamReferences; set => _streamReferences = value; }
        public string Name { get => _name; set => _name = value; }
        public bool Default { get => _default; set => _default = value; }
        public string PatchStream { get => _patchStream; set => _patchStream = value; }
        public string RelativeBasePath { get => _relativeBasePath; set => _relativeBasePath = value; }

        public void ReadXml(Node node)
        {
            Marshaler.Marshal(node.GetChildNodes("BaseStreamSearchPath"), ref _baseStreamSearchPaths);
            Marshaler.Marshal(node.GetChildNodes(nameof(StreamReference)), ref _streamReferences);
            Marshaler.Marshal(node.GetAttributeValue(nameof(Name), string.Empty), ref _name);
            Marshaler.Marshal(node.GetAttributeValue(nameof(Default), "false"), ref _default);
            Marshaler.Marshal(node.GetAttributeValue(nameof(PatchStream), null), ref _patchStream);
            Marshaler.Marshal(node.GetAttributeValue(nameof(RelativeBasePath), null), ref _relativeBasePath);
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (string baseStreamSearchPath in _baseStreamSearchPaths)
            {
                writer.WriteElementString("BaseStreamSearchPath", baseStreamSearchPath);
            }
            foreach (StreamReference streamReference in _streamReferences)
            {
                writer.WriteStartElement(nameof(StreamReference));
                streamReference.WriteXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteAttributeString(nameof(Name), _name);
            writer.WriteAttributeString(nameof(Default), _default.ToString());
            writer.WriteAttributeString(nameof(PatchStream), _patchStream);
            writer.WriteAttributeString(nameof(RelativeBasePath), _relativeBasePath);
        }
    }
}
