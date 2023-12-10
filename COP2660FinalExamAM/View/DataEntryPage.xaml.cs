using COP2660FinalExamAM.ViewModel;

namespace COP2660FinalExamAM.View;

public partial class DataEntryPage : ContentPage
{
	private DataEntryViewModel _vm = new DataEntryViewModel();
	public DataEntryPage()
	{
		InitializeComponent();
		BindingContext = _vm;
	}
}