using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Models.UserDB;
using Models.UserDB.User_Models;
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
            MessageBox.Show("You are done with database");
        }
        else
        {
            MessageBox.Show("Something wrong");
        }
    }

    public User CreateUser()
    {
        return new User
        {
            FirstName = InputFirstName.InputMy.Text,
            LastName = InputLastName.InputMy.Text,
            Email = InputEmail.InputMy.Text,
            Phone_number = InputPhoneNumber.InputMy.Text,
            Password = InputPasswordBox.Password
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