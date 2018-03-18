using blog.io.common;
using LanguageExt;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace blog.io
{
    public class RssPostReader : IRssPostReader
    {
        private readonly HttpClient httpClient;

        public RssPostReader(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<IEnumerable<Post>> ReadPostsAsync(string rssFeed, DateTime limit)
        {

            var parser = new RssParser();
            var ret = new List<Post>();
            var page = 0;

            while (true)
            {
                page++;
                var url = page == 1 ? rssFeed : rssFeed + $"?paged={page}";

                var response = await httpClient.GetAsync(url);
                var feedAsString = string.Empty;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    break;
                else
                    feedAsString = await response.Content.ReadAsStringAsync();

                using (var memoryFeed = new MemoryStream(Encoding.UTF8.GetBytes(feedAsString)))
                using (var xmlReader = XmlReader.Create(memoryFeed, new XmlReaderSettings { Async = true }))
                {
                    var feedReader = new RssFeedReader(xmlReader);
                    while (await feedReader.Read())
                    {

                        if (feedReader.ElementType == SyndicationElementType.Item)
                        {
                            var content = await feedReader.ReadContent();
                            var author = content.Fields.FirstOrDefault(f => f.Name == "creator");
                            var htmlContent = content.Fields.FirstOrDefault(f => f.Name == "encoded");

                            var item = parser.CreateItem(content);

                            var post = new Post
                            {
                                Id = int.Parse(item.Id.Split('=')[1]),
                                Title = item.Title,
                                Content = Cleaner.CleanAnnoyingOriginalBlogCitation(htmlContent?.Value),
                                Description = Cleaner.CleanAnnoyingOriginalBlogCitation(item.Description),
                                Date = item.Published.DateTime,
                                Path = item.Links.First()?.Uri.Segments.Last(),
                                Tags = item.Categories.Select(e => e.Name).ToArray(),
                                Author = author?.Value ?? string.Empty
                            };

                            if (post.Date >= limit)
                                ret.Add(post);
                        }
                    }

                    if (ret.Any() && ret.Min(e => e.Date) < limit)
                        break;

                }
            }

            return ret;
        }
    }
}
