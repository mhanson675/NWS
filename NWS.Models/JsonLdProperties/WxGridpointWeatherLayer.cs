using System.Collections.Generic;

namespace NWS.Models.JsonLdProperties
{
    /// <summary>
    /// An object representing the weather property value layer for a gridpoint raw textual forecast
    /// </summary>
    public record WxGridpointWeatherLayer
    {
        /// <summary>
        /// The available values for this layer
        /// </summary>
        public IEnumerable<WxGridpointWeather> Values { get; init; }
        
        /// <summary>
        /// An object representing a collection of expected weather phenomena grouped by their valid time periods
        /// </summary>
        public record WxGridpointWeather
        {
            /// <summary>
            /// A string representing an ISO8601 interval based on the times that the value will be valid.
            /// </summary>
            public string ValidTime { get; init; }

            /// <summary>
            /// A collection of expected weather phenomena for the given time period.
            /// </summary>
            public IEnumerable<WxGridpointWeatherQuantitativeValue> Value { get; init; }
        }

        /// <summary>
        /// An object representing expected weather phenomena
        /// </summary>
        public record WxGridpointWeatherQuantitativeValue
        {
            /// <summary>
            /// The coverage expected for this weather phenomena
            /// </summary>
            public string Coverage { get; init; }
            /// <summary>
            /// The weather phenomena
            /// </summary>
            public string Weather { get; init; }
            /// <summary>
            /// The intensity of the weather phenomena
            /// </summary>
            public string Intensity { get; init; }
            /// <summary>
            /// The visibility expected during this weather phenomena
            /// </summary>
            public QuantitativeValue Visibility { get; init; }
            /// <summary>
            /// A collection of attributes for this weather phenomena
            /// </summary>
            public string[] Attributes { get; init; }
        }
    }
}