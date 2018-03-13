using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace blog.io.common
{
    public class RssPostWriter
    {
        public async static Task<string> GetFeedAsync(IEnumerable<Post> posts)
        {
            var sw = new StringWriterWithEncoding(Encoding.UTF8);
            const string ExampleNs = "https://feed.lucasteles.net";

            using (var xmlWriter = XmlWriter.Create(sw, new XmlWriterSettings { Async = true, Indent = true }))
            {
                var attributes = new List<SyndicationAttribute>
                {
                    new SyndicationAttribute("xmlns:feed", ExampleNs)
                };

                var formatter = new RssFormatter(attributes, xmlWriter.Settings);
                var writer = new RssFeedWriter(xmlWriter, null, new RssFormatter() { UseCDATA = true });

                //
                // Add Title
                await writer.WriteTitle("Lucas Teles - Blog");

                //
                // Add Description
                await writer.WriteDescription("Tecnologia e inovação");

                //
                // Add Link
                await writer.Write(new SyndicationLink(new Uri("https://lucasteles.net")));

                //
                // Add managing editor
                await writer.Write(new SyndicationPerson("lucasteles", "eu@lucasteles.net", RssContributorTypes.ManagingEditor));

                //
                // Add publish date
                await writer.WritePubDate(DateTimeOffset.UtcNow);


                //
                // Add Items
                foreach (var post in posts)
                {
                    var item = new SyndicationItem
                    {
                        Id = $"https://lucasteles.net/p={post.Id}",
                        Title = post.Title,
                        Description = post.Description,
                        Published = post.Date,
                    };

                    item.AddLink(new SyndicationLink(new Uri($"https://lucasteles.net/{post.Path}")));
                    item.AddCategory(new SyndicationCategory("Technology"));
                    item.AddContributor(new SyndicationPerson("Lucas Teles", "eu@lucasteles.net"));

                    // Format the item as SyndicationContent
                    var content = new SyndicationContent(formatter.CreateContent(item));
                    content.AddField(new SyndicationContent("content:encoded", string.Empty, post.Content));

                    // Write
                    await writer.Write(content);

                }

                //
                // Done
                xmlWriter.Flush();
            }

            return sw.ToString();
        }

        class StringWriterWithEncoding : StringWriter
        {
            private readonly Encoding _encoding;

            public StringWriterWithEncoding(Encoding encoding)
            {
                this._encoding = encoding;
            }

            public override Encoding Encoding
            {
                get { return _encoding; }
            }
        }
    }
}
