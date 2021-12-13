using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NWS.APIClient.Extensions;
using NWS.Models.JsonLdFeatures;
using NWS.Models.Serializing.STJ;

namespace NWS.APIClient
{
    /// <summary>
    /// <para>
    /// Gets weather data from the National Weather Service (api.weather.gov).
    /// </para>
    /// <para>
    /// Supports a user provided .NET <see cref="HttpClient"/> provided through the constructor. Must have a valid 'User-Agent' header and a base address of 'https://api.weather.gov'.
    /// If one isn't supplied, it's recommended that the service be instantiated as a Singleton since a new HttpClient will be created with each instance of the service.
    /// This is currently advised against by Microsoft and general use of the HttpClient class.
    /// See <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests"/>
    /// </para>
    /// <para>
    ///  Supports logging if a <see cref="ILogger{TCategoryName}"/> is provided in the constructor.
    /// </para>
    /// </summary>
    public class WeatherDotGovApi : IWeatherDotGovApiWrapper, IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<WeatherDotGovApi> logger;

        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherDotGovApi"/>.
        /// An <see cref="HttpClient"/> with be created with each instance. It's recommended that this is created as a singleton if using this constructor.
        /// Logging will not be enabled
        /// </summary>
        public WeatherDotGovApi() : this(new NWSHttpClient(), NullLogger<WeatherDotGovApi>.Instance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherDotGovApi"/> class with the provided ILogger.
        /// An <see cref="HttpClient"/> with be created with each instance. It's recommended that this is created as a singleton if using this constructor.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public WeatherDotGovApi(ILogger<WeatherDotGovApi> logger) : this(new NWSHttpClient(), logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherDotGovApi"/> class with the provided HttpClient and the optional ILogger.
        /// If the ILogger is null, no logging functionality will be available with this instance.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="logger">The logger.</param>
        public WeatherDotGovApi(HttpClient client, ILogger<WeatherDotGovApi> logger = null)
        {
            //TODO verify 'user-agent' header and base address
            httpClient = client;

            this.logger = logger ?? NullLogger<WeatherDotGovApi>.Instance;
        }

        /// <summary>
        /// Gets the raw numerical forecast data for a 2.5km grid area designated by the wfo and grid coordinates.
        /// </summary>
        /// <param name="wfo">The WeatherForecast Office ID</param>
        /// <param name="gridX">The forecast grid x coordinate.</param>
        /// <param name="gridY">The forecast grid y coordinate.</param>
        /// <returns>A <see cref="WxGridpointJson"/> containing the forecast data for the grid.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">wfo - Must be a valid WeatherForecast Office Grid ID.</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxGridpointJson> GetGridpointJsonAsync(string wfo, int gridX, int gridY)
        {
            if (!wfo.IsValidWFO())
            {
                logger.LogInformation($"The user entered and Invalid WFO: {wfo}");
                throw new ArgumentOutOfRangeException(nameof(wfo), "Must be a valid WeatherForecast Office Grid ID.");
            }

            string endPoint = $"gridpoints/{wfo}/{gridX},{gridY}";

            try
            {
                return await httpClient.GetFromJsonAsync<WxGridpointJson>(endPoint, STJConfig.SerializeAllNWS);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the textual forecast for a 2.5km grid area designated by the wfo and grid coordinates.
        /// </summary>
        /// <param name="wfo">The WeatherForecast Office ID</param>
        /// <param name="gridX">The forecast grid x coordinate.</param>
        /// <param name="gridY">The forecast grid y coordinate.</param>
        /// <returns>A <see cref="WxGridpointForecastJson"/> containing the textual forecast data for the grid for the next 7 days.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">wfo - Must be a valid WeatherForecast Office Grid ID.</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxGridpointForecastJson> GetGridpointForecastJsonAsync(string wfo, int gridX, int gridY)
        {
            if (!wfo.IsValidWFO())
            {
                logger.LogInformation($"The user entered and Invalid WFO: {wfo}");
                throw new ArgumentOutOfRangeException(nameof(wfo), "Must be a valid WeatherForecast Office Grid ID.");
            }

            string endPoint = $"gridpoints/{wfo}/{gridX},{gridY}/forecast";

            try
            {
                return await httpClient.GetFromJsonAsync<WxGridpointForecastJson>(endPoint);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets an hourly textual forecast for a 2.5km grid area designated by the wfo and grid coordinates.
        /// </summary>
        /// <param name="wfo">The WeatherForecast Office ID</param>
        /// <param name="gridX">The forecast grid x coordinate.</param>
        /// <param name="gridY">The forecast grid y coordinate.</param>
        /// <returns>A <see cref="WxGridpointForecastJson"/> containing the textual forecast data for the grid for the next 156 hours.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">wfo - Must be a valid WeatherForecast Office Grid ID.</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxGridpointForecastJson> GetHourlyGridpointForecastJsonAsync(string wfo, int gridX, int gridY)
        {
            if (!wfo.IsValidWFO())
            {
                logger.LogInformation($"The user entered and Invalid WFO: {wfo}");
                throw new ArgumentOutOfRangeException(nameof(wfo), "Must be a valid WeatherForecast Office Grid ID.");
            }

            string endPoint = $"gridpoints/{wfo}/{gridX},{gridY}/forecast/hourly";

            try
            {
                return await httpClient.GetFromJsonAsync<WxGridpointForecastJson>(endPoint);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// <para>Get all the observation stations for a given location, designated by the latitude and longitude.</para>
        /// <para>Makes a call first to get the Gridpoint associated with the given latitude and longitude.</para>
        /// </summary>
        /// <param name="lat">The latitude of the requested location</param>
        /// <param name="lon">The longitude of the requested locaiton</param>
        /// <returns>A <see cref="WxObservationStationCollectionJson"/> containing all the observation stations for the requested location</returns>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxObservationStationCollectionJson> GetObservationStationsCollectionJsonAsync(decimal lat, decimal lon)
        {
            try
            {
                var gridPoint = await GetPointAsync(lat, lon);
                return await GetObservationStationsCollectionJsonAsync(gridPoint.GridId, gridPoint.GridX, gridPoint.GridY);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of observation stations usable for a given 2.5km grid, designated by the WeatherForecast Office ID and grid points.
        /// </summary>
        /// <param name="wfo">The Weather Forecast Office identifier for the given </param>
        /// <param name="gridX">Forecast grid X coordinate</param>
        /// <param name="gridY">Forecast grid y coordinate</param>
        /// <returns>A <see cref="WxObservationStationCollectionJson"/> containing all the observation stations for the requested location</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">wfo - Must be a valid WeatherForecast Office Grid ID.</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxObservationStationCollectionJson> GetObservationStationsCollectionJsonAsync(string wfo, int gridX, int gridY)
        {
            if (!wfo.IsValidWFO())
            {
                logger.LogInformation($"The user entered and Invalid WFO: {wfo}");
                throw new ArgumentOutOfRangeException(nameof(wfo), "Must be a valid WeatherForecast Office Grid ID.");
            }

            string gridStationsEndpoint = $"gridpoint/{wfo}/{gridX},{gridY}/stations";

            try
            {
                return await httpClient.GetFromJsonAsync<WxObservationStationCollectionJson>(gridStationsEndpoint);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of observations for a station.
        /// </summary>
        /// <param name="stationId">The Station Identifier for the station to check.</param>
        /// <returns>A <see cref="WxObservationCollectionJson"/> containing current weather data conditions.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">stationId - The Station Id cannot be null or empty space.</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxObservationCollectionJson> GetObservationCollectionJsonAsync(string stationId)
        {
            if (string.IsNullOrWhiteSpace(stationId))
            {
                logger.LogInformation($"The user entered and Invalid Station Id: {stationId}");
                throw new ArgumentNullException(nameof(stationId), "The Station Id cannot be null or empty space.");
            }

            string endPoint = $"stations/{stationId}/observations";

            try
            {
                return await httpClient.GetFromJsonAsync<WxObservationCollectionJson>(endPoint);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the latest observation for a station.
        /// </summary>
        /// <param name="stationId">The Station Identifier for the station to check.</param>
        /// <returns>A <see cref="WxObservationJson"/> containing current weather data conditions.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">stationId - The Station Id cannot be null or empty space.</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxObservationJson> GetLatestObservationJsonAsync(string stationId)
        {
            if (string.IsNullOrWhiteSpace(stationId))
            {
                logger.LogInformation($"The user entered and Invalid Station Id: {stationId}");
                throw new ArgumentNullException(nameof(stationId), "The Station Id cannot be null or empty space.");
            }

            string endPoint = $"stations/{stationId}/observations/latest";

            try
            {
                return await httpClient.GetFromJsonAsync<WxObservationJson>(endPoint);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific observation for a station, designated by the given time.
        /// </summary>
        /// <param name="stationId">The Station Identifier for the station to check.</param>
        /// <param name="time">The request observation time</param>
        /// <returns>A <see cref="WxObservationJson"/> containing current weather data conditions.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">stationId - The Station Id cannot be null or empty space.</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxObservationJson> GetSpecifiedObservationJsonAsync(string stationId, string time)
        {
            if (string.IsNullOrWhiteSpace(stationId))
            {
                logger.LogInformation($"The user entered and Invalid Station Id: {stationId}");
                throw new ArgumentNullException(nameof(stationId), "The Station Id cannot be null or empty space.");
            }

            if (string.IsNullOrWhiteSpace(time))
            {
                throw new ArgumentException($"'{nameof(time)}' cannot be null or whitespace.", nameof(time));
            }

            string endPoint = $"stations/{stationId}/observations/latest";

            try
            {
                return await httpClient.GetFromJsonAsync<WxObservationJson>(endPoint);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the information about the given latitude and longitude point.
        /// </summary>
        /// <param name="lat">The latitude of the given point.</param>
        /// <param name="lon">The longitude of the point.</param>
        /// <returns>A <see cref="WxPointJson"/> containing the metadata for the given latitude and longitude</returns>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxPointJson> GetPointAsync(decimal lat, decimal lon)
        {
            var pointsEndPoint = $"/points/{lat},{lon}";

            try
            {
                return await httpClient.GetFromJsonAsync<WxPointJson>(pointsEndPoint);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all weather stations for a given state from the API
        /// </summary>
        /// <param name="state">The two character state abbreviation</param>
        /// <returns>A <see cref="WxObservationStationCollectionJson" /> containing data for all of the weather stations for the given state.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">state - Must be a 2 character string representing the State (i.e, 'TX', 'VA')</exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="JsonException"></exception>
        public async Task<WxObservationStationCollectionJson> GetStateObservationStationCollectionJsonAsync(string state)
        {
            if (string.IsNullOrWhiteSpace(state) || state.Length > 2)
            {
                logger.LogInformation($"The user entered and Invalid State: {state}");
                throw new ArgumentOutOfRangeException(nameof(state), "Must be a 2 character string representing the State (i.e, 'TX', 'VA')");
            }

            try
            {
                return await httpClient.GetFromJsonAsync<WxObservationStationCollectionJson>($"stations?state={state}");
            }
            catch (HttpRequestException ex)
            {
                logger.LogError("The HttpRequest was not successful: {@Exception}", ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                logger.LogError("The Json Format was not support: {@Exception}", ex);
                throw;
            }
            catch (JsonException ex)
            {
                logger.LogError("There was a Json Exception: {@Exception}", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError("There was an unexpected exception: {@Exception}", ex);
                throw;
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Indicates if disposing was called.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                }

                isDisposed = true;
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}