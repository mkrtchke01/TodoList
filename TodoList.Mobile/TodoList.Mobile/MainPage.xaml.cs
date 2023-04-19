using TodoList.Mobile.DataServices;
using TodoList.Mobile.Models;
using TodoList.Mobile.Pages;

namespace TodoList.Mobile;

public partial class MainPage : ContentPage
{
    private readonly IRestDataService _restDataService;

    public MainPage(IRestDataService restDataService)
    {
        InitializeComponent();
        _restDataService = restDataService;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await _restDataService.GetAllGroupsAsync();
    }

    private async void OnAddGroupClicked(object sender, EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            {
                nameof(Group), new Group()
            }
        };
        await Shell.Current.GoToAsync(nameof(CreateGroupPage), navigationParameter);
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(Group), e.CurrentSelection.FirstOrDefault() as Group }
        };
        await Shell.Current.GoToAsync(nameof(GetTodosPage), navigationParameter);
    }
}