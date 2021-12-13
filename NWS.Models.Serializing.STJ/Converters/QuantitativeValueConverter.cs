using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NWS.Models.JsonLdProperties;

namespace NWS.Models.Serializing.STJ.Converters
{
    public class QuantitativeValueConverter : JsonConverter<QuantitativeValue>
    {
        public override QuantitativeValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            double? value = null;
            double? maxValue = null;
            double? minValue = null;
            string unitCode = null;
            string qualityControl = null;
            while (reader.Read() && reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString();
                reader.Read();
                switch (propertyName)
                {
                    case "value":
                        if (reader.TokenType != JsonTokenType.Null && reader.TryGetDouble(out double jsonValue)) value = jsonValue;
                        break;

                    case "maxValue":
                        
                        if (reader.TokenType != JsonTokenType.Null && reader.TryGetDouble(out double jsonMaxValue)) maxValue = jsonMaxValue;
                        break;

                    case "minValue":
                        
                        if (reader.TokenType != JsonTokenType.Null && reader.TryGetDouble(out double jsonMinValue)) minValue = jsonMinValue;
                        break;

                    case "unitCode":
                        unitCode = reader.GetString();
                        break;

                    case "qualityControl":
                        qualityControl = reader.GetString();
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }

            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return new QuantitativeValue(){Value = value, MaxValue = maxValue, MinValue = minValue, UnitCode = unitCode, QualityControl = qualityControl};
        }

        public override void Write(Utf8JsonWriter writer, QuantitativeValue qv, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (qv.Value.HasValue)
            {
                writer.WriteNumber("value", qv.Value.Value);
            }
            else
            {
                writer.WriteNull("value");
            }

            if (qv.MaxValue.HasValue)
            {
                writer.WriteNumber("maxValue", qv.MaxValue.Value);
            }

            if (qv.MinValue.HasValue)
            {
                writer.WriteNumber("minValue", qv.MinValue.Value);
            }

            if (!string.IsNullOrWhiteSpace(qv.UnitCode))
            {
                writer.WriteString("unitCode", qv.UnitCode);
            }

            if (!string.IsNullOrWhiteSpace(qv.QualityControl))
            {
                writer.WriteString("qualityControl", qv.QualityControl);
            }

            writer.WriteEndObject();
        }
    }
}