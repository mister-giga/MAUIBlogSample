using Blogs.MVVM.Models;

namespace Blogs.Services;

public interface IBlogsService
{
    Task<ICollection<Blog>> GetBlogsAsync();
}
