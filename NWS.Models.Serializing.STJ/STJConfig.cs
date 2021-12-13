using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NWS.Models.Serializing.STJ.Converters;
using NWS.Models.Serializing.STJ.Policies;

namespace NWS.Models.Serializing.STJ
{
    public static class STJConfig
    {
        public static JsonSerializerOptions SerializeAllNWS => new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            Converters =
            {
                new QuantitativeValueConverter(),
                new WxObservationStationConverter(),
                new WxObservationStationCollectionConverter(),
                new WxObservationConverter(),
                new WxObservationCollectionConverter(),
                new WxGridpointHazardsQuantitativeValueConverter(),
                new WxGridpointJsonConverter()
            }
        };

        public static JsonSerializerOptions SerializeQvReader => new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            Converters =
            {
                new QuantitativeValueConverter(),
            }
        };

        public static JsonSerializerOptions SerializeGpHQvReader => new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            Converters =
            {
                new QuantitativeValueConverter(),
                new WxGridpointHazardsQuantitativeValueConverter()
            }
        };

        public static JsonSerializerOptions SerializeGpHQvWriter => new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            Converters =
            {
                new QuantitativeValueConverter(),
                new WxGridpointHazardsQuantitativeValueConverter()
            }
        };

        public static JsonSerializerOptions SerializeQvWriter => new JsonSerializerOptions
        {
            PropertyNamingPolicy = new ObjectIdentifierNamingPolicy(),
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            Converters =
            {
                new QuantitativeValueConverter(),
            }
        };
    }
}