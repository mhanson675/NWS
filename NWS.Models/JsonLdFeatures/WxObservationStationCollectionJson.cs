using System.Collections.Generic;

namespace NWS.Models.JsonLdFeatures
{
    /// <summary>
    /// An object representing a collection of observation stations
    /// </summary>
    public record WxObservationStationCollectionJson
    {
        /// <summary>
        /// Gets or sets the stations.
        /// </summary>
        /// <value>
        /// The stations.
        /// </value>
        public IEnumerable<WxObservationStationJson> Stations { get; init; }
        /// <summary>
        /// Gets or sets the station urls.
        /// </summary>
        /// <value>
        /// The station urls.
        /// </value>
        public IEnumerable<string> StationUrls { get; init; }
    }
}