using TodoList.Mobile.DataServices;
using TodoList.Mobile.Models;

namespace TodoList.Mobile.Pages;

[QueryProperty(nameof(Todo), "Todo")]
public partial class UpdateTodoPage : ContentPage
{
    private readonly IRestDataService _restDataService;
    private Todo _todo;

    public UpdateTodoPage(IRestDataService restDataService)
    {
        InitializeComponent();
        _restDataService = restDataService;
        BindingContext = this;
    }

    public Todo Todo
    {
        get => _todo;
        set
        {
            _todo = value;
            OnPropertyChanged();
        }
    }

    private async void OnDeleteTodoClicked(object sender, EventArgs e)
    {
        await _restDataService.DeleteTodoAsync(Todo.TodoId);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnChangeStatusTodoClicked(object sender, EventArgs e)
    {
        Todo.IsCompleted = !Todo.IsCompleted;
        await _restDataService.UpdateTodoAsync(Todo.TodoId, Todo);
        await Shell.Current.GoToAsync("..");
    }
}