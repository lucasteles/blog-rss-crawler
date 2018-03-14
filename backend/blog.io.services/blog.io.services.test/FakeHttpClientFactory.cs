using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace blog.io.services.test
{
    public class FakeHttpClientFactory
    {

        public static HttpClient Create(params string[] rssData)
        {
            var handler = new MockHandler(rssData);
            return new HttpClient(handler);
        }
    }

    public class MockHandler : HttpMessageHandler
    {
        private readonly string[] returnXml;

        public MockHandler(string[] returnXml)
        {
            this.returnXml = returnXml;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var query = HttpUtility.ParseQueryString(request.RequestUri.Query);
            var queryValue = query["paged"];

            var page = queryValue == null ? 0 : (int.Parse(queryValue) - 1);

            if (page >= returnXml.Length)
#pragma warning disable CC0022 // Should dispose object
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
#pragma warning restore CC0022 // Should dispose object

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(returnXml[page]),
            };

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/rss+xml");

            return Task.FromResult(response);
        }
    }
}
