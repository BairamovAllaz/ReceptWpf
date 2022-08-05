using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReceptWpf.App.Components.Navbar;

public partial class NavbarComponent : UserControl,INotifyPropertyChanged
{
    private ICommand _aboutCommand;
    private ICommand _homeCommand;
    private ICommand _userCommand;

    public ICommand AboutCommand
    {
        get => _aboutCommand;
        set
        {
            if (_aboutCommand == value) return;
            _aboutCommand = value;
            OnPropertyChanged(nameof(AboutCommand));
        }
    }
    public ICommand HomeCommand {  
        get => _homeCommand;
        set
        {
            if (_homeCommand == value) return;
            _homeCommand = value;
            OnPropertyChanged(nameof(HomeCommand));
        } 
    }
    public ICommand UserCommand {    
        get => _userCommand;
        set
        {
            if (_userCommand == value) return;
            _userCommand = value;
            OnPropertyChanged(nameof(UserCommand));
        }
    }
    public NavbarComponent()
    {
        InitializeComponent();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}