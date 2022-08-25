using System.Windows.Controls;
using ReceptWpf.App.Configs;

namespace ReceptWpf.App.Components.NavPages.User;

public partial class User : UserControl
{
    public Models.UserDB.User_Models.User CurrentUser { get; set; }
    public User()
    {
        CurrentUser = UserConfig.GetUserFromJsonFile();
        InitializeComponent();
    }
}