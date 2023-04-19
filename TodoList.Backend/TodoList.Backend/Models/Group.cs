namespace TodoList.Backend.Models;

public class Group
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public ICollection<Todo> Todos { get; set; }
}