using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BinaryAssetBuilder.Core
{
    [Serializable]
    public class InstanceSet : KeyedCollection<InstanceHandle, InstanceDeclaration>
    {
        protected override InstanceHandle GetKeyForItem(InstanceDeclaration item)
        {
            return item.Handle;
        }

        public InstanceSet()
        {
        }

        public InstanceSet(AssetDeclarationDocument document, IEnumerable<InstanceDeclaration> instances)
        {
            if (instances is null)
            {
                return;
            }
            foreach (InstanceDeclaration instance in instances)
            {
                instance.Initialize(document);
                Add(instance);
            }
        }

        public void Add(InstanceSet other)
        {
            foreach (InstanceDeclaration declaration in other)
            {
                TryAdd(declaration);
            }
        }

        public void Add(List<InstanceDeclaration> other)
        {
            foreach (InstanceDeclaration declaration in other)
            {
                TryAdd(declaration);
            }
        }

        public bool TryAdd(InstanceDeclaration declaration)
        {
            if (Contains(declaration.Handle))
            {
                return false;
            }
            Add(declaration);
            return true;
        }

        public new bool TryGetValue(InstanceHandle key, out InstanceDeclaration value)
        {
            if (Dictionary != null)
            {
                return Dictionary.TryGetValue(key, out value);
            }
            value = null;
            return false;
        }

        public InstanceDeclaration[] ToArray()
        {
            if (Count == 0)
            {
                return null;
            }
            List<InstanceDeclaration> result = new List<InstanceDeclaration>();
            foreach (InstanceDeclaration instance in Items)
            {
                result.Add(instance);
            }
            return result.ToArray();
        }
    }
}