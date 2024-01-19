using Blogs.MVVM.Models;

namespace Blogs.Services;

public class BlogsRepository : IBlogsRepository
{
    private ICollection<Blog>? _blogs;
    private readonly SemaphoreSlim semaphore;
    private readonly IBlogsService _blogsService;


    public BlogsRepository(IBlogsService blogsService)
    {
        semaphore = new SemaphoreSlim(1, 1);
        _blogsService = blogsService;
    }

    private async Task<ICollection<Blog>> GetCachedBlogsAsync()
    {
        if (_blogs == null)
        {
            await semaphore.WaitAsync();

            try
            {
                _blogs = await _blogsService.GetBlogsAsync();
            }
            finally
            {
                _ = semaphore.Release();
            }
        }

        return _blogs;
    }

    public async Task<Blog> GetBlogAsync(string id)
    {
        ICollection<Blog> blogs = await GetCachedBlogsAsync();
        return blogs.Single(x => x.Id == id);
    }

    public Task<ICollection<Blog>> GetBlogsAsync()
    {
        return GetCachedBlogsAsync();
    }
}
