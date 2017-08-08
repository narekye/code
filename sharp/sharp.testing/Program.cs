using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace sharp.testing
{
    class Sim<T, TU, TV>
    {
        private TU data;
        private TV datas;

        private T f;
    }
    static class Convertable
    {
        public static string ConvertToJson<T>(this T data)
        {
            // T result = default(T);
            string res = JsonConvert.SerializeObject(data);
            return res;
        }

        public static T GetInstanceFromJson<T>(this string data)
        {
            T res;
            try
            {
                res = JsonConvert.DeserializeObject<T>(data);
            }
            catch
            {
                res = default(T);
                throw new ArgumentException("Cannot parse json to - " + res?.GetType() + " object");
            }
            return res;
        }
    }

    class Program
    {
        static void Main()
        {
            HttpClient clinet = new HttpClient();
            var result = clinet.GetAsync("http://crmbetd.azurewebsites.net/api/contacts").Result;
            // var str = result.Content.ReadAsStringAsync().Result.GetInstanceFromJson <  > ();
            Console.Read();
        }
    }


}
