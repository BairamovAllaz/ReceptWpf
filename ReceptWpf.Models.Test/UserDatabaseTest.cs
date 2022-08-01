using Models;
using Models.UserDB;
using Models.UserDB.User_Models;
using Xunit;

namespace ReceptWpf.Models.Test;

public class UserDatabaseTest
{
    [Fact]
    public void InsertUser_Test()
    {
        var user = new User
        {
            FirstName = "User3",
            LastName = "Fake3",
            Email = "FakeUser3@gmail.com",
            Password = "123",
            Phone_number = "+798653412455"
        };
        var expected = 1;
        var actual = new UserDatabase().InsertUser(user);
        Assert.Equal(expected,actual);
    }

    [Fact]
    public void GetUser_Test()
    {
        var loginuser = new LoginUser
        {
            Email = "FakeUser3@gmail.com",
            Password = "123"
        };
        var expected = new User
        {
            FirstName = "User3",
            LastName = "Fake3",
            Email = "FakeUser3@gmail.com",
            Password = "123",
            Phone_number = "+798653412455"
        };
        var actual = new UserDatabase().GetUser(loginuser);
        Assert.Equal(expected,actual);
    }
}