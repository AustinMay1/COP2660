using MVVMCalculatorAppAM.ViewModel;

namespace MVVMCalculatorAppAM.View;

public partial class MainPage : ContentPage
{
    private MainViewModel _vm = new MainViewModel();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }
}