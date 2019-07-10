using Xamarin.Forms;

namespace SimpleXamarinGraphQL
{
    public abstract class BaseContentPage<T> : ContentPage where T : BaseViewModel, new()
    {
        protected BaseContentPage() => BindingContext = ViewModel;

        protected T ViewModel { get; } = new T();
    }
}
