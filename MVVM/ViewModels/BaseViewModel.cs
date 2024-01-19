using Blogs.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Blogs.MVVM.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged, IAppearable
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(field, value))
        {
            field = value;
            RaisePropertyChanged(propertyName);
        }
    }

    protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() => PropertyChanged?.Invoke(this, args));
        
    }

    protected virtual Task OnAppearingAsync() => Task.CompletedTask;

    Task IAppearable.OnAppearAsync() => OnAppearingAsync();
}
