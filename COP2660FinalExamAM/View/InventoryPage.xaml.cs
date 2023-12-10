using COP2660FinalExamAM.ViewModel;

namespace COP2660FinalExamAM.View;

public partial class InventoryPage : ContentPage
{
	private InventoryViewModel _vm = new InventoryViewModel();
	public InventoryPage()
	{
		InitializeComponent();
		BindingContext = _vm; 
	}
}