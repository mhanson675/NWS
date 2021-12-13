using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NWS.Models.JsonLdProperties;

namespace NWS.Models.Serializing.STJ.Converters
{
    public class WxGridpointHazardsQuantitativeValueConverter : JsonConverter<WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue>
    {
        public override WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            Utf8JsonReader readerClone = reader;

            int? eventNumber = null;
            while (readerClone.Read() && readerClone.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = readerClone.GetString();
                readerClone.Read();
                switch (propertyName)
                {
                    case "event_number":
                        eventNumber = JsonSerializer.Deserialize<int?>(ref readerClone, options);
                        break;

                    default:
                        readerClone.Skip();
                        break;
                }
            }

            while (readerClone.Read())
            {
            }

            WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue value =
                JsonSerializer.Deserialize<WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue>(ref reader, STJConfig.SerializeQvReader);

            return (value != null)
                ? value with { EventNumber = eventNumber }
                : new WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue();
        }

        public override void Write(Utf8JsonWriter writer, WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("phenomenon");
            JsonSerializer.Serialize(writer, value.Phenomenon, options);
            writer.WritePropertyName("significance");
            JsonSerializer.Serialize(writer, value.Significance, options);
            writer.WritePropertyName("event_number");
            JsonSerializer.Serialize(writer, value.EventNumber, options);
            writer.WriteEndObject();
        }
    }
}