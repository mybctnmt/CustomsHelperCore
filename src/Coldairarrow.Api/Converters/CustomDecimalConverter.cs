using Newtonsoft.Json;
using System;

namespace Coldairarrow.Api.Converters
{
    public class CustomDecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(decimal?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null && objectType == typeof(decimal?))
            {
                return null;
            }

            if (reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Integer)
            {
                return Convert.ToDecimal(reader.Value);
            }

            throw new JsonSerializationException($"Unexpected token type: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            decimal decimalValue = (decimal)value;
            string formattedValue = decimalValue.ToString("G29", System.Globalization.CultureInfo.InvariantCulture);
            writer.WriteRawValue(formattedValue);
        }
    }


}
