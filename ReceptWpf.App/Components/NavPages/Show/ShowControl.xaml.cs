using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Models.FoodDB.FoodModels;

namespace ReceptWpf.App.Components.NavPages.Show;

public partial class ShowControl : UserControl
{
    public Food Food;
    public ShowControl(Food food)
    {
        InitializeComponent();
        Food = food;
        ImageStack.Source = new BitmapImage(new Uri(Food.FoodPhoto));
    }
}