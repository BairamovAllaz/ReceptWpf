using Models.UserDB.User_Models;
using Xunit;

namespace ReceptWpf.Models.Test.LoginUserTest;

public class LoginUserTest
{
    [Fact]
    public void UserLoginTest()
    {
        var fakeLoginUser = new LoginUser(Faker.NameFaker.Name(),Faker.TextFaker.Sentence());
        
    }
}