using System.Windows.Controls;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Show;

namespace ReceptWpf.App.Components.NavPages;

public partial class Home : UserControl
{
    public Home()
    {
        var food = new Food
        {
            PreparationTime = "25",
            DifficultyFood = "Easy",
            CreatedTime = "01/01/0001 00:00:00",
            FoodPhoto = @"C:\PhotosWpf\TodoFood_Allaz.png",
            Country = "Russia",
            FoodTittle = "TodoFood",
            Ingredients = "somet, fsfds, sfsf, fdfd, sdfsd, dsfds",
            Pretensions = "som,ethiongh",
            CreatedBy = "Allaz"
        };
        InitializeComponent();
        for (int i = 0; i < 6; i++)
        {
            Stack.Children.Add(new ShowControl(food));   
        }
    }
}