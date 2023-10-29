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
    [ObservableProperty] private double _investmentValue;
    [ObservableProperty] private double _interestRate;
    [ObservableProperty] private int _compoundRate;
    [ObservableProperty] private int _yearsInvested;
    [ObservableProperty] private string _output = string.Empty;

    private void _displayOutput(double fv)
    {
        Output += $"ROI: {fv:C2}";
    }
    
    [RelayCommand]
    private void CalculateInvestment()
    {
        var fv = InvestmentValue * Math.Pow((1 + InterestRate / 100 / CompoundRate), CompoundRate * YearsInvested);
        _displayOutput(fv: fv);
    }

    [RelayCommand]
    private void ClearForm()
    {
        InvestmentValue = 0;
        InterestRate = 0;
        CompoundRate = 0;
        YearsInvested = 0;
    }

    [RelayCommand]
    private void ClearAll()
    {
        ClearForm();
        Output = string.Empty;
    }
}