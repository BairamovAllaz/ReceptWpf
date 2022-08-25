using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Models.FoodDB;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Show;
namespace ReceptWpf.App.Components.NavPages.HomeShowComponent;
public partial class HomeShowComponent : UserControl
{
    public List<Food> ListFood;
    private string _searchTitle;
    public HomeShowComponent()
    {
        ListFood = new FoodDatabase().GetAllFoods();
        InitializeComponent();
        foreach (var food in ListFood)
        {
            Stack.Children.Add(new ShowControl(food));   
        }
    }
    public string SearchTitle
    {
        get => _searchTitle;
        set
        {
            _searchTitle = value;
            ChangeList();
        }
    }
    private void ChangeList()
    {
        List<Food> list;
        if (!string.IsNullOrEmpty(SearchText.Text))
        {
            list = ListFood.FindAll(i => i.FoodTittle.Contains(SearchText.Text));
        }
        else
        {
            list = ListFood; 
        }
        Stack.Children.Clear();
        foreach (var food in list)
        {
            Stack.Children.Add(new ShowControl(food));   
        }
    }

    private void SearchText_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        ChangeList();
    }
}