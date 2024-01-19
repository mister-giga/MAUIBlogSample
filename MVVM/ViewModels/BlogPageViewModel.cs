using Blogs.MVVM.Models;
using Blogs.Services;

namespace Blogs.MVVM.ViewModels;

public class BlogPageViewModel(IBlogsRepository blogsRepository) : BaseViewModel, IQueryAttributable
{
    private readonly IBlogsRepository _blogsRepository = blogsRepository;

    private Blog? _blog;
    public Blog? Blog
    {
        get => _blog;
        set => SetProperty(ref _blog, value);
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out string? id))
        {
            Blog = await _blogsRepository.GetBlogAsync(id!);
        }
    }
}
