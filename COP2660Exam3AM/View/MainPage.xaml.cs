using COP2660Exam3AM.ViewModel;

namespace COP2660Exam3AM.View;

public partial class MainPage : ContentPage
{
    private MainViewModel _vm;

    public MainPage()
    {
        this._vm = new MainViewModel();
        InitializeComponent();
        BindingContext = _vm;
    }
}
