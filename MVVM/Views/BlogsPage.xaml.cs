using Blogs.MVVM.ViewModels;

namespace Blogs.MVVM.Views;

public partial class BlogsPage : BaseContentPage
{
    public BlogsPage(BlogsPageViewModel blogsPageViewModel)
    {
        BindingContext = blogsPageViewModel;
        InitializeComponent();
    }
}