using Newtonsoft.Json;

namespace SimpleXamarinGraphQL
{
    public class Followers
    {
        public Followers(long totalCount) => TotalCount = totalCount;

        public long TotalCount { get; }
    }
}
