using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoList.Mobile.Models;

public class Group : INotifyPropertyChanged
{
    private int _groupId;

    private string _groupName;

    public int GroupId
    {
        get => _groupId;
        set
        {
            _groupId = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GroupId)));
        }
    }

    public string GroupName
    {
        get => _groupName;
        set
        {
            _groupName = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GroupId)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}