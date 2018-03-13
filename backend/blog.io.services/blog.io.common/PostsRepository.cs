using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.io.common
{
    public class PostsRepository
    {
        private readonly IRssPostReader reader;
        private readonly string urlFeeds;

        public DateTime Limit { get; }

        public PostsRepository(IRssPostReader reader, DateTime limit, string feedUrl)
        {
            this.reader = reader;
            this.Limit = limit;
            this.urlFeeds = feedUrl;
        }

        public async Task<IReadOnlyCollection<Post>> GetPagedPosts(int page, int qtd, string user)
        {
            var posts = await reader.ReadPostsAsync(urlFeeds, Limit);

            if (user != null)
                posts = posts.Where(e => e.Author.ToLowerInvariant().Contains(user.ToLowerInvariant()));

            posts =
                posts
                .Skip((page - 1) * qtd)
                .Take(qtd);


            return posts.ToArray();

        }

        public async Task<string> GetPagedFeed(int page, string user)
        {
            var posts = await GetPagedPosts(page, 10, user);
            var feed = await RssPostWriter.GetFeedAsync(posts);

            return feed;
        }

        public async Task<Option<Post>> GetPost(int id) =>
            (await reader.ReadPostsAsync(urlFeeds, Limit))
            .FirstOrDefault(e => e.Id == id);

        public async Task<Option<Post>> GetPost(string path) =>
           (await reader.ReadPostsAsync(urlFeeds, Limit))
           .FirstOrDefault(e => e.Path == path);

    }
}
