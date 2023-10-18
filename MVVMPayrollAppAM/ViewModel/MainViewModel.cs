using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MVVMPayrollAppAM.ViewModel;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private string _employeeID;
    [ObservableProperty] private string _employeeName;
    [ObservableProperty] private float _employeeHours;
    [ObservableProperty] private float _employeePayRate;
    [ObservableProperty] private string _payOutput = String.Empty;

    [RelayCommand]
    private void CalculatePay()
    {
        PayOutput = "Hello, World";
    }
}