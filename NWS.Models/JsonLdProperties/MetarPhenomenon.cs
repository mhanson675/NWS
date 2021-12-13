namespace NWS.Models.JsonLdProperties
{
    /// <summary>
    /// An object representing a METAR phenomenon string
    /// </summary>
    public record MetarPhenomenon
    {
        /// <summary>
        /// Gets or sets the intensity.
        /// </summary>
        /// <value>
        /// The intensity.
        /// </value>
        public string Intensity { get; init; }
        /// <summary>
        /// Gets or sets the modifier.
        /// </summary>
        /// <value>
        /// The modifier.
        /// </value>
        public string Modifier { get; init; }
        /// <summary>
        /// Gets or sets the weather.
        /// </summary>
        /// <value>
        /// The weather.
        /// </value>
        public string Weather { get; init; }
        /// <summary>
        /// Gets or sets the raw string.
        /// </summary>
        /// <value>
        /// The raw string.
        /// </value>
        public string RawString { get; init; }
        /// <summary>
        /// Gets or sets a value indicating whether [in vicinity].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in vicinity]; otherwise, <c>false</c>.
        /// </value>
        public bool InVicinity { get; init; }
    }
}