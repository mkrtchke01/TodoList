using TodoList.Mobile.Pages;

namespace TodoList.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CreateGroupPage), typeof(CreateGroupPage));
        Routing.RegisterRoute(nameof(GetTodosPage), typeof(GetTodosPage));
        Routing.RegisterRoute(nameof(CreateTodoPage), typeof(CreateTodoPage));
        Routing.RegisterRoute(nameof(UpdateTodoPage), typeof(UpdateTodoPage));
    }
}