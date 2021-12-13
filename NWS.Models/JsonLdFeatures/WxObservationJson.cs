using System.Collections.Generic;
using NWS.Models.JsonLdProperties;

namespace NWS.Models.JsonLdFeatures
{
    /// <summary>
    /// An object representing observation data from a forecast station
    /// </summary>
    public record WxObservationJson
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; init; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; init; }
        /// <summary>
        /// Gets or sets the geometry.
        /// </summary>
        /// <value>
        /// The geometry.
        /// </value>
        public string Geometry { get; init; }
        /// <summary>
        /// Gets or sets the elevation.
        /// </summary>
        /// <value>
        /// The elevation.
        /// </value>
        public QuantitativeValue Elevation { get; init; }
        /// <summary>
        /// Gets or sets the station.
        /// </summary>
        /// <value>
        /// The station.
        /// </value>
        public string Station { get; init; }
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public string Timestamp { get; init; }
        /// <summary>
        /// Gets or sets the raw message.
        /// </summary>
        /// <value>
        /// The raw message.
        /// </value>
        public string RawMessage { get; init; }
        /// <summary>
        /// Gets or sets the text description.
        /// </summary>
        /// <value>
        /// The text description.
        /// </value>
        public string TextDescription { get; init; }
        /// <summary>
        /// Gets or sets the present weather.
        /// </summary>
        /// <value>
        /// The present weather.
        /// </value>
        public IEnumerable<MetarPhenomenon> PresentWeather { get; init; }
        /// <summary>
        /// Gets or sets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public QuantitativeValue Temperature { get; init; }
        /// <summary>
        /// Gets or sets the dewpoint.
        /// </summary>
        /// <value>
        /// The dewpoint.
        /// </value>
        public QuantitativeValue Dewpoint { get; init; }
        /// <summary>
        /// Gets or sets the wind direction.
        /// </summary>
        /// <value>
        /// The wind direction.
        /// </value>
        public QuantitativeValue WindDirection { get; init; }
        /// <summary>
        /// Gets or sets the wind speed.
        /// </summary>
        /// <value>
        /// The wind speed.
        /// </value>
        public QuantitativeValue WindSpeed { get; init; }
        /// <summary>
        /// Gets or sets the wind gust.
        /// </summary>
        /// <value>
        /// The wind gust.
        /// </value>
        public QuantitativeValue WindGust { get; init; }
        /// <summary>
        /// Gets or sets the barometric pressure.
        /// </summary>
        /// <value>
        /// The barometric pressure.
        /// </value>
        public QuantitativeValue BarometricPressure { get; init; }
        /// <summary>
        /// Gets or sets the sea level pressure.
        /// </summary>
        /// <value>
        /// The sea level pressure.
        /// </value>
        public QuantitativeValue SeaLevelPressure { get; init; }
        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        /// <value>
        /// The visibility.
        /// </value>
        public QuantitativeValue Visibility { get; init; }
        /// <summary>
        /// Gets or sets the maximum temperature last24 hours.
        /// </summary>
        /// <value>
        /// The maximum temperature last24 hours.
        /// </value>
        public QuantitativeValue MaxTemperatureLast24Hours { get; init; }
        /// <summary>
        /// Gets or sets the minimum temperature last24 hours.
        /// </summary>
        /// <value>
        /// The minimum temperature last24 hours.
        /// </value>
        public QuantitativeValue MinTemperatureLast24Hours { get; init; }
        /// <summary>
        /// Gets or sets the precipitation last hour.
        /// </summary>
        /// <value>
        /// The precipitation last hour.
        /// </value>
        public QuantitativeValue PrecipitationLastHour { get; init; }
        /// <summary>
        /// Gets or sets the precipitation last3 hours.
        /// </summary>
        /// <value>
        /// The precipitation last3 hours.
        /// </value>
        public QuantitativeValue PrecipitationLast3Hours { get; init; }
        /// <summary>
        /// Gets or sets the precipitation last6 hours.
        /// </summary>
        /// <value>
        /// The precipitation last6 hours.
        /// </value>
        public QuantitativeValue PrecipitationLast6Hours { get; init; }
        /// <summary>
        /// Gets or sets the relative humidity.
        /// </summary>
        /// <value>
        /// The relative humidity.
        /// </value>
        public QuantitativeValue RelativeHumidity { get; init; }
        /// <summary>
        /// Gets or sets the wind chill.
        /// </summary>
        /// <value>
        /// The wind chill.
        /// </value>
        public QuantitativeValue WindChill { get; init; }
        /// <summary>
        /// Gets or sets the index of the heat.
        /// </summary>
        /// <value>
        /// The index of the heat.
        /// </value>
        public QuantitativeValue HeatIndex { get; init; }
        /// <summary>
        /// Gets or sets the cloud layers.
        /// </summary>
        /// <value>
        /// The cloud layers.
        /// </value>
        public IEnumerable<CloudLayer> CloudLayers { get; init; }
    }
}