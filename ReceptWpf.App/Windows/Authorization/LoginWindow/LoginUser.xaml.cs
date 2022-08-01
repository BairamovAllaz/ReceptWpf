using System.Windows;
using ReceptWpf.App.Windows.Authorization.RegisterWindow;

namespace ReceptWpf.App.Windows.Authorization.LoginWindow;

public partial class LoginUser : Window
{
    public LoginUser()
    {
        InitializeComponent();
    }

    private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
    {
        new RegisterUser().Show();
        this.Close();
    }
}