using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace blog.io.services
{
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
                context.HttpContext.Response.ContentType = "application/rss+xml; charset=utf-8";
                await context.HttpContext.Response.WriteAsync(xml);
            }
        }

    }
}
