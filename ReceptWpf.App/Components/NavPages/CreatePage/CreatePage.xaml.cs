using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Models.FoodDB;
using Models.FoodDB.FoodModels;
using Models.UserDB.User_Models;

namespace ReceptWpf.App.Components.NavPages.CreatePage;

public partial class CreatePage : UserControl,INotifyPropertyChanged
{
    private string? _photo;
    public ObservableCollection<string> ListOfAddedIngredients { get; set;  }
    private string _firstdefautllistvalue = "THERE IS NO ELEMENT"; 
    public Models.UserDB.User_Models.User User{ get; set; }
    public CreatePage()
    {
        ListOfAddedIngredients = new ObservableCollection<string>();
        ListOfAddedIngredients.Add(_firstdefautllistvalue);
        InitializeComponent();
        var url = $@"{Directory.GetCurrentDirectory()}\default2.png";
        PhotoPlace.Source = new BitmapImage(new Uri(url));
    }
    private void ChangePhotoButton_OnClick(object sender, RoutedEventArgs e)
    {
        var file = new OpenFileDialog();
        file.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
        file.ShowDialog();
        _photo = file.FileName;
        if(!(string.IsNullOrEmpty(_photo)))
        {
            PhotoPlace.Source = new BitmapImage(new Uri(_photo));
        }
    }
    private void ButtonAddOnclick(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(IngredientsTextBox.Text))
        {
            ListOfAddedIngredients.Add(IngredientsTextBox.Text);
            IngredientsTextBox.Clear();
            if (ListOfAddedIngredients.Count == 2) ListOfAddedIngredients.Remove(_firstdefautllistvalue);
        }
    }
    
    private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (ListOfAddedIngredients.Count > 0)
        {
            ListOfAddedIngredients.RemoveAt(ListOfAddedIngredients.Count - 1);
            IngredientsTextBox.Clear();
            if (ListOfAddedIngredients.Count == 0) ListOfAddedIngredients.Add(_firstdefautllistvalue);
        }
    }
    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        /*FIX NULL REFERENCE ERROR*/
        Food food = new Food()
        {   
            PreparationTime = TimePickerTextBox.Text,
            CreatedTime = new DateTime().Date.ToString(CultureInfo.InvariantCulture),
            FoodPhoto = _photo,
            FoodTittle = TitleBox.Text,
            DifficultyFood = ComboBox.SelectionBoxItem.ToString(),
            Ingredients = GetIngredients(),
            Pretensions = PretensionsTextBox.Text,
            CreatedBy = User.FirstName
        };
        FoodDatabase foodDatabase = new FoodDatabase();
        int result = foodDatabase.InsertFood(food);
        if (result == 1) MessageBox.Show("Adding done");
    }
    private string GetIngredients()
    {
        StringBuilder stringBuffer = new StringBuilder();
        foreach (var v in ListOfAddedIngredients)
        {
            stringBuffer.Append(", " + v);
        }
        return stringBuffer.ToString();
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}