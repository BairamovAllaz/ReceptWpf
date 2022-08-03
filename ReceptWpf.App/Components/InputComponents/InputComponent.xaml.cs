using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ReceptWpf.App.Components.InputComponents;

public partial class InputComponent : UserControl,INotifyPropertyChanged
{
    private string _labelname;
    private bool _isempty;

    public string LabelName
    {
        get=>_labelname;
        set
        {
            if (value is null) return;
            if (_labelname == value) return;
            _labelname = value;
            OnPropertyChanged(nameof(LabelName));
        }
    }

    public bool IsEmpty
    {
        get => _isempty;
        set
        {
            if (_isempty == value) return;
            _isempty= value;
            OnPropertyChanged(nameof(IsEmpty));               
        }
    }
    private void InputMy_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (InputMy.Text.Length > 0)
        {
            IsEmpty = true;
        }
        else
        {
            IsEmpty = false;
        }
    }
    public InputComponent()
    {
        InitializeComponent();
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

   
}