using System;
using System.Collections.Generic;
using System.Linq;

using Dict = System.Collections.Concurrent.ConcurrentDictionary<string,
    (System.Collections.Generic.IEnumerable<blog.io.Post> posts, System.DateTime created, System.TimeSpan expires)>;

namespace blog.io.common
{
    public class Cache
    {
        private static Dict _cache;

        static Cache() => _cache = new Dict();

        public static void Put(string key, IEnumerable<Post> posts, TimeSpan expireTime) =>
                _cache.AddOrUpdate(key, (posts, DateTime.UtcNow, expireTime), (a, b) => b);

        public static bool TryGet(string key, out IEnumerable<Post> posts)
        {
            posts = Enumerable.Empty<Post>();
            if (_cache.TryGetValue(key, out var data))
            {
                if (DateTime.UtcNow - data.created >= data.expires)
                    return false;

                posts = data.posts;
                Put(key, posts, data.expires);
                return true;
            }
            return false;

        }
    }
}
