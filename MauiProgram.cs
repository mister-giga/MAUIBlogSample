global using Blogs.Utils;
using Blogs.MVVM.ViewModels;
using Blogs.MVVM.Views;
using Blogs.Services;
using Microsoft.Extensions.Logging;

namespace Blogs;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder
            .Services
            .AddSingleton<IBlogsService, BlogsService>()
            .AddSingleton<IBlogsRepository, BlogsRepository>()
            .AddTransient<INavigationService, NavigationService>()
            .AddScoped<BlogsPageViewModel>()
            .AddScoped<BlogPageViewModel>()
            .AddScoped<BlogsPage>()
            .AddScoped<BlogPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
