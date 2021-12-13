using System;
using System.Net.Http;

namespace NWS.APIClient
{
    /// <summary>
    /// An HttpClient wrapper to setup the base url, user-agent, accept, and feature-flag headers for use with the National Weather Service API (api.weather.gov)
    /// </summary>
    /// <seealso cref="System.Net.Http.HttpClient" />
    public class NWSHttpClient : HttpClient
    {
        private const string UserAgent = "NWS Weather API Wrapper Library for .Net";
        private const string baseAddress = "https://api.weather.gov";
        private const string AcceptedFormat = "application/ld+json";
        private const string FeatureFlag = "Feature-Flag";
        private const string Flags = "forecast_temperature_qv, forecast_wind_speed_qv";

        /// <summary>
        /// Initializes a new instance of the <see cref="NWSHttpClient"/> class using default User-Agent header (NWS Weather API Wrapper Library for .NET)
        /// </summary>
        public NWSHttpClient()
        {
            BaseAddress = new Uri(baseAddress);
            DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            DefaultRequestHeaders.Accept.ParseAdd(AcceptedFormat);
            DefaultRequestHeaders.Add(FeatureFlag, Flags);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NWSHttpClient"/> class using the provided string for the User-Agent header values.
        /// </summary>
        /// <param name="userAgentValue">The user agent value.</param>
        public NWSHttpClient(string userAgentValue)
        {
            BaseAddress = new Uri(baseAddress);
            DefaultRequestHeaders.UserAgent.TryParseAdd(userAgentValue);
            DefaultRequestHeaders.Accept.ParseAdd(AcceptedFormat);
            DefaultRequestHeaders.Add(FeatureFlag, Flags);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NWSHttpClient"/> class using the provided <see cref="HttpMessageHandler"/>.
        /// </summary>
        /// <param name="handler">The HTTP handler stack to use for sending requests.</param>
        public NWSHttpClient(HttpMessageHandler handler) : base(handler)
        {
            BaseAddress = new Uri(baseAddress);
            DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            DefaultRequestHeaders.Accept.ParseAdd(AcceptedFormat);
            DefaultRequestHeaders.Add(FeatureFlag, Flags);
        }
    }
}