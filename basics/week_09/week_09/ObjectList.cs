using System.Collections.Generic;

namespace week_09
{
    class ObjectList
    {
        private readonly List<object> list;

        public ObjectList()
        {
            list = new List<object>();
        }

        public void Add(object arg)
        {
            list.Add(arg);
        }

        public object Get(int idx)
        {
            return list[idx];
        }

    }
}
