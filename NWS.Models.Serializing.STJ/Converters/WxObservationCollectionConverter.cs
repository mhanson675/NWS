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
    public class WxObservationCollectionConverter : JsonConverter<WxObservationCollectionJson>
    {
        public override WxObservationCollectionJson Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            IEnumerable<WxObservationJson> observations = new List<WxObservationJson>();
            while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString();
                reader.Read();
                if (propertyName == "@graph")
                {
                    observations = JsonSerializer.Deserialize<IEnumerable<WxObservationJson>>(ref reader, options);
                }
                else
                {
                    reader.Skip();
                }
            }

            return new WxObservationCollectionJson { Observations = observations };
        }

        public override void Write(Utf8JsonWriter writer, WxObservationCollectionJson value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteStartArray("@graph");
            foreach (WxObservationJson wxObservation in value.Observations)
            {
                JsonSerializer.Serialize(writer, wxObservation, STJConfig.SerializeQvWriter);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}