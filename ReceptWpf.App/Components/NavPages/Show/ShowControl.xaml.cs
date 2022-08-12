using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Models.FoodDB.FoodModels;

namespace ReceptWpf.App.Components.NavPages.Show;

public partial class ShowControl : UserControl
{
    public Food Foood { get; set; }
    public bool IsVisible { get; set; } = false;
    public ShowControl(Food food)
    {
        Foood = food;
        InitializeComponent();
        ImageStack.Source = new BitmapImage(new Uri(Foood.FoodPhoto));
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
       //MainStack.Visibility = Visibility.Collapsed;
        IsVisible = true;
    }
}