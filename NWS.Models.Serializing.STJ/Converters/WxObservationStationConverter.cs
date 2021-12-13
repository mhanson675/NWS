using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NWS.Models.JsonLdFeatures;
using NWS.Models.JsonLdProperties;

namespace NWS.Models.Serializing.STJ.Converters
{
    public class WxObservationStationConverter : JsonConverter<WxObservationStationJson>
    {
        public override WxObservationStationJson Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            Utf8JsonReader readerClone = reader;

            string stationId = string.Empty;
            bool idFound = false;
            while (readerClone.Read() && readerClone.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = readerClone.GetString();
                readerClone.Read();
                if (propertyName != "@id") continue;
                stationId = readerClone.GetString();
                idFound = true;
            }

            WxObservationStationJson station = JsonSerializer.Deserialize<WxObservationStationJson>(ref reader, STJConfig.SerializeQvReader);

            if (idFound)
            {
                return (station != null) ? station with { Id = stationId } : new WxObservationStationJson();
            }
            else
            {
                return station;
            }

        }

        public override void Write(Utf8JsonWriter writer, WxObservationStationJson value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, STJConfig.SerializeQvWriter);
        }
    }
}
