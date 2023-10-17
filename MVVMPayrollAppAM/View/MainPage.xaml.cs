using MVVMPayrollAppAM.ViewModel;

namespace MVVMPayrollAppAM.View;

    public partial class MainPage : ContentPage
    {
        private MainViewModel _vm = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            _vm.EmployeeID = "1234567890";
            _vm.EmployeeName = "Austin M.";
            _vm.EmployeeHours = 60f;
            _vm.EmployeePayRate = 33.50f;
        }
    }
