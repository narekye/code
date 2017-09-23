using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace sharp.Extensions.Newtonsoft.Json
{
    public static class JsonExtensions
    {
        public static string ToJson<T>(this T obj, bool includeNull = false)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] { new StringEnumConverter() },
                NullValueHandling = includeNull ? NullValueHandling.Include : NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T FromJson<T>(this string obj, bool include = false)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] { new StringEnumConverter() },
                NullValueHandling = include ? NullValueHandling.Include : NullValueHandling.Ignore
            };

            return JsonConvert.DeserializeObject<T>(obj, settings);
        }

    }
}
