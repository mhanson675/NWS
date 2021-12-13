using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NWS.Models.Serializing.STJ.Converters;
using NWS.Models.Serializing.STJ.Policies;

namespace NWS.Models.Serializing.STJ.Tests.Fixtures
{
    public class SerializerOptionsFixture : IDisposable
    {
        public SerializerOptionsFixture()
        {
            DeserializeOptions = STJConfig.SerializeAllNWS;

            SerializeOptions = DeserializeOptions;
            //SerializeOptions = new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = new ObjectIdentifierNamingPolicy(),
            //    IgnoreNullValues = true,
            //    Converters = {new QuantitativeValueConverter()}
            //};
        }

        public JsonSerializerOptions SerializeOptions { get; private set; }

        public JsonSerializerOptions DeserializeOptions { get; private set; }

        public void Dispose()
        {
        }
    }
}
