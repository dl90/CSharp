using System.Collections.Generic;

namespace Inventory.Classes
{
    class GenericList<T>
    {
        private readonly List<T> list;

        public GenericList()
        {
            list = new List<T>();
        }

        public void Add(T arg)
        {
            list.Add(arg);
        }

        public T Get(int idx)
        {
            return (idx <= list.Count) ? list[idx] : default;
        }

        public void Remove(int idx)
        {
            if (idx <= list.Count) list.RemoveAt(idx);
        }
    }
}
