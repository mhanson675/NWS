namespace NWS.Models.JsonLdProperties
{
    /// <summary>
    ///  An object representing the CloudLayer data point for an Observation
    /// </summary>
    public record CloudLayer
    {
        /// <summary>
        /// The base value of the CloudLayer
        /// </summary>
        /// <value>
        /// The base.
        /// </value>
        public QuantitativeValue Base { get; init; }

        /// <summary>
        /// The amount of cloud coverage.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public string Amount { get; init; }
    }
}