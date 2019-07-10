using System;
using System.Threading.Tasks;
using GraphQL.Client.Http;
using GraphQL.Common.Request;
using ModernHttpClient;
using Polly;

namespace SimpleXamarinGraphQL
{
    public static class GitHubGraphQLService
    {
        #region Constant Fields
        static readonly Lazy<GraphQLHttpClient> _client = new Lazy<GraphQLHttpClient>(CreateGitHubGraphQLClient);
        #endregion

        #region Properties
        static GraphQLHttpClient Client => _client.Value;
        #endregion

        #region Methods
        public static async Task<GitHubUser> GetGitHubUser(string login)
        {
            var graphQLRequest = new GraphQLRequest
            {
                Query = "query { user(login: " + login + "){ name, company, createdAt, followers{ totalCount }}}"
            };

            var gitHubUserResponse = await ExecutePollyFunction(() => Client.SendQueryAsync(graphQLRequest)).ConfigureAwait(false);

            return gitHubUserResponse.GetDataFieldAs<GitHubUser>("user");
        }

        static GraphQLHttpClient CreateGitHubGraphQLClient()
        {
            var client = new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(GitHubConstants.GraphQLApiUrl),
                HttpMessageHandler = new NativeMessageHandler()
            });
            client.DefaultRequestHeaders.Add("Authorization", $"bearer {GitHubConstants.PersonalAccessToken}");
            client.DefaultRequestHeaders.Add("User-Agent", nameof(SimpleXamarinGraphQL));

            return client;
        }

        static Task<T> ExecutePollyFunction<T>(Func<Task<T>> action, int numRetries = 2)
        {
            return Policy.Handle<Exception>().WaitAndRetryAsync(numRetries, pollyRetryAttempt).ExecuteAsync(action);

            TimeSpan pollyRetryAttempt(int attemptNumber) => TimeSpan.FromSeconds(Math.Pow(2, attemptNumber));
        }
        #endregion
    }
}
