using System.Windows;
using System.Windows.Controls;
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
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(food.ToString());
    }
}