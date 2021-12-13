using System.IO;
using System.Linq;
using System.Text.Json;
using NWS.Models.JsonLdFeatures;
using NWS.Models.Serializing.STJ.Tests.Fixtures;
using Xunit;

namespace NWS.Models.Serializing.STJ.Tests
{
    public class NWSFeaturesTests : IClassFixture<SerializerOptionsFixture>
    {
        private readonly JsonSerializerOptions options;
        private const string Folder = "JsonFiles";
        private const string SubFolder = "NWSFeatures";

        public NWSFeaturesTests(SerializerOptionsFixture fixture)
        {
            options = fixture.DeserializeOptions;
        }

        [Fact]
        public void RelativeLocationJsonTest()
        {
            //ACT
            const string fileName = "relativelocationjson.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            //ARRANGE
            WxRelativeLocationJson geo1 = JsonSerializer.Deserialize<WxRelativeLocationJson>(content, options);
            string content2 = JsonSerializer.Serialize(geo1, options);
            WxRelativeLocationJson geo2 = JsonSerializer.Deserialize<WxRelativeLocationJson>(content2, options);

            //ASSERT
            Assert.NotNull(geo1);
            Assert.NotNull(geo1.Geometry);
            Assert.NotNull(geo1.Bearing);
            Assert.NotNull(geo1.Distance);
            Assert.True(geo1.Equals(geo2));
            Assert.Equal("Lackland AFB", geo1.City);
            Assert.Equal("TX", geo1.State);
            Assert.Equal("wmoUnit:m", geo1.Distance.UnitCode);
            Assert.Equal(1089.4165776656, geo1.Distance.Value);
            Assert.Equal("wmoUnit:degree_(angle)", geo1.Bearing.UnitCode);
            Assert.Equal(257, geo1.Bearing.Value);
        }

        [Fact]
        public void PointJsonTest()
        {
            //ACT
            const string fileName = "pointjson.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");

            //ARRANGE
            WxPointJson geo1 = JsonSerializer.Deserialize<WxPointJson>(content, options);
            string content2 = JsonSerializer.Serialize(geo1, options);
            WxPointJson geo2 = JsonSerializer.Deserialize<WxPointJson>(content2, options);

            //ASSERT
            Assert.NotNull(geo1);
            Assert.NotNull(geo1.Geometry);
            Assert.NotNull(geo1);
            Assert.NotNull(geo1.RelativeLocation);
            Assert.NotNull(geo1.RelativeLocation.Bearing);
            Assert.NotNull(geo1.RelativeLocation.Distance);
            Assert.True(geo1.Equals(geo2));
            Assert.Equal(geo1.RelativeLocation, geo2.RelativeLocation);
        }

        [Fact]
        public void GridpointForecastTest()
        {
            // ARRANGE
            const string fileName = "gridpointforecast.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointForecastJson forecast1 = JsonSerializer.Deserialize<WxGridpointForecastJson>(content, options);
            string content2 = JsonSerializer.Serialize(forecast1, options);
            WxGridpointForecastJson forecast2 = JsonSerializer.Deserialize<WxGridpointForecastJson>(content2, options);

            // ASSERT
            Assert.NotNull(forecast1);
            Assert.NotNull(forecast1.Periods);
            Assert.NotNull(forecast1.Periods.First().Temperature);
            Assert.NotNull(forecast1.Periods.First().WindSpeed);
            Assert.Null(forecast1.Periods.First().WindGust);
            Assert.Equal(1, forecast1.Periods.First().Number);
            Assert.Equal("This Afternoon", forecast1.Periods.First().Name);
            Assert.Equal("2021-12-08T13:00:00-06:00", forecast1.Periods.First().StartTime);
            Assert.Equal("2021-12-08T18:00:00-06:00", forecast1.Periods.First().EndTime);
            Assert.True(forecast1.Periods.First().IsDaytime);
            Assert.Equal("SSE", forecast1.Periods.First().WindDirection);
            Assert.Equal("Sunny", forecast1.Periods.First().ShortForecast);
            Assert.Equal("Sunny, with a high near 78. South southeast wind around 5 mph.", forecast1.Periods.First().DetailedForecast);
            Assert.Equal(forecast1.Periods.First(), forecast2.Periods.First());
        }

        [Fact]
        public void ObservationStationCollectionTest()
        {
            // ARRANGE
            const string fileName = "observationstationcollection.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxObservationStationCollectionJson collection1 = JsonSerializer.Deserialize<WxObservationStationCollectionJson>(content, options);
            string content2 = JsonSerializer.Serialize(collection1, options);
            WxObservationStationCollectionJson collection2 = JsonSerializer.Deserialize<WxObservationStationCollectionJson>(content2, options);

            // ASSERT
            Assert.NotNull(collection1);
            Assert.NotNull(collection1.Stations);
            Assert.NotEmpty(collection1.Stations);
            Assert.NotNull(collection1.StationUrls);
            Assert.NotEmpty(collection1.StationUrls);
            Assert.Equal("https://api.weather.gov/stations/KSSF", collection1.StationUrls.First());
            Assert.Equal("https://api.weather.gov/stations/KSSF", collection1.Stations.First().Id);
            Assert.Equal("wx:ObservationStation", collection1.Stations.First().Type);
            Assert.Equal("POINT(-98.47167 29.33889)", collection1.Stations.First().Geometry);
            Assert.Equal("wmoUnit:m", collection1.Stations.First().Elevation.UnitCode);
            Assert.Equal(174.95519999999999, collection1.Stations.First().Elevation.Value);
            Assert.Equal("KSSF", collection1.Stations.First().StationIdentifier);
            Assert.Equal("San Antonio, Stinson Municipal Airport", collection1.Stations.First().Name);
            Assert.Equal("America/Chicago", collection1.Stations.First().TimeZone);
            Assert.Equal("https://api.weather.gov/zones/forecast/TXZ205", collection1.Stations.First().Forecast);
            Assert.Equal("https://api.weather.gov/zones/county/TXC029", collection1.Stations.First().County);
            Assert.Equal("https://api.weather.gov/zones/fire/TXZ205", collection1.Stations.First().FireWeatherZone);
            Assert.Equal(collection1.Stations.Count(), collection2.Stations.Count());
            Assert.Equal(collection1.Stations.First(), collection2.Stations.First());
            Assert.Equal(collection1.StationUrls.Count(), collection2.StationUrls.Count());
            Assert.Equal(collection1.StationUrls.First(), collection2.StationUrls.First());
        }

        [Fact]
        public void ObservationCollectionTest()
        {
            // ARRANGE
            const string fileName = "stationobservations.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxObservationCollectionJson collection1 = JsonSerializer.Deserialize<WxObservationCollectionJson>(content, options);
            string content2 = JsonSerializer.Serialize(collection1, options);
            WxObservationCollectionJson collection2 = JsonSerializer.Deserialize<WxObservationCollectionJson>(content2, options);

            // ASSERT
            Assert.NotNull(collection1);
            Assert.NotNull(collection1.Observations);
            Assert.NotEmpty(collection1.Observations);
            Assert.Equal("wx:ObservationStation", collection1.Observations.First().Type);
            Assert.Equal("POINT(-98.47 29.33)", collection1.Observations.First().Geometry);
            Assert.Equal("wmoUnit:m", collection1.Observations.First().Elevation.UnitCode);
            Assert.Equal(176, collection1.Observations.First().Elevation.Value);
            Assert.Equal("https://api.weather.gov/stations/KSSF", collection1.Observations.First().Station);
            Assert.Equal("Cloudy", collection1.Observations.First().TextDescription);
            Assert.Contains("KSSF", collection1.Observations.First().RawMessage);
            Assert.NotNull(collection1.Observations.First().PresentWeather);
            Assert.Equal("light", collection1.Observations.First().PresentWeather.First().Intensity);
            Assert.Equal(26.100000000000001, collection1.Observations.First().Temperature.Value.Value);
            Assert.Equal(200, collection1.Observations.First().WindDirection.Value.Value);
            Assert.Equal(collection1.Observations.First().Id, collection2.Observations.First().Id);
            Assert.Equal(collection1.Observations.Count(), collection2.Observations.Count());
        }

        [Fact]
        public void GridpointTest()
        {
            // ARRANGE
            const string fileName = "gridpoint.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointJson gridpoint1 = JsonSerializer.Deserialize<WxGridpointJson>(content, options);
            string content2 = JsonSerializer.Serialize(gridpoint1, options);
            WxGridpointJson gridpoint2 = JsonSerializer.Deserialize<WxGridpointJson>(content2, options);

            // ASSERT
            Assert.NotNull(gridpoint1);
            Assert.Equal("https://api.weather.gov/gridpoints/EWX/120,52", gridpoint1.Id);
            Assert.Equal("wx:Gridpoint", gridpoint1.Type);
            Assert.Equal("2021-12-10T12:42:36+00:00", gridpoint1.UpdateTime);
            Assert.Equal("2021-12-10T06:00:00+00:00/P8DT6H", gridpoint1.ValidTimes);
            Assert.Equal(
                "POLYGON((-98.6468125 29.398185,-98.6461097 29.3754212,-98.6199894 29.3760313,-98.6206872 29.3987952,-98.6468125 29.398185))",
                gridpoint1.Geometry);
            Assert.Equal("wmoUnit:m", gridpoint1.Elevation.UnitCode);
            Assert.Equal(231.0384, gridpoint1.Elevation.Value.Value);
            Assert.Equal("https://api.weather.gov/offices/EWX", gridpoint1.ForecastOffice);
            Assert.Equal("EWX", gridpoint1.GridId);
            Assert.Equal("120", gridpoint1.GridX);
            Assert.Equal("52", gridpoint1.GridY);
            Assert.Equal("wmoUnit:degC", gridpoint1.Temperature.Uom);
            Assert.Equal("2021-12-10T06:00:00+00:00/PT1H", gridpoint1.Temperature.Values.First().ValidTime);
            Assert.Equal(21.666666666666668, gridpoint1.Temperature.Values.First().Value.Value);
            Assert.Equal("2021 -12-10T06:00:00+00:00/PT10H", gridpoint1.Hazards.Values.First().ValidTime);
            Assert.Equal("string", gridpoint1.Hazards.Values.First().Value.First().Phenomenon);
            Assert.Equal("string", gridpoint1.Hazards.Values.First().Value.First().Significance);
            Assert.Equal(1, gridpoint1.Hazards.Values.First().Value.First().EventNumber.Value);
            Assert.Equal(gridpoint1.Hazards.Values.First().ValidTime, gridpoint2.Hazards.Values.First().ValidTime);
            Assert.Equal(gridpoint1.Hazards.Values.First().Value.First().EventNumber.Value, gridpoint2.Hazards.Values.First().Value.First().EventNumber.Value);
        }
    }
}