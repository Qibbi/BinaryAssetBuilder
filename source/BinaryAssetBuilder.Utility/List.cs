using System.Xml;
using System.Xml.XPath;

public class List
{
    private XPathNodeIterator _currentIterator;
    private readonly XPathNodeIterator _iterator;
    private readonly XmlNamespaceManager _namespaceManager;

    public List(XPathNodeIterator iterator, XmlNamespaceManager namespaceManager)
    {
        _currentIterator = iterator;
        _iterator = iterator.Clone();
        _namespaceManager = namespaceManager;
    }

    public int GetCount()
    {
        return _currentIterator.Count;
    }

    public Node GetNextNode()
    {
        Node result = null;
        if (_currentIterator.MoveNext())
        {
            result = new Node(_currentIterator.Current.CreateNavigator(), _namespaceManager);
        }
        return result;
    }

    public void Reset()
    {
        _currentIterator = _iterator.Clone();
    }

    public void Release()
    {
    }
}
