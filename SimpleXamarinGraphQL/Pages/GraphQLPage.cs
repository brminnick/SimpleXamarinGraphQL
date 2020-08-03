using Xamarin.Forms;
using Xamarin.Forms.Markup;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace SimpleXamarinGraphQL
{
    class GraphQLPage : BaseContentPage<GraphQLViewModel>
    {
        public GraphQLPage() : base("GitHub User")
        {
            Content = new Grid
            {
                Margin = new Thickness(20, 20, 20, 40),

                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,

                RowSpacing = 20,

                RowDefinitions = Rows.Define(
                    (Row.LoginEntry, new GridLength(50, GridUnitType.Absolute)),
                    (Row.DownloadButton, new GridLength(50, GridUnitType.Absolute)),
                    (Row.ActivityIndicator, new GridLength(15, GridUnitType.Absolute)),
                    (Row.ResultsLabel, new GridLength(1, GridUnitType.Star))),

                Children =
                {
                    new LoginEntry().Row(Row.LoginEntry)
                        .Bind(Entry.TextProperty, nameof(GraphQLViewModel.LoginEntryText))
                        .Bind(Entry.ReturnCommandProperty, nameof(GraphQLViewModel.DownloadButtonCommand)),

                    new DownloadButton().Row(Row.DownloadButton)
                        .Bind(Button.CommandProperty, nameof(GraphQLViewModel.DownloadButtonCommand)),

                    new ActivityIndicator { Color = Color.White }.Row(Row.ActivityIndicator)
                        .Bind(IsVisibleProperty, nameof(GraphQLViewModel.IsExecuting))
                        .Bind(ActivityIndicator.IsRunningProperty, nameof(GraphQLViewModel.IsExecuting)),

                    new ResultsLabel().Row(Row.ResultsLabel)
                        .Bind(Label.TextProperty, nameof(GraphQLViewModel.ResultsLabelText))
                }
            };
        }

        enum Row { LoginEntry, DownloadButton, ActivityIndicator, ResultsLabel }

        class LoginEntry : Entry
        {
            public LoginEntry()
            {
                Placeholder = "GitHub Username";
                BackgroundColor = Device.RuntimePlatform is Device.iOS ? Color.White : default;
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing;
                HorizontalOptions = LayoutOptions.FillAndExpand;
                HorizontalTextAlignment = TextAlignment.Start;
                ReturnType = ReturnType.Go;
                PlaceholderColor = Color.LightGray;
                TextColor = Device.RuntimePlatform is Device.Android ? Color.White : Color.Black;
            }
        }

        class DownloadButton : Button
        {
            public DownloadButton()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand;
                BackgroundColor = Color.Transparent;
                TextColor = Color.White;
                BorderColor = Color.White;
                FontSize = 18;
                CornerRadius = 3;
                BorderWidth = 1;
                Text = "Get User Info";
            }
        }

        class ResultsLabel : Label
        {
            public ResultsLabel()
            {
                FontSize = 20;
                VerticalOptions = LayoutOptions.CenterAndExpand;
                HorizontalOptions = LayoutOptions.FillAndExpand;
                HorizontalTextAlignment = TextAlignment.Start;
                VerticalTextAlignment = TextAlignment.Start;
                TextColor = Color.White;
            }
        }
    }
}