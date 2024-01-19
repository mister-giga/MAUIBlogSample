namespace Blogs.MVVM.Models;

public class Blog
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Content { get; init; }
    public required string ImageUrl { get; init; }
    public required DateTime Date { get; init; }
}
