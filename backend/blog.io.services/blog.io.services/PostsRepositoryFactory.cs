using blog.io.common;
using System.Net.Http;

namespace blog.io.services
{
    public class PostsRepositoryFactory
    {
        public static PostsRepository Create()
        {
            var client = new HttpClient();
            var reader = new RssPostReader(client);
            return new PostsRepository(reader, Config.LimitDate, Config.FeedUrl);
        }
    }
}
