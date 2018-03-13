using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blog.io
{
    public interface IRssPostReader
    {
        Task<IEnumerable<Post>> ReadPostsAsync(string rssFeed, DateTime limit);
    }
}