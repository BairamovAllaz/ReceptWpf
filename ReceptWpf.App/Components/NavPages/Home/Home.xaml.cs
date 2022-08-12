using System.Collections.Generic;
using System.Windows.Controls;
using Models.FoodDB;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Show;

namespace ReceptWpf.App.Components.NavPages.Home;

public partial class Home : UserControl
{
    public List<Food> listFood;
    public Home()
    {
        listFood = new FoodDatabase().GetAllFoods();
        InitializeComponent();
        foreach (var food in listFood)
        {
            Stack.Children.Add(new ShowControl(food));   
        }
    }
}