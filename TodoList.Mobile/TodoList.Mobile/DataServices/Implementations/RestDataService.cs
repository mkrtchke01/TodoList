using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using TodoList.Mobile.Models;

namespace TodoList.Mobile.DataServices.Implementations;

internal class RestDataService : IRestDataService
{
    private readonly string _apiUrl;
    private readonly HttpClient _httpClient;

    public RestDataService()
    {
        _httpClient = new HttpClient();
        _apiUrl = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5124/odata"
            : "http://localhost:5124/odata";
    }

    public async Task<List<Group>> GetAllGroupsAsync()
    {
        var groups = new List<Group>();
        try
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/group");
            var content = await response.Content.ReadAsStringAsync();
            var odataResponse = JsonConvert.DeserializeObject<ODataResponse<Group>>(content);
            if (odataResponse != null) groups = odataResponse.Value;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"------------------>    EXCEPTION: {e.Message}");
        }

        return groups;
    }

    public async Task CreateGroupAsync(Group group)
    {
        try
        {
            var jsonGroup = JsonConvert.SerializeObject(group);
            var content = new StringContent(jsonGroup, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync($"{_apiUrl}/group", content);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"------------------>    EXCEPTION: {e.Message}");
        }
    }

    public async Task DeleteGroupAsync(int groupId)
    {
        try
        {
            await _httpClient.DeleteAsync($"{_apiUrl}/group({groupId})");
        }
        catch (Exception e)
        {
            Debug.WriteLine($"------------------>    EXCEPTION: {e.Message}");
        }
    }

    public async Task<List<Todo>> GetAllTodosAsync(int groupId)
    {
        var todos = new List<Todo>();

        try
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/todo({groupId})");
            var content = await response.Content.ReadAsStringAsync();
            var odataResponse = JsonConvert.DeserializeObject<ODataResponse<Todo>>(content);
            if (odataResponse != null) todos = odataResponse.Value;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"------------------>    EXCEPTION: {e.Message}");
        }

        return todos;
    }

    public async Task CreateTodoAsync(Todo todo)
    {
        try
        {
            var jsonTodo = JsonConvert.SerializeObject(todo);
            var content = new StringContent(jsonTodo, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync($"{_apiUrl}/todo", content);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"------------------>    EXCEPTION: {e.Message}");
        }
    }

    public async Task UpdateTodoAsync(int todoId, Todo todo)
    {
        try
        {
            var jsonTodo = JsonConvert.SerializeObject(todo);
            var content = new StringContent(jsonTodo, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"{_apiUrl}/todo({todoId})", content);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"------------------>    EXCEPTION: {e.Message}");
        }
    }

    public async Task DeleteTodoAsync(int todoId)
    {
        try
        {
            await _httpClient.DeleteAsync($"{_apiUrl}/todo({todoId})");
        }
        catch (Exception e)
        {
            Debug.WriteLine($"------------------>    EXCEPTION: {e.Message}");
        }
    }

    internal class ODataResponse<T>
    {
        public List<T> Value { get; set; }
    }
}