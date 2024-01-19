using Blogs.MVVM.Models;
using Blogs.Services;
using System.Windows.Input;

namespace Blogs.MVVM.ViewModels;

public class BlogsPageViewModel(IBlogsRepository blogsRepository, INavigationService navigationService) : BaseViewModel
{
    private readonly IBlogsRepository _blogsRepository = blogsRepository;

    private ICollection<Blog>? _blogs;
    public ICollection<Blog>? Blogs
    {
        get => _blogs;
        set => SetProperty(ref _blogs, value);
    }

    private ICommand? _selectBlogCommand;
    public ICommand SelectBlogCommand => _selectBlogCommand ??= new Command<Blog>(async (blog) => await SelectBlogAsync(blog));

    private async Task SelectBlogAsync(Blog blog)
    {
        try
        {
            await navigationService.GoToAsync($"blog?id={blog.Id}");
        }
        catch(Exception ex)
        {
            Console.WriteLine(  ex);
        }
    }

    protected override async Task OnAppearingAsync()
    {
        if (Blogs?.Any() != true)
        {
            _ = await Task.Run(async () => Blogs = await _blogsRepository.GetBlogsAsync());
        }
    }
}
