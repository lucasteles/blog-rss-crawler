using System;
using System.Collections.Generic;

namespace blog.io
{
    public class Post
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
    }
}
