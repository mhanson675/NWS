using System.Collections.Generic;

namespace NWS.Models.JsonLdFeatures
{
    /// <summary>
    /// An object containing a collection of Weather Observations
    /// </summary>
    public record WxObservationCollectionJson
    {
        /// <summary>
        /// Gets or sets the observations.
        /// </summary>
        /// <value>
        /// The observations.
        /// </value>
        public IEnumerable<WxObservationJson> Observations { get; init; }
    }
}