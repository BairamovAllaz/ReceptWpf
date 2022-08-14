using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Show;
namespace ReceptWpf.App.Components.NavPages.ActuallComponentShow;
public partial class ActuallComponentShow : UserControl
{
    public Food food { get; set; }
    public List<string> IngredientsList { get; set; }
    public ActuallComponentShow()
    {
        food = Home.Home.Foood;
        IngredientsList = GetIngredients();
        InitializeComponent();
        ImageStack.Source = new BitmapImage(new Uri(food.FoodPhoto));
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(food.ToString());
    }
    public List<string> GetIngredients()
    {
        List<string> fake = new List<string>();
        string[] list = food.Ingredients.Split(',');
        foreach (var s in list)
        {
            fake.Add(s);
        }
        return fake;
    }
}
