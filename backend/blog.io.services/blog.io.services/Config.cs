using System;

namespace blog.io.services
{
    public static class Config
    {
        public static string PostAuthorName { get; }
        public static string FeedUrl { get; }
        public static DateTime LimitDate { get; }

        static Config()
        {
            PostAuthorName = Environment.GetEnvironmentVariable(nameof(PostAuthorName));
            FeedUrl = Environment.GetEnvironmentVariable(nameof(FeedUrl));
            if (DateTime.TryParse(Environment.GetEnvironmentVariable(nameof(LimitDate)), out var limitDate))
                LimitDate = limitDate;
            else
                LimitDate = DateTime.Now.Subtract(TimeSpan.FromDays(30 * 12));

        }
    }
}
