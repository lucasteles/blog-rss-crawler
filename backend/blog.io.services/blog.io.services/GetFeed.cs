using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
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

            var repository = PostsRepositoryFactory.Create();
            var feed = await repository.GetPagedFeed(page, Config.PostAuthorName);

            return new RssResult(feed);
        }
    }



}
