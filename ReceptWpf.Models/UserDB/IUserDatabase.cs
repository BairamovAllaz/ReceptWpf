using Models.UserDB.User_Models;

namespace Models.UserDB;

public interface IUserDatabase
{
    public int InsertUser(User user);
    public User? GetUser(LoginUser loginUser);
}