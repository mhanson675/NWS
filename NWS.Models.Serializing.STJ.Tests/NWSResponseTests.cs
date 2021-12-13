using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using NWS.Models.JsonLdFeatures;
using NWS.Models.Serializing.STJ.Converters;
using NWS.Models.Serializing.STJ.Tests.Fixtures;
using Xunit;

// ReSharper disable StringLiteralTypo

namespace NWS.Models.Serializing.STJ.Tests
{
    public class NWSResponseTests : IClassFixture<SerializerOptionsFixture>
    {
        private readonly JsonSerializerOptions options;
        private const string Folder = "JsonFiles";
        private const string SubFolder = "NWSResponses";

        public NWSResponseTests(SerializerOptionsFixture fixture)
        {
            options = fixture.DeserializeOptions;
        }
        /*
        [Fact]
        public async Task Deserialize_GridPointsRawForecastResponse_Success()
        {
            var fileName = "rawforecastresponse.json";
            var filePath = Path.Combine(Folder, SubFolder, fileName);
            using var jsonFile = File.OpenRead(filePath);
            var response = await JsonSerializer.DeserializeAsync<Feature>(jsonFile, JsonConfig.SerializeAllOptions);

            Assert.NotNull(response);
            Assert.NotNull(response.Properties);
            Assert.NotNull(response.Geometry);
            //Assert.Equal("wmoUnit:degC", response.Properties["temperature"]);
            //Assert.Equal("2021-11-05T02:00:00+00:00/PT2H", response.Properties.Temperature.Values.First().ValidTime);
            //Assert.Equal(10.555555555555555m, response.Properties.Temperature.Values.First().Value);
        }
        */
        [Fact]
        public async Task Deserialize_GridPointsTextualForecastResponse_Success()
        {
            const string fileName = "gridpointstextualforecastresponse.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            await using FileStream jsonFile = File.OpenRead(filePath);
            WxGridpointForecastJson response = await JsonSerializer.DeserializeAsync<WxGridpointForecastJson>(jsonFile, options);

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Geometry));
            Assert.NotNull(response.Periods);
            Assert.NotNull(response.Periods.First().Temperature);
            Assert.Equal(27.222222222222221, response.Periods.First().Temperature.Value);
            Assert.True(response.Periods.First().IsDaytime);
        }

        [Fact]
        public async Task Deserialize_GridPointsHourlyTextualForecastResponse_Success()
        {
            const string fileName = "gridpointsforecasthourlyresponse.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            await using FileStream jsonFile = File.OpenRead(filePath);
            WxGridpointForecastJson response = await JsonSerializer.DeserializeAsync<WxGridpointForecastJson>(jsonFile, options);

            Assert.NotNull(response);
            Assert.False(string.IsNullOrWhiteSpace(response.Geometry));
            Assert.NotNull(response.Periods);
            Assert.NotNull(response.Periods.First().Temperature);
            Assert.Equal(17.777777777777779, response.Periods.First().Temperature.Value);
            Assert.True(response.Periods.First().IsDaytime);
        }

        /*
        [Fact]
        public async void Deserialize_StationsResponse_From_PointsStations_Success()
        {
            var fileName = "stationsresponse.json";
            var filePath = Path.Combine(Folder, SubFolder, fileName);
            using var jsonFile = File.OpenRead(filePath);
            var response = await JsonSerializer.DeserializeAsync<FeatureCollectionBase>(jsonFile, JsonConfig.SerializeAllOptions);

            Assert.NotNull(response);
            //Assert.NotNull(response.Stations);
            //Assert.Equal("KSSF", response.Stations.First().Properties.StationIdentifier);
            //Assert.Equal("KCVB", response.Stations.Skip(1).First().Properties.StationIdentifier);
        }

        [Fact]
        public async Task Deserialize_StationObservationsResponse_Success()
        {
            var fileName = "stationobservationsresponse.json";
            var filePath = Path.Combine(Folder, SubFolder, fileName);
            using var jsonFile = File.OpenRead(filePath);
            var response = await JsonSerializer.DeserializeAsync<FeatureCollectionBase>(jsonFile, JsonConfig.SerializeAllOptions);

            Assert.NotNull(response);
            //Assert.Equal(455, response.Observations.Count());
            //Assert.Equal(-79.5, response.Observations.First().Geometry.Coordinates.Longitude);
            //Assert.Equal(0.80000000000000004, response.Observations.First().Properties.Temperature.Value);
            //Assert.Equal("Clear", response.Observations.First().Properties.TextDescription);
        }

        [Fact]
        public async void Deserialize_StationObservationResponse_From_Latest_Success()
        {
            var fileName = "stationobservationslatestresponse.json";
            var filePath = Path.Combine(Folder, SubFolder, fileName);
            using var jsonFile = File.OpenRead(filePath);
            var response = await JsonSerializer.DeserializeAsync<Feature>(jsonFile, JsonConfig.SerializeAllOptions);

            Assert.NotNull(response);
            Assert.NotNull(response.Properties);
            //Assert.NotNull(response.Properties.CloudLayers);
            //Assert.NotNull(response.Properties.Temperature.Value);
            //Assert.Equal(6.5, response.Properties.Temperature.Value);
        }

        [Fact]
        public async void Deserialize_StationObservationResponse_From_Time_Success()
        {
            var fileName = "stationobservationsresponsetime.json";
            var filePath = Path.Combine(Folder, SubFolder, fileName);
            using var jsonFile = File.OpenRead(filePath);
            var response = await JsonSerializer.DeserializeAsync<Feature>(jsonFile, JsonConfig.SerializeAllOptions);

            Assert.NotNull(response);
            Assert.NotNull(response.Properties);
            //Assert.NotNull(response.Properties.CloudLayers);
            //Assert.NotNull(response.Properties.Temperature.Value);
            //Assert.Equal(0.80000000000000004, response.Properties.Temperature.Value);
            //Assert.Equal("Clear", response.Properties.TextDescription);
        }

        [Fact]
        public async void Deserialize_StationsResponse_From_StateStations_Success()
        {
            var fileName = "statestationsresponse.json";
            var filePath = Path.Combine(Folder, SubFolder, fileName);
            using var jsonFile = File.OpenRead(filePath);
            var response = await JsonSerializer.DeserializeAsync<FeatureCollectionBase>(jsonFile, JsonConfig.SerializeAllOptions);

            Assert.NotNull(response);
            //Assert.NotNull(response.Stations);
            //Assert.Equal("LBJT2", response.Stations.First().Properties.StationIdentifier);
            //Assert.Equal("BZRT2", response.Stations.Skip(1).First().Properties.StationIdentifier);
        }

        [Fact]
        public async Task Deserialize_PointsResponse_Success()
        {
            var fileName = "pointsresponse.json";
            var filePath = Path.Combine(Folder, SubFolder, fileName);
            using var jsonFile = File.OpenRead(filePath);
            var response = await JsonSerializer.DeserializeAsync<PointGeoJson>(jsonFile, JsonConfig.SerializeAllOptions);

            Assert.NotNull(response);
            Assert.NotNull(response.Properties);
            Assert.Equal("EWX", response.Properties.GridId);
            Assert.Equal(120, response.Properties.GridX);
            Assert.Equal(52, response.Properties.GridY);
        }
        */
    }
}