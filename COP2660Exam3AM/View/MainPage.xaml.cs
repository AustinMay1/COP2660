using COP2660Exam3AM.ViewModel;

namespace COP2660Exam3AM.View;

public partial class MainPage : ContentPage
{
    private MainViewModel _vm = new MainViewModel();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }
}