using TodoList.Mobile.Models;

namespace TodoList.Mobile.DataServices;

public interface IRestDataService
{
    Task<List<Group>> GetAllGroupsAsync();
    Task CreateGroupAsync(Group group);
    Task DeleteGroupAsync(int groupId);
    Task<List<Todo>> GetAllTodosAsync(int groupId);
    Task CreateTodoAsync(Todo todo);
    Task UpdateTodoAsync(int todoId, Todo todo);
    Task DeleteTodoAsync(int todoId);
}