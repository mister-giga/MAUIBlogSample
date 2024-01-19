namespace Blogs.Services;

public class NavigationService : INavigationService
{
    public Task GoToAsync(string path)
    {
        return Shell.Current.GoToAsync(path);
    }
}
