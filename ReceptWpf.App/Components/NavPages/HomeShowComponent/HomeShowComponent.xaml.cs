using System.Collections.Generic;
using System.Windows.Controls;
using Models.FoodDB;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Show;

namespace ReceptWpf.App.Components.NavPages.HomeShowComponent;

public partial class HomeShowComponent : UserControl
{
    public List<Food> ListFood;
    public HomeShowComponent()
    {
        ListFood = new FoodDatabase().GetAllFoods();
        InitializeComponent();
        foreach (var food in ListFood)
        {
            Stack.Children.Add(new ShowControl(food));   
        }
    }
}