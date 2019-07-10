using Xamarin.Forms;

namespace SimpleXamarinGraphQL
{
    class GraphQLPage : BaseContentPage<GraphQLViewModel>
    {
        public GraphQLPage()
        {
            var loginEntry = new Entry
            {
                Placeholder = "GitHub Username",
                HorizontalTextAlignment = TextAlignment.Center,
                ReturnType = ReturnType.Go
            };
            loginEntry.SetBinding(Entry.TextProperty, nameof(ViewModel.LoginEntryText));
            loginEntry.SetBinding(Entry.ReturnCommandProperty, nameof(ViewModel.DownloadButtonCommand));

            var downloadButton = new Button
            {
                Text = "Get User Info",
            };
            downloadButton.SetBinding(Button.CommandProperty, nameof(ViewModel.DownloadButtonCommand));

            var resultsLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            resultsLabel.SetBinding(Label.TextProperty, nameof(ViewModel.ResultsLabelText));

            var activityIndicator = new ActivityIndicator();
            activityIndicator.SetBinding(IsVisibleProperty, nameof(ViewModel.IsExecuting));
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, nameof(ViewModel.IsExecuting));


            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,

                Children =
                {
                    resultsLabel,
                    loginEntry,
                    downloadButton,
                    activityIndicator
                }
            };

            Content = stackLayout;
        }
    }
}
