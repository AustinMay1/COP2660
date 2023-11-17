using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MVVMCalculatorAppAM.ViewModel;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private string _output = String.Empty;
    [ObservableProperty] private string _firstOperand = String.Empty;
    [ObservableProperty] private string _secondOperand = String.Empty;
    [ObservableProperty] private string _operator = String.Empty;
    [ObservableProperty] private string _total = String.Empty;

    [RelayCommand]
    private void Input(string i)
    {
        if (Total.Length >= 1)
        {
            Clear();
        }
        Output += i;
    }

    [RelayCommand]
    private void Op(string i)
    {
        if (string.IsNullOrEmpty(Output))
        {
            return;
        }

        if (Operator.Length >= 1 && string.IsNullOrEmpty(SecondOperand))
        {
            var newOp = Output.Replace(Operator, i);
            Operator = i;
            Output = newOp;
            return;
        }

        if (SecondOperand.Length >= 1 && Operator.Length >= 1)
        {
            return;
        }

        if (FirstOperand.Length < 1)
        {
            FirstOperand = Output;
        }

        Operator = i;
        Output += i;
    }

    [RelayCommand]
    private void Enter()
    {
        if (FirstOperand.Length < 1)
        {
            FirstOperand = Output;
        }
        else if (FirstOperand.Length >= 1 && SecondOperand.Length < 1)
        {
            SecondOperand = Output.Substring(FirstOperand.Length + 1);
        }
    }

    [RelayCommand]
    private void Calculate()
    {
        if (string.IsNullOrEmpty(Output))
        {
            return;
        }

        if (FirstOperand.Length >= 1 && string.IsNullOrEmpty(SecondOperand) && Operator.Length >= 1)
        {
            SecondOperand = Output.Substring(FirstOperand.Length + 1);
        }

        if (FirstOperand.Length >= 1 && string.IsNullOrEmpty(SecondOperand))
        {
            Output += $"={FirstOperand}";
            return;
        }

        string calcTotal;

        try
        {
            calcTotal = Operator switch
            {
                "+" => (Int32.Parse(FirstOperand) + Int32.Parse(SecondOperand)).ToString(),
                "-" => (Int32.Parse(FirstOperand) - Int32.Parse(SecondOperand)).ToString(),
                "/" => (Int32.Parse(FirstOperand) / Int32.Parse(SecondOperand)).ToString(),
                "*" => (Int32.Parse(FirstOperand) * Int32.Parse(SecondOperand)).ToString(),
                _ => 0.ToString()
            };
        }
        catch (DivideByZeroException e)
        {
            calcTotal = 0.ToString();
        }

        Output += "=" + calcTotal;
        Total += calcTotal;
    }

    [RelayCommand]
    private void Clear()
    {
        Output = String.Empty;
        FirstOperand = String.Empty;
        SecondOperand = String.Empty;
        Operator = String.Empty;
        Total = String.Empty;
    }
}