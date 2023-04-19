using TodoList.Mobile.DataServices;
using TodoList.Mobile.Models;

namespace TodoList.Mobile.Pages;

[QueryProperty(nameof(Todo), "Todo")]
[QueryProperty(nameof(GroupId), "GroupId")]
public partial class CreateTodoPage : ContentPage
{
    private readonly IRestDataService _restDataService;
    private int _groupId;
    private Todo _todo;

    public CreateTodoPage(IRestDataService restDataService)
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

    public int GroupId
    {
        get => _groupId;
        set
        {
            _groupId = value;
            OnPropertyChanged();
        }
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        Todo.GroupId = GroupId;
        await _restDataService.CreateTodoAsync(Todo);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _restDataService.DeleteTodoAsync(Todo.TodoId);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}