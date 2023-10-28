using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP2660Exam2AM.ViewModel;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private double _initialInvestment;
    [ObservableProperty] private double _interestRate;
    [ObservableProperty] private int _compoundRate;
    [ObservableProperty] private int _yearsInvested;
    
}
