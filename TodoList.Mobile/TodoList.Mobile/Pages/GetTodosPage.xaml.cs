using TodoList.Mobile.DataServices;
using TodoList.Mobile.Models;

namespace TodoList.Mobile.Pages;

[QueryProperty(nameof(Group), "Group")]
public partial class GetTodosPage : ContentPage
{
    private readonly IRestDataService _restDataService;

    private Group _group;

    public GetTodosPage(IRestDataService restDataService)
    {
        InitializeComponent();
        _restDataService = restDataService;
        BindingContext = this;
    }

    public Group Group
    {
        get => _group;
        set
        {
            _group = value;
            OnPropertyChanged();
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await _restDataService.GetAllTodosAsync(Group.GroupId);
    }

    private async void OnAddTodoClicked(object sender, EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            {
                nameof(Todo), new Todo()
            },
            {
                "GroupId", Group.GroupId
            }
        };
        await Shell.Current.GoToAsync(nameof(CreateTodoPage), navigationParameter);
    }

    private async void OnDeleteGroupClicked(object sender, EventArgs e)
    {
        await _restDataService.DeleteGroupAsync(Group.GroupId);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(Todo), e.CurrentSelection.FirstOrDefault() as Todo }
        };
        await Shell.Current.GoToAsync(nameof(UpdateTodoPage), navigationParameter);
    }
}