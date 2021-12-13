using System.Collections.Generic;

namespace NWS.Models.JsonLdProperties
{
    /// <summary>
    /// An object representing the Hazards property layer of a Girdpoint raw forecast
    /// </summary>
    public record WxGridpointHazardsLayer
    {
        /// <summary>
        /// The values available for the current forecast
        /// </summary>
        public IEnumerable<WxGridpointHazards> Values { get; init; }
        
        /// <summary>
        /// An object representing a collection of Hazard data values
        /// </summary>
        public record WxGridpointHazards
        {
            /// <summary>
            /// A string in ISO8601 format representing the time that the Hazard is valid for
            /// </summary>
            public string ValidTime { get; init; }
            
            /// <summary>
            /// A collection of hazard values
            /// </summary>
            public IEnumerable<WxGridpointHazardsQuantitativeValue> Value { get; init; }
        }

        /// <summary>
        /// An object representing the data for a specific hazard value
        /// </summary>
        public record WxGridpointHazardsQuantitativeValue
        {
            /// <summary>
            /// The hazard code, corresponding to a P-VTEC phenomenon code based on NWS Directive 10-1703
            /// </summary>
            public string Phenomenon { get; init; }
            /// <summary>
            /// The significance code, corresponding to a P-VTEC significance code based on NWS Directive 10-1703
            /// </summary>
            public string Significance { get; init; }
            /// <summary>
            /// The event number. If this hazard refers to a national or regional center product, this value will be the sequence number of that product.
            /// </summary>
            public int? EventNumber { get; init; }
        }
    }
}