using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Utils
{
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string[] _formats = new[] { "MM-dd-yyyy HH:mm:ss", "MM-dd-yyyy HH:mm" };
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var dateString = reader.GetString();
                if (DateTime.TryParseExact(dateString, _formats, null, System.Globalization.DateTimeStyles.None, out var date))
                {
                    return date;
                }
            }
            throw new JsonException("Invalid date format");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("MM-dd-yyyy HH:mm:ss"));
        }
    }
}
