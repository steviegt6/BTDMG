using System.Collections.Generic;

namespace BTDMG.Source.Internals.Utilities
{
    public static class CollectionUtils
    {
        public static void GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue fallback, out TValue value)
        {
            if (dictionary.TryGetValue(key, out value))
                return;

            dictionary.Add(key, fallback);
            value = dictionary[key];
        }
    }
}
