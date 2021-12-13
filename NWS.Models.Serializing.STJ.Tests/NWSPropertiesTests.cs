using System.IO;
using System.Linq;
using System.Text.Json;
using NWS.Models.JsonLdFeatures;
using NWS.Models.JsonLdProperties;
using NWS.Models.Serializing.STJ.Tests.Fixtures;
using Xunit;

namespace NWS.Models.Serializing.STJ.Tests
{
    public class NWSPropertiesTests : IClassFixture<SerializerOptionsFixture>
    {
        private readonly JsonSerializerOptions deserializeOptions;
        private readonly JsonSerializerOptions serializeOptions;
        private const string Folder = "JsonFiles";
        private const string SubFolder = "NWSProperties";

        public NWSPropertiesTests(SerializerOptionsFixture fixture)
        {
            deserializeOptions = fixture.DeserializeOptions;
            serializeOptions = fixture.SerializeOptions;
        }

        [Fact]
        public void QuantitativeValueTest()
        {
            // ARRANGE
            const string fileName = "quantitativevalue.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "");

            // ACT
            QuantitativeValue qv1 = JsonSerializer.Deserialize<QuantitativeValue>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(qv1, serializeOptions);
            QuantitativeValue qv2 = JsonSerializer.Deserialize<QuantitativeValue>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(qv1);
            Assert.NotNull(qv1.Value);
            Assert.NotNull(qv1.MaxValue);
            Assert.NotNull(qv1.MinValue);
            Assert.NotNull(qv1.UnitCode);
            Assert.NotNull(qv1.QualityControl);
            Assert.Equal(qv1, qv2);
        }

        [Fact]
        public void GridpointForecastPeriodTest()
        {
            // ARRANGE
            const string fileName = "gridpointforecastperiod.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointForecastPeriod period1 = JsonSerializer.Deserialize<WxGridpointForecastPeriod>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(period1, serializeOptions);
            WxGridpointForecastPeriod period2 = JsonSerializer.Deserialize<WxGridpointForecastPeriod>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(period1);
            Assert.Equal(period1, period2);
            Assert.NotNull(period1.Temperature);
            Assert.NotNull(period1.WindSpeed);
            Assert.Null(period1.WindGust);
            Assert.Equal(1, period1.Number);
            Assert.Equal("This Afternoon", period1.Name);
            Assert.Equal("2021-12-08T13:00:00-06:00", period1.StartTime);
            Assert.Equal("2021-12-08T18:00:00-06:00", period1.EndTime);
            Assert.True(period1.IsDaytime);
            Assert.Equal("SSE", period1.WindDirection);
            Assert.Equal("Sunny", period1.ShortForecast);
            Assert.Equal("Sunny, with a high near 78. South southeast wind around 5 mph.", period1.DetailedForecast);
        }

        [Fact]
        public void ObservationStationTest()
        {
            // ARRANGE
            const string fileName = "observationstation.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxObservationStationJson station1 = JsonSerializer.Deserialize<WxObservationStationJson>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(station1, serializeOptions);
            WxObservationStationJson station2 = JsonSerializer.Deserialize<WxObservationStationJson>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(station1);
            Assert.Equal(station1, station2);
            Assert.False(string.IsNullOrWhiteSpace(station1.Geometry));
            Assert.Equal("https://api.weather.gov/stations/KSSF", station1.Id);
            Assert.Equal("wx:ObservationStation", station1.Type);
            Assert.NotNull(station1.Elevation);
            Assert.Equal("KSSF", station1.StationIdentifier);
            Assert.Equal("San Antonio, Stinson Municipal Airport", station1.Name);
            Assert.Equal("America/Chicago", station1.TimeZone);
            Assert.Equal("https://api.weather.gov/zones/forecast/TXZ205", station1.Forecast);
            Assert.Equal("https://api.weather.gov/zones/county/TXC029", station1.County);
            Assert.Equal("https://api.weather.gov/zones/fire/TXZ205", station1.FireWeatherZone);
        }

        [Fact]
        public void CloudlayerTest()
        {
            // ARRANGE
            const string content = "{\"base\":{\"unitCode\":\"wmoUnit:m\",\"value\":670},\"amount\":\"SCT\"}";

            // ACT
            CloudLayer layer1 = JsonSerializer.Deserialize<CloudLayer>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(layer1, serializeOptions);
            CloudLayer layer2 = JsonSerializer.Deserialize<CloudLayer>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(layer1);
            Assert.NotNull(layer1.Base);
            Assert.False(string.IsNullOrWhiteSpace(layer1.Amount));
            Assert.Equal("SCT", layer1.Amount);
            Assert.Equal(670, layer1.Base.Value);
            Assert.Equal(layer1, layer2);
        }

        [Fact]
        public void MetarPhenomenonTests()
        {
            // ARRANGE
            const string content = "{\"intensity\": \"light\",\"modifier\": \"patches\",\"weather\": \"fog_mist\",\"rawString\": \"string\",\"inVicinity\":true}";

            // ACT
            MetarPhenomenon metar1 = JsonSerializer.Deserialize<MetarPhenomenon>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(metar1, serializeOptions);
            MetarPhenomenon metar2 = JsonSerializer.Deserialize<MetarPhenomenon>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(metar1);
            Assert.Equal("light", metar1.Intensity);
            Assert.Equal("patches", metar1.Modifier);
            Assert.Equal("fog_mist", metar1.Weather);
            Assert.Equal("string", metar1.RawString);
            Assert.True(metar1.InVicinity);
            Assert.Equal(metar1, metar2);
        }

        [Fact]
        public void ObservationTests()
        {
            // ARRANGE
            const string fileName = "observation.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxObservationJson observation1 = JsonSerializer.Deserialize<WxObservationJson>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(observation1, serializeOptions);
            WxObservationJson observation2 = JsonSerializer.Deserialize<WxObservationJson>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(observation1);
            Assert.False(string.IsNullOrWhiteSpace(observation1.Geometry));
            Assert.Equal("https://api.weather.gov/stations/KSSF/observations/2021-12-09T18:53:00+00:00", observation1.Id);
            Assert.Equal("wx:ObservationStation", observation1.Type);
            Assert.NotNull(observation1.Elevation);
            Assert.Contains("KSSF", observation1.RawMessage);
            Assert.NotNull(observation1.PresentWeather);
            Assert.Equal("light", observation1.PresentWeather.First().Intensity);
            Assert.Equal(26.100000000000001, observation1.Temperature.Value.Value);
            Assert.Equal(observation1.Id, observation2.Id);
        }

        [Fact]
        public void GridpointQuantitativeValueTest()
        {
            // ARRANGE
            const string fileName = "wxgridpointquantitativevalue.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointPropertyLayer.WxGridpointQuantitativeValue value1 = JsonSerializer.Deserialize<WxGridpointPropertyLayer.WxGridpointQuantitativeValue>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(value1, serializeOptions);
            WxGridpointPropertyLayer.WxGridpointQuantitativeValue value2 = JsonSerializer.Deserialize<WxGridpointPropertyLayer.WxGridpointQuantitativeValue>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(value1);
            Assert.False(string.IsNullOrWhiteSpace(value1.ValidTime));
            Assert.Equal("2021-12-10T06:00:00+00:00/PT1H", value1.ValidTime);
            Assert.Equal(21.666666666666668, value1.Value);
            Assert.Equal(value1, value2);
        }

        [Fact]
        public void GridpointPropertyLayerTest()
        {
            // ARRANGE
            const string fileName = "wxgridpointpropertylayer.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointPropertyLayer property1 = JsonSerializer.Deserialize<WxGridpointPropertyLayer>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(property1, serializeOptions);
            WxGridpointPropertyLayer property2 = JsonSerializer.Deserialize<WxGridpointPropertyLayer>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(property1);
            Assert.False(string.IsNullOrWhiteSpace(property1.Uom));
            Assert.NotEmpty(property1.Values);
            Assert.Equal("2021-12-10T06:00:00+00:00/PT1H", property1.Values.First().ValidTime);
            Assert.Equal(21.666666666666668, property1.Values.First().Value);
            Assert.Equal(property1.Uom, property2.Uom);
            Assert.Equal(property1.Values.First(), property2.Values.First());
        }

        [Fact]
        public void GridpointHazardsQuantitativeValueTest()
        {
            // ARRANGE
            const string fileName = "wxgridpointhazardsquantitativevalue.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue value1 = JsonSerializer.Deserialize<WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(value1, serializeOptions);
            WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue value2 = JsonSerializer.Deserialize<WxGridpointHazardsLayer.WxGridpointHazardsQuantitativeValue>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(value1);
            Assert.Equal("string", value1.Phenomenon);
            Assert.Equal("string", value1.Significance);
            Assert.Equal(1, value1.EventNumber.Value);
            Assert.Equal(value1, value2);
        }

        [Fact]
        public void GridpointHazardsTest()
        {
            // ARRANGE
            const string fileName = "wxgridpointhazards.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointHazardsLayer.WxGridpointHazards hazard1 = JsonSerializer.Deserialize<WxGridpointHazardsLayer.WxGridpointHazards>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(hazard1, serializeOptions);
            WxGridpointHazardsLayer.WxGridpointHazards hazard2 = JsonSerializer.Deserialize<WxGridpointHazardsLayer.WxGridpointHazards>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(hazard1);
            Assert.Equal("2021 -12-10T06:00:00+00:00/PT10H", hazard1.ValidTime);
            Assert.Equal("string", hazard1.Value.First().Phenomenon);
            Assert.Equal("string", hazard1.Value.First().Significance);
            Assert.Equal(1, hazard1.Value.First().EventNumber.Value);
            Assert.Equal(hazard1.ValidTime, hazard2.ValidTime);
            Assert.Equal(hazard1.Value.First().EventNumber.Value, hazard2.Value.First().EventNumber.Value);
        }

        [Fact]
        public void GridpointHazardsLayerTest()
        {
            // ARRANGE
            const string fileName = "wxgridpointhazardslayer.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointHazardsLayer layer1 = JsonSerializer.Deserialize<WxGridpointHazardsLayer>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(layer1, serializeOptions);
            WxGridpointHazardsLayer layer2 = JsonSerializer.Deserialize<WxGridpointHazardsLayer>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(layer1);
            Assert.Equal("2021 -12-10T06:00:00+00:00/PT10H", layer1.Values.First().ValidTime);
            Assert.Equal("string", layer1.Values.First().Value.First().Phenomenon);
            Assert.Equal("string", layer1.Values.First().Value.First().Significance);
            Assert.Equal(1, layer1.Values.First().Value.First().EventNumber.Value);
            Assert.Equal(layer1.Values.First().ValidTime, layer2.Values.First().ValidTime);
            Assert.Equal(layer1.Values.First().Value.First().EventNumber.Value, layer2.Values.First().Value.First().EventNumber.Value);
        }

        [Fact]
        public void GridpointWeatherQuantitativeValueTest()
        {
            // ARRANGE
            const string fileName = "wxgridpointweatherquantitativevalue.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointWeatherLayer.WxGridpointWeatherQuantitativeValue value1 = JsonSerializer.Deserialize<WxGridpointWeatherLayer.WxGridpointWeatherQuantitativeValue>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(value1, serializeOptions);
            WxGridpointWeatherLayer.WxGridpointWeatherQuantitativeValue value2 = JsonSerializer.Deserialize<WxGridpointWeatherLayer.WxGridpointWeatherQuantitativeValue>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(value1);
            Assert.Equal("areas", value1.Coverage);
            Assert.Equal("fog", value1.Weather);
            Assert.Null(value1.Intensity);
            Assert.Equal("wmoUnit:km", value1.Visibility.UnitCode);
            Assert.Contains("heavy_rain", value1.Attributes);
            Assert.Equal(value1.Coverage, value2.Coverage);
            Assert.Equal(value1.Weather, value2.Weather);
            Assert.Equal(value1.Intensity, value2.Intensity);
        }

        [Fact]
        public void GridpointWeatherTest()
        {
            // ARRANGE
            const string fileName = "wxgridpointweather.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointWeatherLayer.WxGridpointWeather weather1 = JsonSerializer.Deserialize<WxGridpointWeatherLayer.WxGridpointWeather>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(weather1, serializeOptions);
            WxGridpointWeatherLayer.WxGridpointWeather weather2 = JsonSerializer.Deserialize<WxGridpointWeatherLayer.WxGridpointWeather>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(weather1);
            Assert.Equal("2021-12-10T06:00:00+00:00/PT10H", weather1.ValidTime);
            Assert.Equal("areas", weather1.Value.First().Coverage);
            Assert.Equal("fog", weather1.Value.First().Weather);
            Assert.Null(weather1.Value.First().Intensity);
            Assert.Equal("wmoUnit:km", weather1.Value.First().Visibility.UnitCode);
            Assert.Contains("heavy_rain", weather1.Value.First().Attributes);
            Assert.Equal(weather1.Value.First().Coverage, weather2.Value.First().Coverage);
            Assert.Equal(weather1.Value.First().Weather, weather2.Value.First().Weather);
            Assert.Equal(weather1.Value.First().Intensity, weather2.Value.First().Intensity);
        }

        [Fact]
        public void GridpointWeatherLayerTest()
        {
            // ARRANGE
            const string fileName = "wxgridpointweatherlayer.json";
            string filePath = Path.Combine(Folder, SubFolder, fileName);
            string content = File.ReadAllText(filePath).Replace("\r", "").Replace("\n", "").Replace("\t", "");

            // ACT
            WxGridpointWeatherLayer weather1 = JsonSerializer.Deserialize<WxGridpointWeatherLayer>(content, deserializeOptions);
            string content2 = JsonSerializer.Serialize(weather1, serializeOptions);
            WxGridpointWeatherLayer weather2 = JsonSerializer.Deserialize<WxGridpointWeatherLayer>(content2, deserializeOptions);

            // ASSERT
            Assert.NotNull(weather1);
            Assert.Equal("2021-12-10T06:00:00+00:00/PT10H", weather1.Values.First().ValidTime);
            Assert.Equal("areas", weather1.Values.First().Value.First().Coverage);
            Assert.Equal("fog", weather1.Values.First().Value.First().Weather);
            Assert.Null(weather1.Values.First().Value.First().Intensity);
            Assert.Equal("wmoUnit:km", weather1.Values.First().Value.First().Visibility.UnitCode);
            Assert.Contains("heavy_rain", weather1.Values.First().Value.First().Attributes);
            Assert.Equal(weather1.Values.First().Value.First().Coverage, weather2.Values.First().Value.First().Coverage);
            Assert.Equal(weather1.Values.First().Value.First().Weather, weather2.Values.First().Value.First().Weather);
            Assert.Equal(weather1.Values.First().Value.First().Intensity, weather2.Values.First().Value.First().Intensity);
        }
    }
}