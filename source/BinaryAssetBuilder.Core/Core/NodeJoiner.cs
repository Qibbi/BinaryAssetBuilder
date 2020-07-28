using System;
using System.Xml;
using System.Xml.Schema;

namespace BinaryAssetBuilder.Core
{
    public class NodeJoiner
    {
        private enum JoinAction
        {
            Append = 0,
            Overwrite = 1,
            Override = Overwrite,
            Replace = Overwrite,
            Remove = 2
        }

        private enum InsertPosition
        {
            Top,
            Bottom
        }

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(NodeJoiner), "Joins XML Nodes, for inheritance and overriding");

        private readonly XmlDocument _document;
        private readonly XmlSchemaSet _schema;

        public NodeJoiner(XmlSchemaSet docSchema, XmlDocument document)
        {
            _schema = docSchema;
            _document = document;
        }

        public static XmlNode Override(XmlSchemaSet docSchema, XmlDocument document, XmlNode baseNode, XmlNode overrideNode)
        {
            XmlNode node = document.CreateNode(baseNode.NodeType, baseNode.Name, baseNode.NamespaceURI);
            NodeJoiner joiner = new NodeJoiner(docSchema, document);
            JoinAction joinAction = JoinAction.Append;
            joiner.GetJoinAction(overrideNode, ref joinAction);
            switch (joinAction)
            {
                case JoinAction.Append:
                    joiner.ReplaceXmlNode(node, baseNode, null, false, JoinAction.Append);
                    break;
                case JoinAction.Remove:
                    string str = overrideNode.Attributes.GetNamedItem("id") is XmlAttribute namedItem ? namedItem.Value : "<Unknown id>";
                    _tracer.TraceError("Removal of top-level asset is not supported, in {0}:{1} ({2})", overrideNode.Name, str, overrideNode.OwnerDocument.BaseURI);
                    break;
            }
            joiner.ReplaceXmlNode(node, overrideNode, null, false, joinAction);
            return node;
        }

        private XmlNode SelectMatchingKey(XmlNode destNode, XmlNode srcNode)
        {
            if (destNode.Attributes != null && srcNode.Attributes != null)
            {
                if (srcNode.Attributes.GetNamedItem("id") is XmlAttribute srcId && destNode.Attributes.GetNamedItem("id") is XmlAttribute destId && srcId.Value == destId.Value)
                {
                    return destNode;
                }
            }
            return null;
        }

        private XmlNode SelectSame(XmlNode destParent, XmlNode srcChild, bool idMatchRequired, bool replaceAny)
        {
            if (destParent.ChildNodes is null)
            {
                return null;
            }
            if (idMatchRequired)
            {
                foreach (XmlNode childNode in destParent.ChildNodes)
                {
                    XmlNode xmlNode = SelectMatchingKey(childNode, srcChild);
                    if (xmlNode != null)
                    {
                        return xmlNode;
                    }
                }
            }
            else
            {
                if (replaceAny && destParent.ChildNodes.Count == 1)
                {
                    return destParent.ChildNodes[0];
                }
                foreach (XmlNode childNode in destParent.ChildNodes)
                {
                    if (childNode.Name == srcChild.Name)
                    {
                        return childNode;
                    }
                }
            }
            return null;
        }

        private bool FindPrevNode(XmlSchemaComplexType complex, XmlNode node, XmlSchemaElement element)
        {
            if (complex.BaseXmlSchemaType != null && complex.BaseXmlSchemaType is XmlSchemaComplexType baseType && FindPrevNode(baseType, node, element))
            {
                return true;
            }
            if (!(complex.ContentTypeParticle is XmlSchemaSequence particle) || particle.Items is null)
            {
                return false;
            }
            foreach (XmlSchemaParticle schemaParticle in particle.Items)
            {
                if (schemaParticle is XmlSchemaElement schemaElement && node.Name == schemaElement.Name)
                {
                    return true;
                }
                if (element == schemaParticle)
                {
                    return false;
                }
            }
            return false;
        }

        private XmlSchemaElement FindInBase(XmlSchemaComplexType complex, XmlQualifiedName childName)
        {
            if (complex.BaseXmlSchemaType != null && complex.BaseXmlSchemaType is XmlSchemaComplexType baseType)
            {
                XmlSchemaElement inBase = FindInBase(baseType, childName);
                if (inBase != null)
                {
                    return inBase;
                }
            }
            if (!(complex.ContentTypeParticle is XmlSchemaSequence particle) || particle.Items is null)
            {
                return null;
            }
            foreach (XmlSchemaParticle schemaParticle in particle.Items)
            {
                if (schemaParticle is XmlSchemaElement element && element.QualifiedName == childName)
                {
                    return element;
                }
            }
            return null;
        }

        private XmlNode AppendCorrespondedXmlNode(XmlNode parentNode, XmlNode srcChild, XmlSchemaElement element, XmlSchemaComplexType parentType, InsertPosition insertPosition)
        {
            XmlNode node = _document.CreateNode(srcChild.NodeType, srcChild.Name, srcChild.NamespaceURI);
            if (element != null && element.Parent is XmlSchemaSequence && parentNode.HasChildNodes)
            {
                XmlNode refChild = null;
                bool inserted = false;
                foreach (XmlNode childNode in parentNode.ChildNodes)
                {
                    if (childNode.LocalName == element.Name)
                    {
                        if (insertPosition == InsertPosition.Bottom)
                        {
                            refChild = childNode;
                            inserted = true;
                        }
                        else
                        {
                            refChild = null;
                            break;
                        }
                    }
                    else if (!inserted)
                    {
                        if (parentType != null && FindPrevNode(parentType, childNode, element))
                        {
                            refChild = childNode;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                parentNode.InsertAfter(node, refChild);
            }
            else if (insertPosition == InsertPosition.Bottom)
            {
                parentNode.AppendChild(node);
            }
            else
            {
                parentNode.InsertAfter(node, null);
            }
            return node;
        }

        private void GetJoinAction(XmlNode node, ref JoinAction joinAction)
        {
            XmlAttribute attribute = node.Attributes[nameof(joinAction), "uri:ea.com:eala:asset:instance"];
            if (attribute is null)
            {
                return;
            }
            try
            {
                joinAction = (JoinAction)Enum.Parse(typeof(JoinAction), attribute.Value, true);
            }
            catch (Exception ex)
            {
                throw new BinaryAssetBuilderException(ex,
                                                      ErrorCode.SchemaValidation,
                                                      "{0} not valid for joinAction, in {1}. Valid values: Append, Replace, Remove",
                                                      attribute.Value,
                                                      node.Name);
            }
        }

        private void GetInsertPosition(XmlNode node, ref InsertPosition insertPosition)
        {
            XmlAttribute attribute = node.Attributes[nameof(insertPosition), "uri:ea.com:eala:asset:instance"];
            if (attribute is null)
            {
                return;
            }
            try
            {
                insertPosition = (InsertPosition)Enum.Parse(typeof(InsertPosition), attribute.Value, true);
            }
            catch (Exception ex)
            {
                throw new BinaryAssetBuilderException(ex,
                                                      ErrorCode.SchemaValidation,
                                                      "{0} nod valid for insertPosition, in {1}. Valid values: Top, Bottom",
                                                      attribute.Value,
                                                      node.Name);
            }
        }

        private void ReplaceXmlNode(XmlNode dest, XmlNode src, XmlSchemaParticle parent, bool parentsMatch, JoinAction parentJoinAction)
        {
            if (src.ChildNodes != null && src.ChildNodes.Count != 0)
            {
                XmlSchemaObject objectType = GetObjectType(src, parent);
                if (objectType is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.SchemaValidation, "The element {0} is not expected in {1}", src.Name, src.ParentNode.Name);
                }
                foreach (XmlNode childNode in src.ChildNodes)
                {
                    XmlQualifiedName childName = new XmlQualifiedName(childNode.Name, childNode.NamespaceURI);
                    switch (childNode)
                    {
                        case XmlDeclaration _:
                        case XmlComment _:
                            continue;
                        case XmlText _:
                            XmlNode node = _document.CreateNode(childNode.NodeType, childNode.Name, childNode.NamespaceURI);
                            node.Value = childNode.Value;
                            dest.AppendChild(node);
                            continue;
                        default:
                            if (!(objectType is XmlSchemaComplexType complex))
                            {
                                throw new BinaryAssetBuilderException(ErrorCode.XmlFormattingError, "The element {0} is not expected in {1}", src.Name, src.ParentNode.Name);
                            }
                            XmlSchemaElement inBase = FindInBase(complex, childName);
                            bool isSequence = complex.ContentTypeParticle is XmlSchemaSequence;
                            bool isChoice = complex.ContentTypeParticle is XmlSchemaChoice;
                            if (inBase is null && isSequence)
                            {
                                throw new BinaryAssetBuilderException(ErrorCode.XmlFormattingError, "Bad XML: unexpected {0} in {1}", childNode.Name, complex.Name);
                            }
                            bool replaceAny = isChoice && complex.ContentTypeParticle.MaxOccurs <= new decimal(1);
                            bool idMatchRequired = (isSequence && inBase.MaxOccurs > new decimal(1)) || (isChoice && complex.ContentTypeParticle.MaxOccurs > new decimal(1));
                            XmlNode xmlNode = SelectSame(dest, childNode, idMatchRequired, replaceAny);
                            bool isMatch = parentsMatch || xmlNode != null;
                            JoinAction joinAction = parentJoinAction;
                            GetJoinAction(childNode, ref joinAction);
                            InsertPosition insertPosition = InsertPosition.Bottom;
                            GetInsertPosition(childNode, ref insertPosition);
                            string srcId = src.Attributes.GetNamedItem("id") is XmlAttribute srcItem ? srcItem.Value : "<Unknown id>";
                            string childId = childNode.Attributes.GetNamedItem("id") is XmlAttribute childItem ? childItem.Value : "<Unknown id>";
                            if (xmlNode != null)
                            {
                                if (new XmlQualifiedName(xmlNode.Name, xmlNode.NamespaceURI) != childName || joinAction == JoinAction.Remove || joinAction == JoinAction.Overwrite)
                                {
                                    dest.RemoveChild(xmlNode);
                                    xmlNode = null;
                                }
                            }
                            else if (joinAction == JoinAction.Remove)
                            {
                                _tracer.TraceWarning("{0}:{1} in {2}:{3} attempts to remove non-existent node", childNode.Name, childId, src.Name, srcId);
                            }
                            if (joinAction != JoinAction.Remove)
                            {
                                if (xmlNode is null)
                                {
                                    xmlNode = AppendCorrespondedXmlNode(dest, childNode, inBase, complex, insertPosition);
                                }
                                ReplaceXmlNode(xmlNode, childNode, complex.ContentTypeParticle, isMatch, joinAction);
                                continue;
                            }
                            continue;
                    }
                }
            }
            if (src.Value != null)
            {
                dest.Value = src.Value;
            }
            if (src.Attributes is null)
            {
                return;
            }
            foreach (XmlAttribute attribute in src.Attributes)
            {
                if (!(attribute.NamespaceURI == "xmlns")
                 && !(attribute.LocalName == "xmlns")
                 && !(attribute.LocalName == "TypeId")
                 && (!(attribute.NamespaceURI == "uri:ea.com:eala:asset:instance") || (!(attribute.LocalName == "insertPosition") && !(attribute.LocalName == "joinAction"))))
                {
                    XmlAttribute destAttribute = dest.Attributes[attribute.LocalName];
                    if (destAttribute is null)
                    {
                        destAttribute = _document.CreateAttribute(attribute.Name, attribute.NamespaceURI);
                        dest.Attributes.Append(destAttribute);
                    }
                    destAttribute.Value = attribute.Value;
                }
            }
        }

        protected XmlSchemaObject GetObjectType(XmlNode node, XmlSchemaParticle parent)
        {
            if (node.SchemaInfo != null && node.SchemaInfo.SchemaType != null)
            {
                return node.SchemaInfo.SchemaType;
            }
            XmlQualifiedName name = new XmlQualifiedName(node.Name, node.NamespaceURI);
            if (parent != null)
            {
                XmlSchemaObjectCollection collection = null;
                if (parent is XmlSchemaSequence sequence)
                {
                    collection = sequence.Items;
                }
                if (parent is XmlSchemaChoice choice)
                {
                    collection = choice.Items;
                }
                if (collection != null)
                {
                    foreach (XmlSchemaParticle particle in collection)
                    {
                        if (particle is XmlSchemaElement element)
                        {
                            if (element.QualifiedName == name)
                            {
                                return element.ElementSchemaType;
                            }
                        }
                    }
                }
            }
            else if (_schema.GlobalTypes.Contains(name))
            {
                return _schema.GlobalTypes[name];
            }
            return null;
        }
    }
}