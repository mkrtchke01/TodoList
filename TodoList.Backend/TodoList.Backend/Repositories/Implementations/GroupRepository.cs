using Microsoft.EntityFrameworkCore;
using TodoList.Backend.Data;
using TodoList.Backend.Models;

namespace TodoList.Backend.Repositories.Implementations;

public class GroupRepository : IGroupRepository
{
    private readonly TodoListContext _context;

    public GroupRepository(TodoListContext context)
    {
        _context = context;
    }

    public async Task<Group> GetAsync(int groupId)
    {
        var group = await _context.Groups.FirstOrDefaultAsync(group => group.GroupId == groupId);
        if (group == null) throw new Exception("Group is not found.");
        return group;
    }

    public async Task<List<Group>> GetAllAsync()
    {
        var groups = await _context.Groups.ToListAsync();
        return groups;
    }

    public async Task CreateAsync(Group group)
    {
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int groupId)
    {
        var group = await _context.Groups.FirstOrDefaultAsync(group => group.GroupId == groupId);
        if (group == null) throw new Exception("Group is not found.");
        _context.Remove(group);
        await _context.SaveChangesAsync();
    }
}