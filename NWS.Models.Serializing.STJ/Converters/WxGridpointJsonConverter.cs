using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NWS.Models.JsonLdFeatures;

namespace NWS.Models.Serializing.STJ.Converters
{
    public class WxGridpointJsonConverter : JsonConverter<WxGridpointJson>
    {
        public override WxGridpointJson Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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

            WxGridpointJson gridpoint = JsonSerializer.Deserialize<WxGridpointJson>(ref reader, STJConfig.SerializeGpHQvReader);

            return (gridpoint != null) ? gridpoint with { Id = id, Type = type } : new WxGridpointJson();
        }

        public override void Write(Utf8JsonWriter writer, WxGridpointJson value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, STJConfig.SerializeGpHQvWriter);
        }
    }
}