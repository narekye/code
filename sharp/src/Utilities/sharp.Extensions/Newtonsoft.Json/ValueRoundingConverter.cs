using Newtonsoft.Json;
using System;

namespace sharp.Extensions.Newtonsoft.Json
{
    public class ValueRoundingConverter : JsonConverter
    {
        private int _precision;
        private MidpointRounding _rounding;

        public ValueRoundingConverter() : this(2) { }

        public ValueRoundingConverter(int precision) : this(precision, MidpointRounding.AwayFromZero) { }

        public ValueRoundingConverter(int precision, MidpointRounding rounding)
        {
            _precision = precision;
            _rounding = rounding;
        }

        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(float);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(decimal))
                writer.WriteValue(Math.Round((decimal)value, _precision, _rounding));
            else
                writer.WriteValue(Math.Round((double)value, _precision, _rounding));
        }
    }
}
