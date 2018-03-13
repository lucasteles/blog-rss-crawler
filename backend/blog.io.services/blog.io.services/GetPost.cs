using LanguageExt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;
using System.Threading.Tasks;

namespace blog.io.services
{
    public static class GetPost
    {
        [FunctionName(nameof(GetPost))]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            var value = req.Query["id"];

            if (!value.Any())
                return new BadRequestObjectResult("Bad id");

            var someId = value.ToString();
            Option<Post> somePost;

            var repository = PostsRepositoryFactory.Create();


            somePost = int.TryParse(someId, out var id)
                            ? await repository.GetPost(id)
                            : await repository.GetPost(someId);

            return somePost
                     .Some(p => (IActionResult)new OkObjectResult(p))
                     .None(() => new BadRequestObjectResult("Post not found"));

        }
    }
}
