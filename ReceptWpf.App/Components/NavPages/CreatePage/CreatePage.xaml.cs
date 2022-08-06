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
    private string _photo;
    public Models.UserDB.User_Models.User User{ get; set; }
    public CreatePage()
    {
        //TODO FIX IMAGE PROBLEM
        _photo  = @"C:\Users\ellez\OneDrive\Programing\Csharp\ReceptWpf\ReceptWpf.App\Components\NavPages\CreatePage";
        InitializeComponent();
        PhotoPlace.Source = new BitmapImage(new Uri(_photo));
    }
    
    /*
     * Pice of the code for future
     private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
         {
             var ext = _photo.Substring(_photo.LastIndexOf('.'));
             File.Copy(_photo, $@"D:\photos\{_account.Id}_{_user.LastName}_{_user.FirstName}{ext}", true);
         }
     */
    private void ChangePhotoButton_OnClick(object sender, RoutedEventArgs e)
    {
        var file = new OpenFileDialog();
        file.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
        file.ShowDialog();
        _photo = file.FileName;
        PhotoPlace.Source = new BitmapImage(new Uri(_photo));
    }
}