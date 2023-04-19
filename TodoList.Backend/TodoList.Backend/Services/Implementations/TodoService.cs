using TodoList.Backend.Models;
using TodoList.Backend.Repositories;

namespace TodoList.Backend.Services.Implementations;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<List<Todo>> GetAllFromGroupAsync(int groupId)
    {
        var todos = await _todoRepository.GetAllFromGroupAsync(groupId);
        return todos;
    }

    public async Task CreateAsync(Todo todoModel)
    {
        await _todoRepository.CreateAsync(todoModel);
    }

    public async Task UpdateStatusAsync(int todoId, Todo todoModel)
    {
        var entity = await _todoRepository.GetAsync(todoId);
        entity.IsCompleted = todoModel.IsCompleted;
        await _todoRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int todoId)
    {
        await _todoRepository.DeleteAsync(todoId);
    }
}