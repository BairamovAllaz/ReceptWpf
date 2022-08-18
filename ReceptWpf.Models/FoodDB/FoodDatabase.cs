using System.Data;
using Microsoft.Data.Sqlite;
using Models.DBconfig;
using Models.FoodDB.FoodModels;

namespace Models.FoodDB;

public class FoodDatabase : Db
{
    public FoodDatabase() : base() {}
    public int InsertFood(Food food)
    {
        _db.Open();
        string sql = @$"INSERT INTO Food(preparation_time,difficulty_food,country,created_time,food_photo,food_title,ingredients,pretensions,created_by) VALUES ('{food.PreparationTime}','{food.DifficultyFood}','{food.Country}','{food.CreatedTime:g}','{food.FoodPhoto}','{food.FoodTittle}','{food.Ingredients}','{food.Pretensions}','{food.CreatedBy}')";
        SqliteCommand command = new SqliteCommand(sql,_db);
        var result = command.ExecuteNonQuery();
        _db.Close();
        return result; 
    }
    
    public List<Food> GetAllFoods()
    { 
        _db.Open();
        var sql = @$"SELECT * FROM Food";
        var command = new SqliteCommand(sql,_db);
        var result = command.ExecuteReader();
        var foodList = new List<Food>();
        if (result.HasRows)
        {
            while (result.Read())
            {
                foodList.Add(new Food{ 
                    Id = result.GetInt32("food_id"),
                    PreparationTime = result.GetString("preparation_time"),
                    DifficultyFood = result.GetString("difficulty_food"),
                    CreatedTime = Convert.ToDateTime(result.GetString("created_time")),
                    FoodPhoto = result.GetString("food_photo"),
                    Country = result.GetString("country"),
                    FoodTittle = result.GetString("food_title"), 
                    Ingredients = result.GetString("ingredients"),
                    Pretensions = result.GetString("pretensions"),
                    CreatedBy = result.GetString("created_by") 
                });
            }
        }
        _db.Close();
        return foodList;
    }
    public int DeleteFood(int foodid)
    {
        _db.Open();
        string sql = @$"DELETE FROM Food WHERE food_id == '{foodid}'";
        SqliteCommand command = new SqliteCommand(sql,_db);
        var result = command.ExecuteNonQuery();
        _db.Close();
        return result;
    }
}