using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using TodoList.Backend.Models;
using TodoList.Backend.Services;

namespace TodoList.Backend.Controllers;

public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [EnableQuery]
    public async Task<IActionResult> Get()
    {
        var result = await _groupService.GetAllAsync();
        return Ok(result);
    }

    public async Task<IActionResult> Post([FromBody] Group group)
    {
        await _groupService.CreateAsync(group);
        return Ok();
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete([FromODataUri] int key)
    {
        await _groupService.DeleteAsync(key);
        return Ok();
    }
}