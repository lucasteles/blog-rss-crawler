using System;
using System.Collections.Generic;

namespace blog.io.services
{
    public class PostViewModel
    {

        public PostViewModel(Post post)
        {
            Title = post.Title;
            Date = post.Date;
            Author = post.Author;
            Tags = post.Tags;
            Description = post.Description;
            Path = post.Path;
            Id = post.Id;
        }
        public string Title { get; }
        public DateTime Date { get; }
        public string Author { get; }
        public IReadOnlyCollection<string> Tags { get; }
        public string Description { get; }
        public string Path { get; }
        public int Id { get; }
    }
}
