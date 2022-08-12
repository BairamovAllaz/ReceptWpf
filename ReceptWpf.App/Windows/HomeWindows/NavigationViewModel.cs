using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using System.Windows.Input;
using ReceptWpf.App.Components.NavPages;
using ReceptWpf.App.Components.NavPages.ActuallComponentShow;
using ReceptWpf.App.Components.NavPages.CreatePage;
using ReceptWpf.App.Components.NavPages.Home;

namespace ReceptWpf.App.Windows.HomeWindows;
public class NavigationViewModel : INotifyPropertyChanged
{
    public ICommand AboutCommand { get; set; }
    public ICommand HomeCommand { get; set; }
    public ICommand UserCommand { get; set; }
    public ICommand CreateCommand { get; set; }
    public ICommand AcctualShow { get; set; }
    private object? _selectedViewModel;

    public NavigationViewModel()
    {
        AboutCommand = new BaseCommand(OpenAbout);
        HomeCommand = new BaseCommand(OpenHome);
        UserCommand = new BaseCommand(OpenUser);
        CreateCommand = new BaseCommand(OpenCreate);
        AcctualShow = new BaseCommand(OpenActuall);
        SelectedViewModel = new Home(); //navigate to start page 
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

    private void OpenActuall(object obj)
    {
        SelectedViewModel = new ActuallComponentShow();
    } 

    private void OpenAbout(object obj)
    {
        SelectedViewModel = new About();
    }
    private void OpenHome(object obj)
    {
        SelectedViewModel = new Home();
    }
    private void OpenUser(object obj)
    {
        SelectedViewModel = new User();
    }
    private void OpenCreate(object opj)
    {
        SelectedViewModel = new CreatePage();
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}