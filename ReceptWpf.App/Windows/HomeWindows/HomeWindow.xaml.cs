using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Models.UserDB.User_Models;
using ReceptWpf.App.Configs;

namespace ReceptWpf.App.Windows.HomeWindows;

public partial class HomeWindow : Window
{
    public User? user { get; set; }
    public HomeWindow()
    {
        user = UserConfig.GetUserFromJsonFile();
        InitializeComponent();
        this.DataContext = new NavigationViewModel();
    }
}