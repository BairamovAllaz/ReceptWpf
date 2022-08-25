using System.IO;
using System.Text.Json;
using Models.UserDB.User_Models;
using ReceptWpf;

namespace ReceptWpf.App.Configs;

public static class UserConfig
{
    private static string _filename = "UserData.json";
    
    public static void SaveToJsonFile(User user)
    {
        using StreamWriter streamWriter = new StreamWriter(_filename,append:false);
        string jsonstring = JsonSerializer.Serialize<User>(user);
        streamWriter.Write(jsonstring);
    }

    public static User GetUserFromJsonFile()
    {
        string jsonString = File.ReadAllText(_filename);
        User? juser = JsonSerializer.Deserialize<User>(jsonString);
        return juser;
    }
}