using System.Threading.Tasks;
using NWS.Models.JsonLdFeatures;

namespace NWS.APIClient
{
    /// <summary>
    /// Interface for WeatherDotGovApi
    /// </summary>
#pragma warning disable CS1591

    public interface IWeatherDotGovApiWrapper
    {
        Task<WxGridpointForecastJson> GetHourlyGridpointForecastJsonAsync(string wfo, int gridX, int gridY);

        Task<WxObservationJson> GetLatestObservationJsonAsync(string stationId);

        Task<WxObservationCollectionJson> GetObservationCollectionJsonAsync(string stationId);

        Task<WxObservationStationCollectionJson> GetObservationStationsCollectionJsonAsync(decimal lat, decimal lon);

        Task<WxObservationStationCollectionJson> GetObservationStationsCollectionJsonAsync(string wfo, int gridX, int gridY);

        Task<WxGridpointJson> GetGridpointJsonAsync(string wfo, int gridX, int gridY);

        Task<WxObservationJson> GetSpecifiedObservationJsonAsync(string stationId, string time);

        Task<WxGridpointForecastJson> GetGridpointForecastJsonAsync(string wfo, int gridX, int gridY);
        
        Task<WxObservationStationCollectionJson> GetStateObservationStationCollectionJsonAsync(string state);
        
        Task<WxPointJson> GetPointAsync(decimal lat, decimal lon);
    }

#pragma warning restore CS1591
}