using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Models.UserDB;
using Models.UserDB.User_Models;
using ReceptWpf.App.Configs;
using ReceptWpf.App.Windows.HomeWindows;
using LoginUser = ReceptWpf.App.Windows.Authorization.LoginWindow.LoginUser;

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
    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        Clear();
    }
    private void ButtonRegister_OnClick(object sender, RoutedEventArgs e)
    {
        UserDatabase userDatabase = new UserDatabase();
        var user = CreateUser();
        int result = userDatabase.InsertUser(user);
        if (result == 1)
        {
            UserConfig.SaveToJsonFile(user:user);
            new HomeWindow().Show();
            this.Close();
        }
        else MessageBox.Show("Something wrong");
    }
    public User CreateUser()
    {
        return new User
        {
            FirstName = InputFirstName.InputMy.Text.Trim(),
            LastName = InputLastName.InputMy.Text.Trim(),
            Email = InputEmail.InputMy.Text.Trim(),
            Phone_number = InputPhoneNumber.InputMy.Text.Trim(),
            Password = InputPasswordBox.Password.Trim()
        };
    }
    private void Clear()
    {
        InputFirstName.InputMy.Clear();
        InputLastName.InputMy.Clear();
        InputEmail.InputMy.Clear(); 
        InputPhoneNumber.InputMy.Clear();
        InputPasswordBox.Clear();
    }
}