using BinaryAssetBuilder.Core;
using System.Xml;

namespace BinaryAssetBuilder.GameDataVerifier
{
    internal class Plugin : IAssetBuilderVerifierPlugin
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(GameDataVerifier), "Verifies that Sage RTS data is logic correct");
        private XmlNamespaceManager _namespaceManager;

        private bool VerifyGameObject(string gameObjectId, string srcFile, XmlNode node)
        {
            bool result = true;
            XmlNodeList nodes = node.SelectNodes("ea:Behaviors/* | ea:Draws/* | ea:AI/* | ea:Body/*", _namespaceManager);
            Set<string> set = new Set<string>();
            foreach (XmlNode xmlNode in nodes)
            {
                XmlAttribute attribute = xmlNode.Attributes["id"];
                if (attribute is null || attribute.Value == string.Empty)
                {
                    _tracer.TraceError("GameObject {0} has an unnamed module {1} in file {2}", gameObjectId, xmlNode.Name, srcFile);
                    result = false;
                }
                else
                {
                    string lower = attribute.Value.ToLower();
                    if (set.Contains(lower))
                    {
                        _tracer.TraceError("GameObject {0} has 2 modules with the name {1} in file {2}", gameObjectId, attribute.Value, srcFile);
                        result = false;
                    }
                    else
                    {
                        set.Add(lower);
                    }
                }
            }
            return result;
        }

        public void Initialize(object configObject, TargetPlatform targetPlatform)
        {
        }

        public void ReInitialize(object configObject, TargetPlatform targetPlatform)
        {
        }

        public bool VerifyInstance(InstanceDeclaration instance)
        {
            _namespaceManager = instance.Document.NamespaceManager;
            switch (instance.Node.Name)
            {
                case "GameObject":
                    return VerifyGameObject(instance.Node.Attributes["id"].Value, instance.Document.SourcePath, instance.Node);
                default:
                    return true;
            }
        }
    }
}
