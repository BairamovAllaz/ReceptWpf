using System.Data;
using Microsoft.Data.Sqlite;
namespace Models;
public class UserDatabase
{
    // TODO FIX ENVORIMENT VARIABLE PROBLEM
    private readonly string? connstring = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    private SqliteConnection _db;
    public UserDatabase()
    {
        _db = new SqliteConnection(connstring);
    }
    public int InsertUser(User user)
    {
        _db.Open();
        string sql = @$"INSERT INTO User(first_name,last_name,email,password,email,phone_number) VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}','{user.Email}','{user.Phone_number}')";
        SqliteCommand command = new SqliteCommand(sql,_db);
        var result = command.ExecuteNonQuery();
        _db.Close();
        return result;
    }
    public User? GetUser(LoginUser loginUser)
    {
        _db.Open();
        var sql = @$"SELECT * FROM User WHERE email='{loginUser.Email}' AND password = '{loginUser.Password}'";
        var command = new SqliteCommand(sql,_db);
        var result = command.ExecuteReader();
        User? user = null;
        if (result.HasRows)
        {
            if (result.Read())
            {
                user = new User
                {
                    Id = result.GetInt32("user_id"),
                    FirstName = result.GetString("first_name"),
                    LastName = result.GetString("last_name"),
                    Email = result.GetString("email"),
                    Password = result.GetString("password"),
                    Phone_number = result.GetString("phone_number")
                };
            }
        }
        _db.Close();
        return user;
    }
}