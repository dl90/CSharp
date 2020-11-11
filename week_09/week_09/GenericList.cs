using System.Collections.Generic;

namespace week_09
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
            return list[idx];
        }
    }
}
