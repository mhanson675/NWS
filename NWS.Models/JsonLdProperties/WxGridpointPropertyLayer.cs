using System.Collections.Generic;

namespace NWS.Models.JsonLdProperties
{
    /// <summary>
    /// An object representing a property layer for a gridpoint raw textual forescast
    /// </summary>
    public record WxGridpointPropertyLayer
    {
        /// <summary>
        /// The unit of measurement used for this value
        /// </summary>
        public string Uom { get; init; }
        
        /// <summary>
        /// The values available for this forecast
        /// </summary>
        public IEnumerable<WxGridpointQuantitativeValue> Values { get; init; }
        
        /// <summary>
        /// An object representing individual values of a gridpoint property layer
        /// </summary>
        public record WxGridpointQuantitativeValue
        {
            /// <summary>
            /// A string representation of an ISO8601 date for the valid times for this value
            /// </summary>
            public string ValidTime { get; init; }
            
            /// <summary>
            /// The numerical value of this measurement.
            /// </summary>
            public double? Value { get; init; }
        }
    }
}