using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP2660Exam2AM.ViewModel;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private string _investmentValue = string.Empty;
    [ObservableProperty] private string _interestRate = string.Empty;
    [ObservableProperty] private string _compoundRate = string.Empty;
    [ObservableProperty] private string _yearsInvested = string.Empty;
    [ObservableProperty] private string _output = string.Empty;
    private readonly Page _mainPage = Application.Current?.MainPage;

    private void _displayOutput(double fv, double p)
    {
        var ai = fv - p;
        Output = $"Future Value: {fv:C2}\nAccrued Interest {ai:C2}\nPrincipal: {p:C2}";
    }
    
    [RelayCommand]
    private async Task CalculateInvestment()
    {
        var p = string.IsNullOrEmpty(InvestmentValue) ? 0 : double.Parse(InvestmentValue);
        var r = string.IsNullOrEmpty(InterestRate) ? 0 : double.Parse(InterestRate);
        var n = string.IsNullOrEmpty(CompoundRate) ? 0 : double.Parse(CompoundRate);
        var t = string.IsNullOrEmpty(YearsInvested) ? 0 : double.Parse(YearsInvested);
        
        if (p <= 0 || r <= 0 || n <= 0 || t <= 0 )
        {
            await _mainPage.DisplayAlert(
                "Invalid/Empty Fields",
                "One or more of your fields contain empty or invalid values. Please double check your fields and resubmit.",
                "OK"
                );
            return;
        }
        var fv = p * Math.Pow((1 + r / 100 / n), n * t);
        _displayOutput(fv: fv, p: p);
    }

    [RelayCommand]
    private void ClearForm()
    {
        InvestmentValue = string.Empty;
        InterestRate = string.Empty;
        CompoundRate = string.Empty;
        YearsInvested = string.Empty;
    }

    [RelayCommand]
    private void ClearAll()
    {
        ClearForm();
        Output = string.Empty;
    }
}