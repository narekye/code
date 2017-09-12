using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace sharp.Extensions.Newtonsoft.Json
{
    public static class JsonExtensions
    {
        public static object ExpressionHelper { get; private set; }

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
    }
}
