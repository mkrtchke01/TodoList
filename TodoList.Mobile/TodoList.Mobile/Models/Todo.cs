using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoList.Mobile.Models;

public class Todo : INotifyPropertyChanged
{
    private int _groupId;

    private bool _isCompleted;
    private int _todoId;

    private string _todoName;

    public int TodoId
    {
        get => _todoId;
        set
        {
            _todoId = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TodoId)));
        }
    }

    public string TodoName
    {
        get => _todoName;
        set
        {
            _todoName = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TodoName)));
        }
    }

    public bool IsCompleted
    {
        get => _isCompleted;
        set
        {
            _isCompleted = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
        }
    }

    public int GroupId
    {
        get => _groupId;
        set
        {
            _groupId = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GroupId)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}