using Microsoft.EntityFrameworkCore;
using TodoList.Backend.Data;
using TodoList.Backend.Models;

namespace TodoList.Backend.Repositories.Implementations;

public class TodoRepository : ITodoRepository
{
    private readonly TodoListContext _context;

    public TodoRepository(TodoListContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Todo todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Todo todo)
    {
        _context.Update(todo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int todoId)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.TodoId == todoId);
        if (todo == null) throw new Exception("Todo is not found.");
        _context.Remove(todo);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Todo>> GetAllFromGroupAsync(int groupId)
    {
        var todos = await _context.Todos.Where(todo => todo.GroupId == groupId).ToListAsync();
        return todos;
    }

    public async Task<Todo> GetAsync(int todoId)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.TodoId == todoId);
        if (todo == null) throw new Exception("Todo is not found");
        return todo;
    }
}