using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class Set<T> : ICollection<T>, ICollection
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct Nop
        {
        }

        private static readonly Nop _theNop = new Nop();

        private readonly Dictionary<T, Nop> _dictionary;

        public static Set<T> Empty => new Set<T>(0);

        public int Count => _dictionary.Count;
        public bool IsReadOnly => false;
        public bool IsSynchronized => ((ICollection)_dictionary.Keys).IsSynchronized;
        public object SyncRoot => ((ICollection)_dictionary.Keys).SyncRoot;

        public Set()
        {
            _dictionary = new Dictionary<T, Nop>();
        }

        public Set(int capacity)
        {
            _dictionary = new Dictionary<T, Nop>(capacity);
        }

        public Set(Set<T> other)
        {
            _dictionary = new Dictionary<T, Nop>(other._dictionary);
        }

        public Set(IEnumerable<T> original)
        {
            _dictionary = new Dictionary<T, Nop>();
            AddRange(original);
        }

        public void Add(T item)
        {
            _dictionary[item] = _theNop;
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (T item in range)
            {
                Add(item);
            }
        }

        public Set<U> ConvertAll<U>(Converter<T, U> converter)
        {
            Set<U> result = new Set<U>(Count);
            foreach (T input in this)
            {
                result.Add(converter(input));
            }
            return result;
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(T item)
        {
            return _dictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _dictionary.Keys.CopyTo(array, arrayIndex);
        }

        public T[] ToArray()
        {
            T[] result = new T[_dictionary.Keys.Count];
            _dictionary.Keys.CopyTo(result, 0);
            return result;
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)_dictionary.Keys).CopyTo(array, index);
        }

        public bool Remove(T item)
        {
            return _dictionary.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dictionary.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_dictionary.Keys).GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            return obj is Set<T> objT && this == objT;
        }

        public override int GetHashCode()
        {
            int result = 0;
            foreach (T obj in this)
            {
                result ^= obj.GetHashCode();
            }
            return result;
        }
    }
}