using TodoList.Mobile.DataServices;
using TodoList.Mobile.DataServices.Implementations;
using TodoList.Mobile.Pages;

namespace TodoList.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IRestDataService, RestDataService>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<CreateGroupPage>();
        builder.Services.AddTransient<GetTodosPage>();
        builder.Services.AddTransient<CreateTodoPage>();
        builder.Services.AddTransient<UpdateTodoPage>();

        return builder.Build();
    }
}