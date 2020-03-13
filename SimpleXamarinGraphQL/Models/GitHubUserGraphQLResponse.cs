namespace SimpleXamarinGraphQL
{
    public class GitHubUserGraphQLResponse
    {
        public GitHubUserGraphQLResponse(GitHubUser user) => User = user;

        public GitHubUser User { get; }
    }
}
