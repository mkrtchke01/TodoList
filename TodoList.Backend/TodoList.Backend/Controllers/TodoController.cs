using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using TodoList.Backend.Models;
using TodoList.Backend.Services;

namespace TodoList.Backend.Controllers;

public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [EnableQuery]
    [HttpGet("{key}")]
    public async Task<IActionResult> Get([FromODataUri] int key)
    {
        var result = await _todoService.GetAllFromGroupAsync(key);
        return Ok(result);
    }

    public async Task<IActionResult> Post([FromBody] Todo todo)
    {
        await _todoService.CreateAsync(todo);
        return Ok();
    }

    public async Task<IActionResult> Put([FromRoute] int key, [FromBody] Todo todo)
    {
        await _todoService.UpdateStatusAsync(key, todo);
        return Ok();
    }

    public async Task<IActionResult> Delete([FromRoute] int key)
    {
        await _todoService.DeleteAsync(key);
        return Ok();
    }
}