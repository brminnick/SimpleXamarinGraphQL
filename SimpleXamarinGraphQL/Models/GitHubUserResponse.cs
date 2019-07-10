using System;
using System.Text;
using Newtonsoft.Json;

namespace SimpleXamarinGraphQL
{
    public class GitHubUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("followers")]
        public Followers Followers { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{nameof(Name)}: {Name}");
            stringBuilder.AppendLine($"{nameof(Company)}: {Company}");
            stringBuilder.AppendLine($"{nameof(CreatedAt)}: {CreatedAt}");
            stringBuilder.Append($"Followers: {Followers.TotalCount}");

            return stringBuilder.ToString();
        }
    }

    public class Followers
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }
    }
}
