using TodoList.Backend.Models;

namespace TodoList.Backend.Repositories;

public interface IGroupRepository
{
    Task<Group> GetAsync(int groupId);
    Task<List<Group>> GetAllAsync();
    Task CreateAsync(Group group);
    Task DeleteAsync(int groupId);
}