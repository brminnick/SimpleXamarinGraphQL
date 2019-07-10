using System.Threading.Tasks;
using AsyncAwaitBestPractices.MVVM;
using Xamarin.Forms;

namespace SimpleXamarinGraphQL
{
    class GraphQLViewModel : BaseViewModel
    {
        #region Fields
        bool _isExecuting;
        string _resultsLabelText, _loginEntryText = "brminnick";
        #endregion

        #region Constructors
        public GraphQLViewModel()
        {
            DownloadButtonCommand = new AsyncCommand(() => ExecuteDownloadButtonTapped(LoginEntryText), _ => !IsExecuting);
        }
        #endregion

        #region Properties
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
        #endregion

        #region Methods
        async Task ExecuteDownloadButtonTapped(string login)
        {
            IsExecuting = true;

            ResultsLabelText = "Getting GitHub User Data...";

            try
            {
                var gitHubUser = await GitHubGraphQLService.GetGitHubUser(login).ConfigureAwait(false);

                ResultsLabelText = gitHubUser.ToString();
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
        #endregion
    }
}
