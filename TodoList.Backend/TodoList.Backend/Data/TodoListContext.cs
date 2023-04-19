using Microsoft.EntityFrameworkCore;
using TodoList.Backend.Models;

namespace TodoList.Backend.Data;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Group> Groups { get; set; }
}