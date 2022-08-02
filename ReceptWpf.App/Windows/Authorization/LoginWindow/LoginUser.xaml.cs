using System.Windows;
using System.Xml;
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

    private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
    {
        var userDatabase = new Models.UserDB.UserDatabase();
        var logindUser = GetLoginUser();
        var user = userDatabase.GetUser(logindUser);
        if (user is not null) MessageBox.Show("You are our guy");
        else MessageBox.Show("Fuck you you are not our guy");
    }
    private void ButtonClear_Onlick(object sender, RoutedEventArgs e)
    {
        InputEmail.InputMy.Clear(); 
        InputPasswordBox.Clear();
    }

    private Models.UserDB.User_Models.LoginUser GetLoginUser()
    {
        return new Models.UserDB.User_Models.LoginUser()
        {
            Email = InputEmail.InputMy.Text,
            Password = InputPasswordBox.Password
        };
    }

}