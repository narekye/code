namespace sharp.Extensions.Cache
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;

    public static class Cache
    {
        private struct CacheItem
        {
            public CacheItem(object item, int expires) : this()
            {
                Item = item;
                ExpireTime = DateTime.Now.AddMinutes(expires);
            }

            public object Item { get; }
            public DateTime ExpireTime { get; }
        }

        static readonly Timer cleanupTimer = new Timer { AutoReset = true, Enabled = true, Interval = 60000 };
        static readonly Dictionary<string, CacheItem> internalCache = new Dictionary<string, CacheItem>();

        static Cache()
        {
            cleanupTimer.Elapsed += Clean;
            cleanupTimer.Start();
        }

        private static void Clean(object sender, ElapsedEventArgs e)
        {
            foreach (var s in internalCache.Keys.ToList())
            {
                try
                {
                    if (internalCache[s].ExpireTime <= e.SignalTime)
                    {
                        Remove(s);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        public static T GetItem<T>(string key, int expiresMin, Func<T> refreshFunc) where T : class
        {
            if (internalCache.ContainsKey(key) && internalCache[key].ExpireTime > DateTime.Now)
                return (T)internalCache[key].Item;

            var result = refreshFunc();
            Set(key, result, expiresMin);
            return result;
        }

        public static void Set(string key, object result, int expiresMin)
        {
            internalCache.Remove(key);
            internalCache.Add(key, new CacheItem(result, expiresMin));
        }


        private static void Remove(string key)
        {
            if (internalCache.ContainsKey(key))
            {
                internalCache.Remove(key);
            }
        }
    }
}
