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
        string sql = @$"INSERT INTO Food(preparation_time,difficulty_food,country,created_time,food_photo,food_title,ingredients,pretensions,created_by) VALUES ('{food.PreparationTime}','{food.DifficultyFood}','{food.Country}','{food.CreatedTime}','{food.FoodPhoto}','{food.FoodTittle}','{food.Ingredients}','{food.Pretensions}','{food.CreatedBy}')";
        SqliteCommand command = new SqliteCommand(sql,_db);
        var result = command.ExecuteNonQuery();
        _db.Close();
        return result; 
    }
}