using System.Windows;
using ReceptWpf.App.Windows.Authorization.LoginWindow;

namespace ReceptWpf.App.Windows.Authorization.RegisterWindow;

public partial class RegisterUser : Window
{
    public RegisterUser()
    {
        InitializeComponent();
    }

    private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
    {
        new LoginUser().Show();
        this.Close();
    }
}