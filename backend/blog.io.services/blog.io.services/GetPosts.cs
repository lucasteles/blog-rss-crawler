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
    public static class GetPosts
    {
        [FunctionName(nameof(GetPosts))]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var ok = int.TryParse(req.Query["page"], out var page);
            ok &= int.TryParse(req.Query["qtd"], out var qtd);

            if (!ok)
                return new BadRequestObjectResult("Something went wrong, really really wrong");

            var client = new HttpClient();
            var reader = new RssPostReader(client);
            var repository = new PostsRepository(reader);
            var posts = await repository.GetPagedPosts(page, qtd);

            return new OkObjectResult(posts);
        }
    }
}
