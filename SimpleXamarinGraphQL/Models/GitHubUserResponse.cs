using System;
using Newtonsoft.Json;

namespace SimpleXamarinGraphQL
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("followers")]
        public Followers Followers { get; set; }
    }

    public class Followers
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }
    }
}
