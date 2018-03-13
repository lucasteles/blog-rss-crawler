using blog.io.common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Threading.Tasks;

namespace blog.io.services
{
    public static class GetFeed
    {
        [FunctionName(nameof(GetFeed))]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            if (!int.TryParse(req.Query["paged"], out var page))
                page = 1;

            var client = new HttpClient();
            var reader = new RssPostReader(client);
            var repository = new PostsRepository(reader);
            var feed = await repository.GetPagedFeed(page);

            return new RssResult(feed);
        }
    }

    public class RssResult : ActionResult
    {
        private string xml;

        public RssResult(string xml)
        {
            this.xml = xml;
        }


        public override void ExecuteResult(ActionContext context) => ExecuteResultAsync(context).Wait();

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (this.xml != null)
            {
                context.HttpContext.Response.Clear();
                context.HttpContext.Response.ContentType = "application/rss+xml";
                await context.HttpContext.Response.WriteAsync(xml);
            }
        }

    }

}
