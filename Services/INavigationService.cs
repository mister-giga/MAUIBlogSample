namespace Blogs.Services;

public interface INavigationService
{
    Task GoToAsync(string path);
}
