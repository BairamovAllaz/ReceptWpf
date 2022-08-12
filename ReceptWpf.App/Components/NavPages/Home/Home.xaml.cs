using System.Collections.Generic;
using System.Windows.Controls;
using Models.FoodDB;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Home.NavigateConfigs;
using ReceptWpf.App.Components.NavPages.Show;

namespace ReceptWpf.App.Components.NavPages.Home;

public partial class Home : UserControl
{
    public NavigationViewModel TypeNavigationViewModel { get; set; }
    public Home()
    {
        TypeNavigationViewModel = new NavigationViewModel();
        InitializeComponent();
    }
}