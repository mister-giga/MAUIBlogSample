using Blogs.MVVM.Views;

namespace Blogs;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("blog", typeof(BlogPage));
    }
}
