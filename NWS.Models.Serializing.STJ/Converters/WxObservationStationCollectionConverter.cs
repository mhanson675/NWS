using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NWS.Models.JsonLdFeatures;
using NWS.Models.JsonLdProperties;

namespace NWS.Models.Serializing.STJ.Converters
{
    public class WxObservationStationCollectionConverter : JsonConverter<WxObservationStationCollectionJson>
    {
        public override WxObservationStationCollectionJson Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            IEnumerable<WxObservationStationJson> stations = new List<WxObservationStationJson>();
            IEnumerable<string> urls = new List<string>();
            while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString();
                reader.Read();
                switch (propertyName)
                {
                    case "@graph":
                        stations = JsonSerializer.Deserialize<IEnumerable<WxObservationStationJson>>(ref reader, options);
                        break;
                    case "observationStations":
                        urls = JsonSerializer.Deserialize<IEnumerable<string>>(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            return new WxObservationStationCollectionJson { Stations = stations, StationUrls = urls };
        }

        public override void Write(Utf8JsonWriter writer, WxObservationStationCollectionJson value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteStartArray("@graph");
            foreach (WxObservationStationJson wxObservationStation in value.Stations)
            {
                JsonSerializer.Serialize(writer, wxObservationStation, STJConfig.SerializeQvWriter);
            }
            writer.WriteEndArray();
            writer.WriteStartArray("observationStations");
            foreach (string valueStationUrl in value.StationUrls)
            {
                writer.WriteStringValue(valueStationUrl);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
