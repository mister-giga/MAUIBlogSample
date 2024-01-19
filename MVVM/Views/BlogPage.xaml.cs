using Blogs.MVVM.ViewModels;

namespace Blogs.MVVM.Views;

public partial class BlogPage : BaseContentPage
{
    public BlogPage(BlogPageViewModel blogPageViewModel)
    {
        BindingContext = blogPageViewModel;
        InitializeComponent();
    }
}