using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake.Http.Pipelines;
using SimpleXamarinGraphQL;

namespace SimpleXamarinGraphQL.Services
{
    public class GitHubClientFactory
    {
        public static IGitHubClient Create()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDefaultScalarSerializers();
            serviceCollection.AddGitHubClient();
            serviceCollection.AddHttpClient("GitHubClient", c =>
            {
                c.BaseAddress = new Uri(GitHubConstants.GraphQLApiUrl);
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "bearer", GitHubConstants.PersonalAccessToken);
                c.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(
                    new ProductHeaderValue("SimpleXamarinGraphQL", "1.0.0")));
            });
            return serviceCollection.BuildServiceProvider().GetRequiredService<IGitHubClient>();
        }
    }
}
