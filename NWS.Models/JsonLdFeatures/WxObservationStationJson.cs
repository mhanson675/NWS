using NWS.Models.JsonLdProperties;

namespace NWS.Models.JsonLdFeatures
{
    /// <summary>
    /// An object representing a weather observation station
    /// </summary>
    public record WxObservationStationJson
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; init; }
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type => "wx:ObservationStation";
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
        /// Gets or sets the station identifier.
        /// </summary>
        /// <value>
        /// The station identifier.
        /// </value>
        public string StationIdentifier { get; init; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; init; }
        /// <summary>
        /// Gets or sets the time zone.
        /// </summary>
        /// <value>
        /// The time zone.
        /// </value>
        public string TimeZone { get; init; }
        /// <summary>
        /// Gets or sets the forecast.
        /// </summary>
        /// <value>
        /// The forecast.
        /// </value>
        public string Forecast { get; init; }
        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>
        /// The county.
        /// </value>
        public string County { get; init; }
        /// <summary>
        /// Gets or sets the fire weather zone.
        /// </summary>
        /// <value>
        /// The fire weather zone.
        /// </value>
        public string FireWeatherZone { get; init; }
    }
}