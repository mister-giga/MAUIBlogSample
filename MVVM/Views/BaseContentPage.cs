using Blogs.Services;

namespace Blogs.MVVM.Views;

public abstract class BaseContentPage : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is IAppearable appearable)
        {
            await appearable.OnAppearAsync();
        }
    }
}
