using TodoList.Backend.Models;

namespace TodoList.Backend.Repositories;

public interface ITodoRepository
{
    Task<List<Todo>> GetAllFromGroupAsync(int groupId);
    Task<Todo> GetAsync(int todoId);
    Task CreateAsync(Todo todo);
    Task UpdateAsync(Todo todo);
    Task DeleteAsync(int todoId);
}