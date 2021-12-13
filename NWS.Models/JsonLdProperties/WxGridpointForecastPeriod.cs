namespace NWS.Models.JsonLdProperties
{
    /// <summary>
    /// An object containing forecast information for a specific time period (usually 12-hour or 1-hour)
    /// </summary>
    public record WxGridpointForecastPeriod
    {
        /// <summary>
        /// Gets or sets the number for this period when in a collection.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public int Number { get; init; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; init; }
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public string StartTime { get; set; }
        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public string EndTime { get; init; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is daytime.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is daytime; otherwise, <c>false</c>.
        /// </value>
        public bool IsDaytime { get; init; }
        /// <summary>
        /// Gets or sets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public QuantitativeValue Temperature { get; init; }
        /// <summary>
        /// Gets or sets the temperature trend.
        /// </summary>
        /// <value>
        /// The temperature trend.
        /// </value>
        public string TemperatureTrend { get; init; }
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
        /// Gets or sets the wind direction.
        /// </summary>
        /// <value>
        /// The wind direction.
        /// </value>
        public string WindDirection { get; init; }
        /// <summary>
        /// Gets or sets the short forecast.
        /// </summary>
        /// <value>
        /// The short forecast.
        /// </value>
        public string ShortForecast { get; init; }
        /// <summary>
        /// Gets or sets the detailed forecast.
        /// </summary>
        /// <value>
        /// The detailed forecast.
        /// </value>
        public string DetailedForecast { get; init; }
    }
}