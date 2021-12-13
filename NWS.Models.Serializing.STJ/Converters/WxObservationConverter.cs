using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NWS.Models.JsonLdFeatures;

namespace NWS.Models.Serializing.STJ.Converters
{
    public class WxObservationConverter : JsonConverter<WxObservationJson>
    {
        public override WxObservationJson Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            Utf8JsonReader readerClone = reader;

            string id = string.Empty;
            string type = string.Empty;
            while (readerClone.Read() && readerClone.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = readerClone.GetString();
                readerClone.Read();
                switch (propertyName)
                {
                    case "@id":
                        id = JsonSerializer.Deserialize<string>(ref readerClone, options);
                        break;

                    case "@type":
                        type = JsonSerializer.Deserialize<string>(ref readerClone, options);
                        break;

                    default:
                        readerClone.Skip();
                        break;
                }
            }

            while (readerClone.Read())
            {
            }

            WxObservationJson observation = JsonSerializer.Deserialize<WxObservationJson>(ref reader, STJConfig.SerializeQvReader);

            return (observation != null) ? observation with { Id = id, Type = type } : new WxObservationJson();
        }

        public override void Write(Utf8JsonWriter writer, WxObservationJson value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, STJConfig.SerializeQvWriter);
        }
    }
}