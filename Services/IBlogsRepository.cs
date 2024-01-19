using Blogs.MVVM.Models;

namespace Blogs.Services;

public interface IBlogsRepository
{
    Task<Blog> GetBlogAsync(string id);
    Task<ICollection<Blog>> GetBlogsAsync();
}
