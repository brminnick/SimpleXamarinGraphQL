using System;
using System.Text;
using Newtonsoft.Json;

namespace SimpleXamarinGraphQL
{
    public class GitHubUser
    {
        public GitHubUser()
        {

        }

        [JsonConstructor]
        public GitHubUser(string name, string company, DateTimeOffset createdAt, Followers followers) =>
            (Name, Company, CreatedAt, FollowersCount) = (name, company, createdAt, followers.TotalCount);

        public string Name { get; set; }

        public string Company { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public long FollowersCount { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{nameof(Name)}: {Name}");
            stringBuilder.AppendLine($"{nameof(Company)}: {Company}");
            stringBuilder.AppendLine($"{nameof(CreatedAt)}: {CreatedAt.ToString("d")}");
            stringBuilder.Append($"{nameof(FollowersCount)}: {FollowersCount}");

            return stringBuilder.ToString();
        }
    }
}
