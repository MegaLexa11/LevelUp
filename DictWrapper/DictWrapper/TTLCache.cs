using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DictWrapper
{
    internal class TTLCache<V>
    {

        private Dictionary<int, (V value, DateTime expiredDate)> _cache;

        public TTLCache()
        {
            _cache = new Dictionary<int, (V, DateTime)>();
        }

        public void AddOrUpdate(int key, V value, int ttl = 30) 
        {
            _cache[key] = (value, DateTime.Now.AddSeconds(30));
        }

        public V? Get(int key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                return default;
            }

            if (value.expiredDate > DateTime.Now)
            {
                _cache.Remove(key);
                return default;
            }

            return value.value;

        }

    }
}
