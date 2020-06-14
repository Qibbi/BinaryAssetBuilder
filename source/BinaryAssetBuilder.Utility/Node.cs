using System.Xml;
using System.Xml.XPath;

public class Node
{
    private XPathNavigator _navigator { get; }
    private string _defaultValue { get; }
    private XmlNamespaceManager _namespaceManager { get; }

    public Node(XPathNavigator navigator, XmlNamespaceManager namespaceManager)
    {
        _navigator = navigator;
        _namespaceManager = namespaceManager;
    }

    public Node(string defaultValue)
    {
        _defaultValue = defaultValue;
    }

    public List GetChildNodes(string name)
    {
        List result = null;
        if (_navigator != null)
        {
            if (name is null)
            {
                result = new List(_navigator.SelectChildren(XPathNodeType.Element), _namespaceManager);
            }
            else
            {
                result = new List((XPathNodeIterator)_navigator.Evaluate($"ea:{name}", _namespaceManager), _namespaceManager);
            }
        }
        return result;
    }

    public Node GetChildNode(string name, string defaultValue)
    {
        Node result = null;
        if (_navigator != null)
        {
            if (_navigator.MoveToChild(name, _navigator.NamespaceURI))
            {
                result = new Node(_navigator.CreateNavigator(), _namespaceManager);
            }
            _navigator.MoveToParent();
        }
        if (result is null && defaultValue != null)
        {
            result = new Node(defaultValue);
        }
        return result;
    }

    public Value GetAttributeValue(string name, string defaultValue)
    {
        Value result = null;
        if (_navigator != null && _navigator.MoveToAttribute(name, string.Empty))
        {
            result = new Value(_navigator.Value);
            _navigator.MoveToParent();
        }
        if (result is null && defaultValue != null)
        {
            result = new Value(defaultValue);
        }
        return result;
    }

    public Value GetValue()
    {
        Value result = null;
        if (_navigator != null)
        {
            result = new Value(_navigator.Value);
        }
        else if (_defaultValue != null)
        {
            result = new Value(_defaultValue);
        }
        return result;
    }

    public void Release()
    {
    }
}
