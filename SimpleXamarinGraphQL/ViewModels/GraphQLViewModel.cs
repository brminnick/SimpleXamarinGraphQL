using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using SimpleXamarinGraphQL.Services;
using Xamarin.Forms;

namespace SimpleXamarinGraphQL
{
    class GraphQLViewModel : BaseViewModel
    {
        bool _isExecuting;
        string _resultsLabelText, _loginEntryText = "brminnick";
        IGitHubClient _gitHubClient;

        public GraphQLViewModel()
        {
            _gitHubClient = GitHubClientFactory.Create();
            DownloadButtonCommand = new AsyncCommand(() => ExecuteDownloadButtonTapped(LoginEntryText), _ => !IsExecuting);
        }

        public AsyncCommand DownloadButtonCommand { get; }

        public bool IsExecuting
        {
            get => _isExecuting;
            set => SetProperty(ref _isExecuting, value, () => Device.BeginInvokeOnMainThread(DownloadButtonCommand.RaiseCanExecuteChanged));
        }

        public string LoginEntryText
        {
            get => _loginEntryText;
            set => SetProperty(ref _loginEntryText, value);
        }

        public string ResultsLabelText
        {
            get => _resultsLabelText;
            set => SetProperty(ref _resultsLabelText, value);
        }

        async Task ExecuteDownloadButtonTapped(string login)
        {
            IsExecuting = true;

            ResultsLabelText = "Getting GitHub User Data...";

            try
            {
                var response = await _gitHubClient.GetUserAsync(login).ConfigureAwait(false);
                response.EnsureNoErrors();

                var gitHubUser = response.Data.User;

                ResultsLabelText = gitHubUser.Name.ToString();
            }
            catch (System.Exception e)
            {
                ResultsLabelText = e.Message;
            }
            finally
            {
                IsExecuting = false;
            }
        }
    }
}
