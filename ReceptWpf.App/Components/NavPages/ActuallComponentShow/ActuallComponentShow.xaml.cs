using System.Windows.Controls;
using Models.FoodDB.FoodModels;

namespace ReceptWpf.App.Components.NavPages.ActuallComponentShow;

public partial class ActuallComponentShow : UserControl
{
    public Food food { get; set; }
    public ActuallComponentShow()
    {
        InitializeComponent();
    }
}