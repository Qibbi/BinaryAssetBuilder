using System.Collections.Generic;

namespace BinaryAssetBuilder.Core.Xml
{
    public static class Marshaler
    {
        public static void Marshal(string text, ref bool objT)
        {
            objT = bool.Parse(text);
        }

        public static void Marshal(Value value, ref bool objT)
        {
            if (value is null)
            {
                return;
            }
            Marshal(value.GetText(), ref objT);
        }

        public static void Marshal(Node node, ref bool objT)
        {
            if (node is null)
            {
                return;
            }
            Marshal(node.GetValue(), ref objT);
        }

        public static void Marshal(string text, ref string objT)
        {
            objT = text;
        }

        public static void Marshal(Value value, ref string objT)
        {
            if (value is null)
            {
                return;
            }
            Marshal(value.GetText(), ref objT);
        }

        public static void Marshal(Node node, ref string objT)
        {
            if (node is null)
            {
                return;
            }
            Marshal(node.GetValue(), ref objT);
        }

        public static void Marshal<T>(List list, ref T[] objT) where T : ISerializable, new()
        {
            if (list is null)
            {
                return;
            }
            int count = list.GetCount();
            objT = new T[count];
            for (int idx = 0; idx < count; ++idx)
            {
                T item = new T();
                item.ReadXml(list.GetNextNode());
                objT[idx] = item;
            }
        }

        public static void Marshal<T>(List list, ref List<T> objT) where T : ISerializable, new()
        {
            if (list is null)
            {
                return;
            }
            int count = list.GetCount();
            objT = new List<T>(count);
            for (int idx = 0; idx < count; ++idx)
            {
                T item = new T();
                item.ReadXml(list.GetNextNode());
                objT.Add(item);
            }
        }

        public static void Marshal(List list, ref string[] objT)
        {
            if (list is null)
            {
                return;
            }
            int count = list.GetCount();
            objT = new string[count];
            for (int idx = 0; idx < count; ++idx)
            {
                string item = default;
                Marshal(list.GetNextNode(), ref item);
                objT[idx] = item;
            }
        }

        public static void Marshal(List list, ref List<string> objT)
        {
            if (list is null)
            {
                return;
            }
            int count = list.GetCount();
            objT = new List<string>(count);
            for (int idx = 0; idx < count; ++idx)
            {
                string item = default;
                Marshal(list.GetNextNode(), ref item);
                objT.Add(item);
            }
        }
    }
}
