namespace TodoList.Backend.Models;

public class Todo
{
    public int TodoId { get; set; }
    public string TodoName { get; set; }
    public bool IsCompleted { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}