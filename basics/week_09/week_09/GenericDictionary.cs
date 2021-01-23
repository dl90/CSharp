using System.Collections.Generic;

namespace week_09
{
    class GenericDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> dictionary;

        public GenericDictionary()
        {
            dictionary = new Dictionary<TKey, TValue>();
        }

        public void Add(TKey key, TValue val)
        {
            dictionary.Add(key, val);
        }

        public dynamic Get(TKey key)
        {
            TValue val;
            bool result = dictionary.TryGetValue(key, out val);
            if (result) return val;
            else return null;
        }
    }
}
