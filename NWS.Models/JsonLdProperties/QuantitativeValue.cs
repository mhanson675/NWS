namespace NWS.Models.JsonLdProperties
{
    /// <summary>
    /// A Quantitative Value based on the schema.org format
    /// </summary>
    public record QuantitativeValue
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double? Value { get; init; }
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public double? MaxValue { get; init; }
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public double? MinValue { get; init; }
        /// <summary>
        /// Gets or sets the unit code.
        /// </summary>
        /// <value>
        /// The unit code.
        /// </value>
        public string UnitCode { get; init; }
        /// <summary>
        /// Gets or sets the quality control.
        /// </summary>
        /// <value>
        /// The quality control.
        /// </value>
        public string QualityControl { get; init; }
    }
}