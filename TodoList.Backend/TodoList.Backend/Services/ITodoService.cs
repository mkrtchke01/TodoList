using TodoList.Backend.Models;

namespace TodoList.Backend.Services;

public interface ITodoService
{
    Task<List<Todo>> GetAllFromGroupAsync(int groupId);
    Task CreateAsync(Todo todo);
    Task UpdateStatusAsync(int todoId, Todo todoModel);
    Task DeleteAsync(int todoId);
}