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
    public Food food { get; set; }
    public bool IsUser { get; set; }
    public List<string> IngredientsList { get; set; }
    public ActuallComponentShow()
    {
        food = Home.Home.Foood;
        IngredientsList = GetIngredients();
        IsUser = CheckUser(food?.CreatedBy);
        InitializeComponent();
        ImageStack.Source = new BitmapImage(new Uri(food.FoodPhoto));
    }

    private bool CheckUser(string username)
    {
        var actuallUser = UserConfig.GetUserFromJsonFile();
        if (username == actuallUser?.FirstName)
        {
            return true;
        }
        return false;
    }
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
    /*TODO STYLING DELETE BUTTON*/
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
    private void PdfButton_OnClick(object sender, RoutedEventArgs e)
    {
        string htmltext = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "buffer.html"));
        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(),"index.html"),htmltext);
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = @"C:\";
        saveFileDialog.Title = "Save pdf file";
        saveFileDialog.DefaultExt = "pdf";
        saveFileDialog.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
        saveFileDialog.FilterIndex = 2;
        saveFileDialog.RestoreDirectory = true;
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
                /*.Replace("$$CREATEDTIME$$", food.CreatedTime.ToString())
                .Replace("$$FOODPHOTO$$", food.FoodPhoto)
                .Replace("$$COUNTRY$$", food.Country)
                .Replace("$$INGREDIENTS$$", food.Ingredients)
                .Replace("$$PRETENSIONS$$", food.Pretensions)
                .Replace("$$CREATEDBY$$", food.CreatedBy)*/;
            File.WriteAllText("index.html", html);
        }
    }


}
