using TodoList.Mobile.DataServices;
using TodoList.Mobile.Models;

namespace TodoList.Mobile.Pages;

[QueryProperty(nameof(Group), "Group")]
public partial class CreateGroupPage : ContentPage
{
    private readonly IRestDataService _restDataService;
    private Group _group;

    public CreateGroupPage(IRestDataService restDataService)
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

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        await _restDataService.CreateGroupAsync(Group);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _restDataService.DeleteGroupAsync(Group.GroupId);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}