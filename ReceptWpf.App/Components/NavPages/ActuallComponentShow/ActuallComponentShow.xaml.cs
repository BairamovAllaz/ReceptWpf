using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using IronPdf;
using Microsoft.Win32;
using Models.FoodDB;
using Models.FoodDB.FoodModels;
using ReceptWpf.App.Components.NavPages.Home.NavigateConfigs;
using ReceptWpf.App.Configs;
using NavigationViewModel = ReceptWpf.App.Windows.HomeWindows.NavigationViewModel;

namespace ReceptWpf.App.Components.NavPages.ActuallComponentShow;
public partial class ActuallComponentShow : UserControl
{
    /// <summary>
    /// Food which user clicked at show component
    /// </summary>
    public Food food { get; set; }
    
    /// <summary>
    /// Variable which hold current user created that food or not.If true than will enable delete button.
    /// </summary>
    public bool IsUser { get; set; }
    
    /// <summary>
    /// List of Ingredients,in current food
    /// </summary>
    public List<string> IngredientsList { get; set; }
    public ActuallComponentShow()
    {
        //take food from home component
        food = Home.Home.Foood;
        //get all Ingredients
        IngredientsList = GetIngredients();
        //check if user admin
        IsUser = CheckUser(food?.CreatedBy);
        InitializeComponent();
        //Push food image to image source
        ImageStack.Source = new BitmapImage(new Uri(food.FoodPhoto));
        CopyFromBufToIndex();
    }

    /// <summary>
    /// Method which take authorization user from config file and chech if with current user
    /// if users equal return true otherwise false
    /// </summary>
    /// <param name="username">Current user</param>
    /// <returns></returns>
    private bool CheckUser(string username)
    {
        var actuallUser = UserConfig.GetUserFromJsonFile();
        if (username == actuallUser?.FirstName)
        {
            return true;
        }
        return false;
    }
    
    /// <summary>
    /// Get all Ingredients from string and return list of Ingredients
    /// </summary>
    /// <returns>List of Ingredients</returns>
    public List<string> GetIngredients()
    {
        List<string> fake = new List<string>();
        string[] list = food.Ingredients.Split(',');
        foreach (var s in list)
        {
            fake.Add(s);
        }
        return fake;
    }
    /// <summary>
    /// Event for delete food works if isUser true
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
           MessageBoxResult resultmessage = MessageBox.Show("Info",$"Are you sure to delete food {food.FoodTittle}",MessageBoxButton.YesNo);
           if (resultmessage == MessageBoxResult.Yes)
           {
               FoodDatabase foodDatabase = new FoodDatabase();
               int result = foodDatabase.DeleteFood(food.Id);
               if (result == 1)
               {
                   HyperlinkButton.DoClick();
               }     
           }
           else
           {
               return;
           }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
        
    }
    /// <summary>
    /// Method that open buffer.html and write to index.html
    /// </summary>
    private void CopyFromBufToIndex()
    {
        string htmltext = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "buffer.html"));
        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(),"index.html"),htmltext);
    }

    /// <summary>
    /// Create and initalization savedialog object for pdf
    /// </summary>
    /// <returns>SaveDialog object</returns>
    private SaveFileDialog InitSaveDialog()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = @"C:\";
        saveFileDialog.Title = "Save pdf file";
        saveFileDialog.DefaultExt = "pdf";
        saveFileDialog.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
        saveFileDialog.FilterIndex = 2;
        saveFileDialog.RestoreDirectory = true;
        return saveFileDialog;
    }
    
    private void PdfButton_OnClick(object sender, RoutedEventArgs e)
    {
        CopyFromBufToIndex();
        SaveFileDialog saveFileDialog = InitSaveDialog();
        Nullable<bool> result = saveFileDialog.ShowDialog();
        if (result == true)
        {
            string filename = saveFileDialog.FileName;
            SaveToHtml();
            var htmlLine = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),"index.html"));
            new HtmlToPdf().RenderHtmlAsPdf(htmlLine).SaveAs(filename);
            MessageBox.Show("File succesfully saved");
        }
    }
    
    /// <summary>
    /// Opens html file (resource type) and replace all the text inside from food object
    /// </summary>
    private void SaveToHtml()
    {
        var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(q => q.Contains("index.html"));
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        
        using (StreamReader reader = new(stream: stream))
        {
            string html = reader.ReadToEnd()
                .Replace("$$FOODTITLE$$", food.FoodTittle)
                .Replace("$$PREPARATIONTIME$$", food.PreparationTime)
                .Replace("$$DIFFICULTYFOOD$$", food.DifficultyFood)
                .Replace("$$CREATEDTIME$$", food.CreatedTime.ToString())
                .Replace("$$FOODPHOTO$$", food.FoodPhoto)
                .Replace("$$COUNTRY$$", food.Country)
                .Replace("$$INGREDIENTS$$", food.Ingredients)
                .Replace("$$PRETENSIONS$$", food.Pretensions)
                .Replace("$$CREATEDBY$$", food.CreatedBy);
            File.WriteAllText("index.html", html);
        }
    }
}
