using Blogs.MVVM.Models;
using System.Net.Http.Json;

namespace Blogs.Services;

public class BlogsService : IBlogsService
{
    private readonly HttpClient _httpClinet;
    public BlogsService()
    {
        _httpClinet = new();
    }

    public async Task<ICollection<Blog>> GetBlogsAsync()
    {
        BlogsResponse? blogsRepsonse = await _httpClinet.GetFromJsonAsync<BlogsResponse>("https://api.slingacademy.com/v1/sample-data/blog-posts");
        return blogsRepsonse!.Blogs.Select(x => new Blog
        {
            Id = x.Id.ToString(),
            Title = x.Title,
            Content = x.Content_text,
            Date = x.Created_at,
            ImageUrl = x.Photo_url
        }).ToList();
    }

    private class BlogsResponse
    {
        public required List<BlogDto> Blogs { get; init; }
    }

    private class BlogDto
    {
        public required string Title { get; init; }
        public required string Content_text { get; init; }
        public required string Photo_url { get; init; }
        public required DateTime Created_at { get; init; }
        public required int Id { get; init; }
    }
}
