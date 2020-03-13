using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SimpleXamarinGraphQL
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            Xamarin.Forms.Device.SetFlags(new[] { "Markup_Experimental" });

            var navigationPage = new Xamarin.Forms.NavigationPage(new GraphQLPage())
            {
                BarBackgroundColor = Xamarin.Forms.Color.FromHex("#3498db"),
                BarTextColor = Xamarin.Forms.Color.White
            };
            navigationPage.On<iOS>().SetPrefersLargeTitles(true);

            MainPage = navigationPage;
        }
    }
}
