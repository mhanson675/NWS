using NWS.Models.JsonLdProperties;

namespace NWS.Models.JsonLdFeatures
{
    /// <summary>
    /// An object representing a relative location
    /// </summary>
    public record WxRelativeLocationJson
    {
        /// <summary>
        /// Gets or sets the geometry.
        /// </summary>
        /// <value>
        /// The geometry.
        /// </value>
        public string Geometry { get; init; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; init; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; init; }
        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public QuantitativeValue Distance { get; init; }
        /// <summary>
        /// Gets or sets the bearing.
        /// </summary>
        /// <value>
        /// The bearing.
        /// </value>
        public QuantitativeValue Bearing { get; init; }
    }
}