using StackExchange.Redis;
using System;

namespace sharp.Cache.Redis.Store
{
    public class RedisStore
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisStore()
        {
            var config = new ConfigurationOptions
            {
                EndPoints = { "localhost" }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(config));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;
        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}
