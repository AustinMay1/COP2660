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
    [ObservableProperty] private string _payOutput = string.Empty;

    [RelayCommand]
    private void CalculatePay()
    {
        const float taxRate = 0.2f;
        var grossPay = EmployeeHours * EmployeePayRate;
        var taxes = grossPay * taxRate;
        var netPay = grossPay - taxes;

        PayOutput +=
            $"Employee Pay:\n" +
            $"Employee ID: {EmployeeID}\n" +
            $"Employee Name: {EmployeeName}\n" +
            $"Employee Hours: {EmployeeHours}\n" +
            $"Employee Pay Rate: {EmployeePayRate}\n" +
            $"Gross Pay: ${grossPay}\n" +
            $"Taxes: ${taxes}\n" +
            $"Net Pay: ${netPay}\n\n";
    }

    [RelayCommand]
    private void ClearInput()
    {
        EmployeeID = string.Empty;
        EmployeeName = string.Empty;
        EmployeeHours = 0;
        EmployeePayRate = 0;
    }

    [RelayCommand]
    private void ClearOutput()
    {
        PayOutput = string.Empty;
    }
}