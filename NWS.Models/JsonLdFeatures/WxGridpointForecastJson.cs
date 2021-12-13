using System.Collections.Generic;
using NWS.Models.JsonLdProperties;

namespace NWS.Models.JsonLdFeatures
{
    /// <summary>
    /// An object representing a multi-day forecast for a 2.5km grid square
    /// </summary>
    public record WxGridpointForecastJson
    {
        /// <summary>
        /// Gets or sets the geometry.
        /// </summary>
        /// <value>
        /// The geometry.
        /// </value>
        public string Geometry { get; init; }
        /// <summary>
        /// Gets or sets the units.
        /// </summary>
        /// <value>
        /// The units.
        /// </value>
        public string Units { get; init; }
        /// <summary>
        /// Gets or sets the forecast generator.
        /// </summary>
        /// <value>
        /// The forecast generator.
        /// </value>
        public string ForecastGenerator { get; init; }
        /// <summary>
        /// Gets or sets the generated at.
        /// </summary>
        /// <value>
        /// The generated at.
        /// </value>
        public string GeneratedAt { get; init; }
        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        /// <value>
        /// The update time.
        /// </value>
        public string UpdateTime { get; init; }
        /// <summary>
        /// Gets or sets the valid times.
        /// </summary>
        /// <value>
        /// The valid times.
        /// </value>
        public string ValidTimes { get; init; }
        /// <summary>
        /// Gets or sets the elevation.
        /// </summary>
        /// <value>
        /// The elevation.
        /// </value>
        public QuantitativeValue Elevation { get; init; }
        /// <summary>
        /// Gets or sets the periods.
        /// </summary>
        /// <value>
        /// The periods.
        /// </value>
        public IEnumerable<WxGridpointForecastPeriod> Periods { get; init; }
    }
}