using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Show;

namespace ReceptWpf.App.Components.NavPages.ActuallComponentShow;

public partial class ActuallComponentShow : UserControl
{
    public Food food { get; set; }
    public ActuallComponentShow()
    {
        food = Home.Home.Foood;
        InitializeComponent();
        ImageStack.Source = new BitmapImage(new Uri(food.FoodPhoto));
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(food.ToString());
    }
}