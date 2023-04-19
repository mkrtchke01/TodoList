using TodoList.Backend.Models;

namespace TodoList.Backend.Services;

public interface IGroupService
{
    Task<List<Group>> GetAllAsync();
    Task CreateAsync(Group group);
    Task DeleteAsync(int groupId);
}