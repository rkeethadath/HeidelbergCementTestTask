using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace LogProxy.Api.Helpers
{
    public class DatetimeConverter : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return Convert.ToDateTime(reader.Value);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            base.WriteJson(writer, value, serializer);
        }
    }
}
