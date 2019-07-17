using Newtonsoft.Json;

namespace SimpleXamarinGraphQL
{
    public class Followers
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }
    }
}
