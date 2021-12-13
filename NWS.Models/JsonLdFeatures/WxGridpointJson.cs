using NWS.Models.JsonLdProperties;

namespace NWS.Models.JsonLdFeatures
{
    public record WxGridpointJson
    {
        public string Id { get; init; }
        public string Type { get; init; } = "wx:Gridpoint";
        public string Geometry { get; init; }
        public string UpdateTime { get; init; }
        public string ValidTimes { get; init; }
        public QuantitativeValue Elevation { get; init; }
        public string ForecastOffice { get; init; }
        public string GridId { get; init; }
        public string GridX { get; init; }
        public string GridY { get; init; }

        public WxGridpointWeatherLayer Weather { get; init; }
        public WxGridpointHazardsLayer Hazards { get; init; }

        public WxGridpointPropertyLayer Temperature { get; init; }
        public WxGridpointPropertyLayer Dewpoint { get; init; }
        public WxGridpointPropertyLayer MaxTemperature { get; init; }
        public WxGridpointPropertyLayer MinTemperature { get; init; }
        public WxGridpointPropertyLayer RelativeHumidity { get; init; }
        public WxGridpointPropertyLayer ApparentTemperature { get; init; }
        public WxGridpointPropertyLayer HeatIndex { get; init; }
        public WxGridpointPropertyLayer WindChill { get; init; }
        public WxGridpointPropertyLayer SkyCover { get; init; }
        public WxGridpointPropertyLayer WindDirection { get; init; }
        public WxGridpointPropertyLayer WindSpeed { get; init; }
        public WxGridpointPropertyLayer WindGust { get; init; }
        public WxGridpointPropertyLayer ProbabilityOfPrecipitation { get; init; }
        public WxGridpointPropertyLayer QuantitativePrecipitation { get; init; }
        public WxGridpointPropertyLayer IceAccumulation { get; init; }
        public WxGridpointPropertyLayer SnowfallAmount { get; init; }
        public WxGridpointPropertyLayer SnowLevel { get; init; }
        public WxGridpointPropertyLayer CeilingHeight { get; init; }
        public WxGridpointPropertyLayer Visibility { get; init; }
        public WxGridpointPropertyLayer TransportWindSpeed { get; init; }
        public WxGridpointPropertyLayer TransportWindDirection { get; init; }
        public WxGridpointPropertyLayer MixingHeight { get; init; }
        public WxGridpointPropertyLayer HainesIndex { get; init; }
        public WxGridpointPropertyLayer LightningActivityLevel { get; init; }
        public WxGridpointPropertyLayer TwentyFootWindSpeed { get; init; }
        public WxGridpointPropertyLayer TwentyFootWindDirection { get; init; }
        public WxGridpointPropertyLayer WaveHeight { get; init; }
        public WxGridpointPropertyLayer WavePeriod { get; init; }
        public WxGridpointPropertyLayer WaveDirection { get; init; }
        public WxGridpointPropertyLayer PrimarySwellHeight { get; init; }
        public WxGridpointPropertyLayer PrimarySwellDirection { get; init; }
        public WxGridpointPropertyLayer SecondarySwellHeight { get; init; }
        public WxGridpointPropertyLayer SecondarySwellDirection { get; init; }
        public WxGridpointPropertyLayer WavePeriod2 { get; init; }
        public WxGridpointPropertyLayer WindWaveHeight { get; init; }
        public WxGridpointPropertyLayer DispersionIndex { get; init; }
        public WxGridpointPropertyLayer Pressure { get; init; }
        public WxGridpointPropertyLayer ProbabilityOfTropicalStormWinds { get; init; }
        public WxGridpointPropertyLayer ProbabilityOfHurricaneWinds { get; init; }
        public WxGridpointPropertyLayer PotentialOf15MphWinds { get; init; }
        public WxGridpointPropertyLayer PotentialOf25MphWinds { get; init; }
        public WxGridpointPropertyLayer PotentialOf35MphWinds { get; init; }
        public WxGridpointPropertyLayer PotentialOf45MphWinds { get; init; }
        public WxGridpointPropertyLayer PotentialOf20MphWindGusts { get; init; }
        public WxGridpointPropertyLayer PotentialOf30MphWindGusts { get; init; }
        public WxGridpointPropertyLayer PotentialOf40MphWindGusts { get; init; }
        public WxGridpointPropertyLayer PotentialOf50MphWindGusts { get; init; }
        public WxGridpointPropertyLayer PotentialOf60MphWindGusts { get; init; }
        public WxGridpointPropertyLayer GrasslandFireDangerIndex { get; init; }
        public WxGridpointPropertyLayer ProbabilityOfThunder { get; init; }
        public WxGridpointPropertyLayer DavisStabilityIndex { get; init; }
        public WxGridpointPropertyLayer AtmosphericDispersionIndex { get; init; }
        public WxGridpointPropertyLayer LowVisibilityOccurrenceRiskIndex { get; init; }
        public WxGridpointPropertyLayer Stability { get; init; }
        public WxGridpointPropertyLayer RedFlagThreatIndex { get; init; }
    }
}