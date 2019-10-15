using Xamarin.Forms;

namespace SimpleXamarinGraphQL
{
    class GraphQLPage : BaseContentPage<GraphQLViewModel>
    {
        public GraphQLPage() : base("GitHub User")
        {
            var loginEntry = new Entry
            {
                BackgroundColor = Device.RuntimePlatform is Device.iOS ? Color.White : default,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Placeholder = "GitHub Username",
                HorizontalTextAlignment = TextAlignment.Start,
                ReturnType = ReturnType.Go,
                PlaceholderColor = Color.LightGray,
                TextColor = Device.RuntimePlatform is Device.Android ? Color.White : Color.Black
            };
            loginEntry.SetBinding(Entry.TextProperty, nameof(GraphQLViewModel.LoginEntryText));
            loginEntry.SetBinding(Entry.ReturnCommandProperty, nameof(GraphQLViewModel.DownloadButtonCommand));

            var downloadButton = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                BorderColor = Color.White,
                FontSize = 18,
                CornerRadius = 3,
                BorderWidth = 1,
                Text = "Get User Info"
            };
            downloadButton.SetBinding(Button.CommandProperty, nameof(GraphQLViewModel.DownloadButtonCommand));

            var activityIndicator = new ActivityIndicator { Color = Color.White };
            activityIndicator.SetBinding(IsVisibleProperty, nameof(GraphQLViewModel.IsExecuting));
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, nameof(GraphQLViewModel.IsExecuting));

            var resultsLabel = new Label
            {
                FontSize = 20,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start,
                TextColor = Color.White
            };
            resultsLabel.SetBinding(Label.TextProperty, nameof(GraphQLViewModel.ResultsLabelText));

            var grid = new Grid
            {
                Margin = new Thickness(20, 20, 20, 40),

                RowSpacing = 20,

                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,

                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(15, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            grid.Children.Add(loginEntry, 0, 0);
            grid.Children.Add(downloadButton, 0, 1);
            grid.Children.Add(activityIndicator, 0, 2);
            grid.Children.Add(resultsLabel, 0, 3);

            Content = new ScrollView { Content = grid };
        }
    }
}
