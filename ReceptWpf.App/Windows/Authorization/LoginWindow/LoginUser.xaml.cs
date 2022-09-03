using System.Windows;
using System.Windows.Media;
using System.Xml;
using Models.UserDB;
using ReceptWpf.App.Configs;
using ReceptWpf.App.Windows.Authorization.RegisterWindow;
using ReceptWpf.App.Windows.HomeWindows;

namespace ReceptWpf.App.Windows.Authorization.LoginWindow;

public partial class LoginUser : Window
{
    private IUserDatabase _userDatabase;
    public LoginUser()
    {
        _userDatabase = new UserDatabase();
        InitializeComponent();
    }
    
    public void SetUserDatabaseWithFake(IUserDatabase userDatabase)
    {
        _userDatabase = userDatabase;
    }
    
    private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
    {
        new RegisterUser().Show();
        this.Close();
    }

    private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
    {
        var logindUser = GetLoginUser();
        var user = _userDatabase.GetUser(logindUser);
        if (user is not null)
        {
            UserConfig.SaveToJsonFile(user:user);
            new HomeWindow().Show();
            this.Close();
        }
        else InitErrorInput();
    }
    
    public void InitErrorInput()
    {
        MessageBox.Show("User has not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        InputEmail.InputMy.BorderBrush = new SolidColorBrush(Colors.Red);
        InputPasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
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
            Email = InputEmail.InputMy.Text.Trim(),
            Password = InputPasswordBox.Password.Trim()
        };
    }
}