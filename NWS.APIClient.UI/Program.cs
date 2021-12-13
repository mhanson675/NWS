using System;
using System.Threading.Tasks;

namespace NWS.APIClient.UI
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var api = new WeatherDotGovApi(new NWSHttpClient());
            var testRawResponse = await api.GetGridpointJsonAsync("EWX", 116, 58);

            Console.WriteLine($"ID: {testRawResponse.Id}");
            //Console.WriteLine($"{testRawResponse.Properties.Temperature.Values.First().Value}");

            foreach (var property in testRawResponse.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(testRawResponse, null)}");
            }
        }
    }
}