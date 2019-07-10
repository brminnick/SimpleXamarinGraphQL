using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;

namespace SimpleXamarinGraphQL
{
    public class GraphQLViewModel : BaseViewModel
    {
        #region Fields
        string _resultsLabelText;
        #endregion

        public GraphQLViewModel()
        {
            DownloadButtonCommand = new AsyncCommand(ExecuteDownloadButtonTapped);
        }

        public ICommand DownloadButtonCommand { get; }

        public string ResultsLabelText
        {
            get => _resultsLabelText;
            set => SetProperty(ref _resultsLabelText, value);
        }

        Task ExecuteDownloadButtonTapped()
        {
            ResultsLabelText = "Getting GitHub User Data...";

            var gitHubUserResponse = await client.SendQueryAsync(graphQLRequest);

            User gitHubUser = gitHubUserResponse.GetDataFieldAs<User>("user");

            ResultLabel.Text = gitHubUser.Name;
        }
    }
}
