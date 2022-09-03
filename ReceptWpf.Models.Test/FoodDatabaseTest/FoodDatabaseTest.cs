using System;
using System.Collections.Generic;
using System.Globalization;
using Models.FoodDB;
using Models.FoodDB.FoodModels;
using Xunit;
namespace ReceptWpf.Models.Test;
public class FoodDatabaseTest
{
    [Fact]
    public void InsertFood_Test()
    {
        var food = new Food
        {
            FoodTittle = "Chorizo & mozzarella gnocchi bake",
            FoodPhoto = "urlnothing",
            CreatedBy = "Bairamov Allaz",
            PreparationTime = "25",
            Country = "Russia",
            DifficultyFood = "Easy",
            CreatedTime = Convert.ToDateTime(DateTime.Now, CultureInfo.InvariantCulture),
            Ingredients = "1 tbsp olive oil,1 onion-finely chopped,1 tsp caster sugar",
            Pretensions = @"Heat the oil in a medium pan over 
                            a medium heat. Fry the onion and garlic for 8-10 mins until soft. 
                            Add the chorizo and fry for 5 mins more.
                            Tip in the tomatoes and sugar, and season. 
                            Bring to a simmer, then add the gnocchi and cook for 8 mins, stirring often, until soft. 
                            Heat the grill to high."
        };
        var expected = 1;
        var actual = new FoodDatabase().InsertFood(food:food);
        Assert.Equal(expected,actual);
    }

    [Fact]
    public void GetAllFoods_Test()
    {
        var listFood = new List<Food>
        {
            new Food
            {
                FoodTittle = "Chorizo & mozzarella gnocchi bake",
                FoodPhoto = "urlnothing",
                CreatedBy = "Bairamov Allaz",
                PreparationTime = "25",
                Country = "Russia",
                DifficultyFood = "Easy",
                CreatedTime = Convert.ToDateTime(DateTime.Now, CultureInfo.InvariantCulture),
                Ingredients = "1 tbsp olive oil,1 onion-finely chopped,1 tsp caster sugar",
                Pretensions = @"Heat the oil in a medium pan over 
                            a medium heat. Fry the onion and garlic for 8-10 mins until soft. 
                            Add the chorizo and fry for 5 mins more.
                            Tip in the tomatoes and sugar, and season. 
                            Bring to a simmer, then add the gnocchi and cook for 8 mins, stirring often, until soft. 
                            Heat the grill to high."
            }
        };
        var actual = new FoodDatabase().GetAllFoods();
        Assert.Equal(listFood,actual);
    }

    /*TODO FIX DELETEFOOD_TEST*/
    /*[Fact]
    public void DeleteFood_Test()
    {
        var food = new Food
        {
            Id = 4,
            FoodTittle = "test8",
            FoodPhoto = "urlnothing",
            CreatedBy = "somehow",
            PreparationTime = "25",
            Country = "Russia",
            DifficultyFood = "Easy",
            CreatedTime = Convert.ToDateTime(DateTime.Now, CultureInfo.InvariantCulture),
            Ingredients = "test string",
            Pretensions = @"Something"
        };
        FoodDatabase database = new FoodDatabase();
        database.InsertFood(food);
        var actuall = database.DeleteFood(food.Id);
        var expected = 1;
        database.InsertFood(food);
        Assert.Equal(expected,actuall);
    }*/
}