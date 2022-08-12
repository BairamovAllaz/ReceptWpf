using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ReceptWpf.App.Components.NavPages.Home.NavigateConfigs;
public class NavigationViewModel : INotifyPropertyChanged
{
    public ICommand ShowActuall { get; set; }
    public ICommand ShowHomeShow { get; set; }
    private object? _selectedViewModel;

    public NavigationViewModel()
    {
        ShowActuall = new BaseCommand(ShowActuallMethod);
        ShowHomeShow = new BaseCommand(ShowSomeShowMethod);
        SelectedViewModel = new HomeShowComponent.HomeShowComponent();
    }
    public object SelectedViewModel
    {
        get => _selectedViewModel;
        set
        {
            if(_selectedViewModel == value) return;
            _selectedViewModel = value; 
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }

    private void ShowActuallMethod(object obj)
    {
        SelectedViewModel = new ActuallComponentShow.ActuallComponentShow();
    }
    
    private void ShowSomeShowMethod(object obj)
    {
        SelectedViewModel = new HomeShowComponent.HomeShowComponent();
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}