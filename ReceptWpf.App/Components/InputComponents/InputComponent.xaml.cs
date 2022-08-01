using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ReceptWpf.App.Components.InputComponents;

public partial class InputComponent : UserControl,INotifyPropertyChanged
{
    private string _labelname;

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