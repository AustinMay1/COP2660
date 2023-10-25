using System.Globalization;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MVVMPayrollAppAM.ViewModel;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private string? _employeeID;
    [ObservableProperty] private string? _employeeName;
    [ObservableProperty] private string? _employeeHours;
    [ObservableProperty] private string? _employeePayRate;
    [ObservableProperty] private string _payOutput = string.Empty;
    [GeneratedRegex("[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)")]
    private static partial Regex NumbersOnlyRegex();

    [GeneratedRegex(@"^[a-zA-Z\s]*$")]
    private static partial Regex LettersOnlyRegex();
    private readonly Page _main = Application.Current?.MainPage;
    
    [RelayCommand]
    private async Task CalculatePay()
    {
        if (!NumbersOnlyRegex().IsMatch(EmployeeHours ?? string.Empty) ||
            !NumbersOnlyRegex().IsMatch(EmployeePayRate ?? string.Empty) || 
            !LettersOnlyRegex().IsMatch(EmployeeName ?? string.Empty) ||
            EmployeeID == string.Empty)
        {
            await _main.DisplayAlert(
                "Invalid/Empty Fields!",
                "One or more fields contain invalid/empty values. Please check your fields and try again.",
                "OK"
            );

            return;
        }
        
        const float taxRate = 0.2f;
        var hrs = float.Parse(EmployeeHours);
        var rate = float.Parse(EmployeePayRate);
        var overtime = hrs > 40 ? hrs - 40 : 0;
        var grossPay = (hrs * rate) + (overtime * 1.5f);
        var taxes = grossPay * taxRate;
        var netPay = (grossPay - taxes);
        var hoursWorked = hrs > 40 ? 40 : hrs;

        PayOutput +=
            $"Employee\n" + $"----------\n" +
            $"ID: {EmployeeID}\n" +
            $"Name: {EmployeeName}\n" +
            $"Hours Worked: {hoursWorked:F2}\n" +
            $"Overtime: {overtime:F2}\n" +
            $"Pay Rate: {rate:C2}\n" +
            $"Gross Pay: {grossPay:C2}\n" +
            $"Taxes: {taxes:C2}\n" +
            $"Net Pay: {netPay:C2}\n\n";
    }

    [RelayCommand]
    private void ClearInput()
    {
        EmployeeID = string.Empty;
        EmployeeName = string.Empty;
        EmployeeHours =  string.Empty;
        EmployeePayRate = string.Empty;
    }

    [RelayCommand]
    private void ClearOutput()
    {
        PayOutput = string.Empty;
    }
}