using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Models.FoodDB.FoodModels;

namespace ReceptWpf.App.Components.NavPages.Show;

public partial class ShowControl : UserControl
{
    public Food Foood { get; set; }
    public ShowControl(Food food)
    {
        Foood = food;
        InitializeComponent();
        ImageStack.Source = new BitmapImage(new Uri(Foood.FoodPhoto));
    }
}