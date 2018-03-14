using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace blog.io.services.test
{
    public class RssReaderTests
    {

        private string fake_url = "http://fake.com";

        [Fact]
        public async Task Should_return_empty_in_a_empty_rss_feed()
        {
            var httpClient = FakeHttpClientFactory.Create(RssData.Empty);
            var reader = new RssPostReader(httpClient);

            var posts = await reader.ReadPostsAsync(fake_url, DateTime.MinValue);

            posts.Should().BeEmpty();

        }

        [Fact]
        public async Task Should_return_data_from_rss_feed()
        {

            var httpClient = FakeHttpClientFactory.Create(RssData.Default);
            var reader = new RssPostReader(httpClient);

            var posts = await reader.ReadPostsAsync(fake_url, DateTime.MinValue);

            posts.Should().NotBeEmpty();
            posts.Should().HaveCount(1);

            var post = posts.First();
            var expected = new Post
            {
                Author = "Test",
                Content = "<p>teste!</p>",
                Date = new System.DateTime(2018, 3, 9, 14, 0, 26),
                Description = "<p>teste</p>\n",
                Path = "test",
                Id = 42,
                Tags = new[] { "c1", "c2", "c3" },
                Title = "Teste de post"
            };

            post.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Should_return_paged_data_from_rss_feed()
        {

            var httpClient = FakeHttpClientFactory.Create(RssData.Default, RssData.Default);
            var reader = new RssPostReader(httpClient);

            var posts = await reader.ReadPostsAsync(fake_url, DateTime.MinValue);

            posts.Should().NotBeEmpty();
            posts.Should().HaveCount(2);

            var expected = new Post
            {
                Author = "Test",
                Content = "<p>teste!</p>",
                Date = new DateTime(2018, 3, 9, 14, 0, 26),
                Description = "<p>teste</p>\n",
                Id = 42,
                Path = "test",
                Tags = new[] { "c1", "c2", "c3" },
                Title = "Teste de post"
            };

            posts.Should().AllBeEquivalentTo(expected);
        }



        [Fact]
        public async Task Should_return_respect_limit_date()
        {
            var httpClient = FakeHttpClientFactory.Create(RssData.OneYerLaterPost, RssData.Default);
            var reader = new RssPostReader(httpClient);

            var posts = await reader.ReadPostsAsync(fake_url, new DateTime(2019, 1, 1));

            posts.Should().NotBeEmpty();
            posts.Should().HaveCount(1);
            posts.First().Date.Year.Should().Be(2019);


        }
    }
}
