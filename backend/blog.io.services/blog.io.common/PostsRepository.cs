using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.io.common
{
    public class PostsRepository
    {
        private readonly IRssPostReader reader;
        const string urlFeeds = "http://high5devs.com/feed/";

        public PostsRepository(IRssPostReader reader)
        {
            this.reader = reader;
        }

        public async Task<IReadOnlyCollection<Post>> GetPagedPosts(int page, int qtd, string user = null)
        {
            var posts = await reader.ReadPostsAsync(urlFeeds);

            if (user != null)
                posts = posts.Where(e => e.Author.ToLowerInvariant().Contains(user.ToLowerInvariant()));

            posts =
                posts
                .Skip((page - 1) * qtd)
                .Take(qtd);


            return posts.ToArray();

        }

        public async Task<string> GetPagedFeed(int page)
        {
            var posts = await GetPagedPosts(page, 10);
            var feed = await RssPostWriter.GetFeedAsync(posts);

            return feed;
        }
    }
}
