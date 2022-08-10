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
using ReceptWpf.App.Configs;

namespace ReceptWpf.App.Components.NavPages.CreatePage;

public partial class CreatePage : UserControl,INotifyPropertyChanged
{
    private string? _photo;
    public ObservableCollection<string> ListOfAddedIngredients { get; set;  }
    private string _firstdefautllistvalue = "THERE IS NO ELEMENT"; 
    public Models.UserDB.User_Models.User? User{ get; set; }
    public CreatePage()
    {
        ListOfAddedIngredients = new ObservableCollection<string>();
        ListOfAddedIngredients.Add(_firstdefautllistvalue);
        InitializeComponent();
        User = UserConfig.GetUserFromJsonFile();
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
        var food = CreateFoodObj();
        FoodDatabase foodDatabase = new FoodDatabase();
        int result = foodDatabase.InsertFood(food);
        if (result == 1) MessageBox.Show("Adding done","Info",MessageBoxButton.OK,MessageBoxImage.Information);
        FilesButtonSaveClick(food);
        ClearAll();
    }

    private void FilesButtonSaveClick(Food food)
    {
        var ext = _photo?.Substring(_photo.LastIndexOf('.'));
        File.Copy(_photo, $@"C:\PhotosWpf\{food.FoodTittle}_{food.CreatedBy}{ext}", true);
        var url = $@"{Directory.GetCurrentDirectory()}\default2.png";
        PhotoPlace.Source = new BitmapImage(new Uri(url));
    }

    private Food CreateFoodObj()
    {
        return new Food
        {
            PreparationTime = TimePickerTextBox.Text,
            CreatedTime = new DateTime().Date.ToString(CultureInfo.InvariantCulture),
            FoodPhoto = _photo,
            FoodTittle = TitleBox.Text,
            DifficultyFood = ComboBox.SelectionBoxItem.ToString(),
            Ingredients = GetIngredients(),
            Country = CountryBox.Text,
            Pretensions = PretensionsTextBox.Text,
            CreatedBy = User.FirstName 
        };
    }
    private string GetIngredients()
    {
        StringBuilder stringBuffer = new StringBuilder();
        for (int i = 0; i < ListOfAddedIngredients.Count; i++)
        {
            if (i == 0) stringBuffer.Append(ListOfAddedIngredients[i]); //if first element then just add without ,
            else stringBuffer.Append(", " + ListOfAddedIngredients[i]);
        }
        return stringBuffer.ToString();
    }

    private void ClearAll()
    {
        TimePickerTextBox.Clear();
        TitleBox.Clear();
        PretensionsTextBox.Clear();
        CountryBox.Clear();
        ListOfAddedIngredients.Clear();
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}