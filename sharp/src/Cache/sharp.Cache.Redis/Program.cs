using sharp.Cache.Redis.Store;
using System;

namespace sharp.Cache.Redis
{
    class A
    {
        public A()
        {
            Age = 35;
        }
        public int Age { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var redis = RedisStore.RedisCache;

            CustomCache.Cache.Set("aa", new object(), 60000);

            Console.Read();
        }
    }
}
