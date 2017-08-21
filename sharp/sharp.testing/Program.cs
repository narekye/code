using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

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

            HashSet<int?> arr = new HashSet<int?>();
            int x = 0;
            // var enumerable = x.ToString().Reverse().ToString();
            // var t = arr.GetEnumerator();
            // int b;
            // int.Parse(enumerable);
            arr.Add(null);

            long z = 456456465465465465;



            // Map<int, int> map = new HashMap<>();
            HttpClient clinet = new HttpClient();
            var result = clinet.GetAsync("http://crmbetd.azurewebsites.net/api/contacts").Result;
            // var str = result.Content.ReadAsStringAsync().Result.GetInstanceFromJson <  > ();

            int k = -78;
            var res = Reverse(k);
            Console.WriteLine(res);
            Console.Read();
        }

        public static int Reverse(int a)
        {
            Hashtable table = new Hashtable();

            if (a < 0)
            {
                a *= -1;
                var temp = a.ToString().Reverse();
                StringBuilder builder = new StringBuilder();
                foreach (char item in temp)
                {
                    builder.Append(item);
                }
                long b = int.Parse(builder.ToString());
                return (int)b * -1;
            }
            return 0;
        }


    }
}



