using Xunit;
using blog.io.services;

namespace blog.io.services.test
{
    public class RssReaderTests
    {
        [Fact]
        public void Should_return_empty_in_a_empty_rss_feed()
        {
            var httpClient = new HttpClient();
            var reader = new RssReader();


        }
    }
}
