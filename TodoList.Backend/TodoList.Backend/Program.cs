using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using TodoList.Backend.Data;
using TodoList.Backend.Models;
using TodoList.Backend.Repositories;
using TodoList.Backend.Repositories.Implementations;
using TodoList.Backend.Services;
using TodoList.Backend.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(20)
        .Count()
        .Expand()
    );

builder.Services.AddDbContext<TodoListContext>(option =>
    option.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 11))));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupService, GroupService>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());


app.MapControllers();

app.Run();

IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Todo>("Todo");
    odataBuilder.EntitySet<Group>("Group");

    return odataBuilder.GetEdmModel();
}