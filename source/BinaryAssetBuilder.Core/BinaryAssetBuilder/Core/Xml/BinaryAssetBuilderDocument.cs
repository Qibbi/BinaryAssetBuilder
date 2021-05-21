using BinaryAssetBuilder.Core.Hashing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace BinaryAssetBuilder.Core.Xml
{
    public class BinaryAssetBuilderDocument
    {
        public const string XmlRootName = "BinaryAssetBuilder";
        public const string XmlNamespace = "uri:binaryassetbuilder.bab";

        private readonly Dictionary<uint, List<XmlNode>> _nodes = new Dictionary<uint, List<XmlNode>>();
        private XmlDocument _document;
        private XmlNamespaceManager _namespaceManager;

        public BinaryAssetBuilderDocument(string path)
        {
            LoadXml(path);
        }

        public BinaryAssetBuilderDocument(Stream stream, XmlReaderSettings settings = null)
        {
            LoadXml(XmlReader.Create(stream, settings ?? new XmlReaderSettings()));
        }

        public static void WriteXml(Stream stream, string name, Action<XmlWriter> writeCallback, string id = null)
        {
            using XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                IndentChars = "    "
            });
            writer.WriteStartDocument();
            writer.WriteStartElement(XmlRootName, XmlNamespace);
            writer.WriteStartElement(name);
            if (id is not null)
            {
                writer.WriteAttributeString("id", id);
            }
            writeCallback(writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
        }

        public static void Writexml(string path, string name, Action<XmlWriter> writeCallback, string id = null)
        {
            using Stream stream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
            WriteXml(stream, name, writeCallback, id);
        }

        private void NodeInsertedHandler(object sender, XmlNodeChangedEventArgs args)
        {
            uint typeId = HashProvider.GetCaseSensitiveSymbolHash(args.Node.Name);
            if (!_nodes.TryGetValue(typeId, out List<XmlNode> nodes))
            {
                nodes = new List<XmlNode>();
                _nodes.Add(typeId, nodes);
            }
            nodes.Add(args.Node);
        }

        private void LoadXml(XmlReader reader)
        {
            if (_document is not null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Document attempted to load twice.");
            }
            _document = new XmlDocument();
            _document.NodeInserted += NodeInsertedHandler;
            _document.Load(reader);
            _document.NodeInserted -= NodeInsertedHandler;
            _namespaceManager = new XmlNamespaceManager(reader.NameTable);
            _namespaceManager.AddNamespace("ea", XmlNamespace);
            _namespaceManager.AddNamespace("babproj", "urn:xmlns:ea.com:babproject");
            _namespaceManager.AddNamespace("ms", "urn:schemas-microsoft-com:xslt");
        }

        private void LoadXml(string path)
        {
            if (_document is not null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Document '{0}' attempted to load twice.", path);
            }
            XmlReader reader;
            if (File.Exists(path))
            {
                reader = XmlReader.Create(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read), new XmlReaderSettings { CloseInput = true });
            }
            else
            {
                reader = XmlReader.Create(new StringReader($"<?xml version='1.0' encoding='utf-8'?>\n\r<{XmlRootName} xmlns=\"{XmlNamespace}\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n\r</{XmlRootName}>"));
            }
            try
            {
                LoadXml(reader);
            }
            finally
            {
                reader.Close();
            }
        }

        public Node GetNode(string typeId, string instanceId = null)
        {
            if (!_nodes.TryGetValue(HashProvider.GetCaseSensitiveSymbolHash(typeId), out List<XmlNode> nodes))
            {
                return null;
            }
            if (instanceId is null)
            {
                return new Node(nodes[0].CreateNavigator(), _namespaceManager);
            }
            uint id = HashProvider.GetCaseSensitiveSymbolHash(instanceId);
            foreach (XmlNode node in nodes)
            {
                Node result = new Node(node.CreateNavigator(), _namespaceManager);
                uint resultId = HashProvider.GetCaseInsensitiveSymbolHash(result.GetAttributeValue("id", string.Empty).GetText());
                if (resultId == id)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
