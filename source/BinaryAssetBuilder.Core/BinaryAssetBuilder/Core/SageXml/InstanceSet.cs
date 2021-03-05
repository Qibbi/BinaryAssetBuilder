using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BinaryAssetBuilder.Core.SageXml
{
    public class InstanceSet : KeyedCollection<InstanceHandle, InstanceDeclaration>
    {
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

        protected override InstanceHandle GetKeyForItem(InstanceDeclaration item)
        {
            return item.Handle;
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

        public void Add(InstanceSet other)
        {
            foreach (InstanceDeclaration instanceDeclaration in other)
            {
                TryAdd(instanceDeclaration);
            }
        }

        public void Add(IList<InstanceDeclaration> other)
        {
            foreach (InstanceDeclaration instanceDeclaration in other)
            {
                TryAdd(instanceDeclaration);
            }
        }

        public new bool TryGetValue(InstanceHandle key, out InstanceDeclaration value)
        {
            if (Dictionary is not null)
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
            List<InstanceDeclaration> list = new List<InstanceDeclaration>();
            foreach (InstanceDeclaration instanceDeclaration in Items)
            {
                list.Add(instanceDeclaration);
            }
            return list.ToArray();
        }
    }
}
