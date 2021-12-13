using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NWS.APIClient.Tests.TestUtilities
{
    public class HttpClientMock : HttpClient
    {
        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}