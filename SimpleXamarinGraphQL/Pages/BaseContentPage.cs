using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SimpleXamarinGraphQL
{
    abstract class BaseContentPage<T> : ContentPage where T : BaseViewModel, new()
    {
        protected BaseContentPage(string title)
        {
            BindingContext = ViewModel;
            BackgroundColor = Color.FromHex("#2980b9");
            Title = title;

            On<iOS>().SetUseSafeArea(true);
        }

        protected T ViewModel { get; } = new T();
    }
}
