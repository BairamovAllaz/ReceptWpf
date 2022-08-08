using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Models.UserDB.User_Models;

namespace ReceptWpf.App.Components.NavPages.CreatePage;

public partial class CreatePage : UserControl
{
    private string? _photo;
    public Models.UserDB.User_Models.User User{ get; set; }
    public CreatePage()
    {
        InitializeComponent();
        var url = $@"{Directory.GetCurrentDirectory()}\default2.png";
        PhotoPlace.Source = new BitmapImage(new Uri(url));
    }
    private void ChangePhotoButton_OnClick(object sender, RoutedEventArgs e)
    {
        var file = new OpenFileDialog();
        file.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
        file.ShowDialog();
        _photo = file.FileName;
        if(!(string.IsNullOrEmpty(_photo)))
        {
            PhotoPlace.Source = new BitmapImage(new Uri(_photo));
        }
    }
}