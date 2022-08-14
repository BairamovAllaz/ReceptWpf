using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Models.FoodDB;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Home.NavigateConfigs;
using ReceptWpf.App.Components.NavPages.Show;

namespace ReceptWpf.App.Components.NavPages.Home;

public partial class Home : UserControl
{
    public NavigationViewModel TypeNavigationViewModel { get; set; }
    private static Food _currfood;
    public static Food Foood
    {
        get
        {
            if (_currfood == null)
            {
                _currfood = new Food(); 
            }
            return _currfood;
        }
        set => _currfood = value;
    }
    public Home()
    {
        TypeNavigationViewModel = new NavigationViewModel();
        InitializeComponent();
    }
}