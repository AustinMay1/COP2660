using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVMPayrollAppAM.ViewModel;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private string _employeeID;
    [ObservableProperty] private string _employeeName;
    [ObservableProperty] private float _employeeHours;
    [ObservableProperty] private float _employeePayRate;
}