using System.Text.RegularExpressions;

namespace blog.io.common
{
    public static class Cleaner
    {
        public static string CleanAnnoyingOriginalBlogCitation(string text) =>
            new Regex("<p>O post.*apareceu primeiro em.*</p>")
                .Replace(text, string.Empty);


    }
}
