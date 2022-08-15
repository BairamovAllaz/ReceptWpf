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
using Models.FoodDB.FoodModels;
namespace ReceptWpf.App.Components.NavPages.ActuallComponentShow;
public partial class ActuallComponentShow : UserControl
{
    public Food food { get; set; }
    public List<string> IngredientsList { get; set; }
    public ActuallComponentShow()
    {
        food = Home.Home.Foood;
        IngredientsList = GetIngredients();
        InitializeComponent();
        ImageStack.Source = new BitmapImage(new Uri(food.FoodPhoto));
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
    private void PdfButton_OnClick(object sender, RoutedEventArgs e)
    {
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
        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string html = reader.ReadToEnd()
                    .Replace("$$FOODTITLE$$", food.FoodTittle)
                    .Replace("$$PREPARATIONTIME$$", food.PreparationTime)
                    .Replace("$$DIFFICULTYFOOD$$", food.DifficultyFood)
                    .Replace("$$CREATEDTIME$$", food.CreatedTime)
                    .Replace("$$FOODPHOTO$$", food.FoodPhoto)
                    .Replace("$$COUNTRY$$", food.Country)
                    .Replace("$$INGREDIENTS$$", food.Ingredients)
                    .Replace("$$PRETENSIONS$$", food.Pretensions)
                    .Replace("$$CREATEDBY$$", food.CreatedBy);
                File.WriteAllText("index.html", html);
            }
        }
    }
}
