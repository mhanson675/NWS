namespace NWS.Models.JsonLdFeatures
{
    /// <summary>
    /// An object representing a 2.5km grid square
    /// </summary>
    public record WxPointJson
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
        public string Type { get; } = "wx:Point";
        /// <summary>
        /// Gets or sets the geometry.
        /// </summary>
        /// <value>
        /// The geometry.
        /// </value>
        public string Geometry { get; init; }
        /// <summary>
        /// Gets or sets the cwa.
        /// </summary>
        /// <value>
        /// The cwa.
        /// </value>
        public string Cwa { get; init; }
        /// <summary>
        /// Gets or sets the forecast office.
        /// </summary>
        /// <value>
        /// The forecast office.
        /// </value>
        public string ForecastOffice { get; init; }
        /// <summary>
        /// Gets or sets the grid identifier.
        /// </summary>
        /// <value>
        /// The grid identifier.
        /// </value>
        public string GridId { get; init; }
        /// <summary>
        /// Gets or sets the grid x.
        /// </summary>
        /// <value>
        /// The grid x.
        /// </value>
        public int GridX { get; init; }
        /// <summary>
        /// Gets or sets the grid y.
        /// </summary>
        /// <value>
        /// The grid y.
        /// </value>
        public int GridY { get; init; }
        /// <summary>
        /// Gets or sets the forecast.
        /// </summary>
        /// <value>
        /// The forecast.
        /// </value>
        public string Forecast { get; init; }
        /// <summary>
        /// Gets or sets the forecast hourly.
        /// </summary>
        /// <value>
        /// The forecast hourly.
        /// </value>
        public string ForecastHourly { get; init; }
        /// <summary>
        /// Gets or sets the forecast grid data.
        /// </summary>
        /// <value>
        /// The forecast grid data.
        /// </value>
        public string ForecastGridData { get; init; }
        /// <summary>
        /// Gets or sets the observation stations.
        /// </summary>
        /// <value>
        /// The observation stations.
        /// </value>
        public string ObservationStations { get; init; }
        /// <summary>
        /// Gets or sets the relative location.
        /// </summary>
        /// <value>
        /// The relative location.
        /// </value>
        public WxRelativeLocationJson RelativeLocation { get; init; }
        /// <summary>
        /// Gets or sets the forecast zone.
        /// </summary>
        /// <value>
        /// The forecast zone.
        /// </value>
        public string ForecastZone { get; init; }
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
        /// <summary>
        /// Gets or sets the time zone.
        /// </summary>
        /// <value>
        /// The time zone.
        /// </value>
        public string TimeZone { get; init; }
        /// <summary>
        /// Gets or sets the radar station.
        /// </summary>
        /// <value>
        /// The radar station.
        /// </value>
        public string RadarStation { get; init; }
    }
}