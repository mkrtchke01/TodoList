using TodoList.Backend.Models;
using TodoList.Backend.Repositories;

namespace TodoList.Backend.Services.Implementations;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<List<Group>> GetAllAsync()
    {
        var groups = await _groupRepository.GetAllAsync();
        return groups;
    }

    public async Task CreateAsync(Group group)
    {
        await _groupRepository.CreateAsync(group);
    }

    public async Task DeleteAsync(int groupId)
    {
        await _groupRepository.DeleteAsync(groupId);
    }
}