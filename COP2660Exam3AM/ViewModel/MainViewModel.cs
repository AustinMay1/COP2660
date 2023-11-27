using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using COP2660Exam3AM.Model;

namespace COP2660Exam3AM.ViewModel;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private string _itemName;
    [ObservableProperty] private int _quantity;
    [ObservableProperty] private double _price;
    [ObservableProperty] private List<InventoryItem> _inventory;

    public MainViewModel()
    {
        ItemName = string.Empty;
        Quantity = 0;
        Price = 0;
        Inventory = new List<InventoryItem>();
    }

    [RelayCommand]
    public async Task AddItem()
    {
        InventoryItem item = new InventoryItem();
        item.ItemName = this.ItemName;
        item.Quantity = this.Quantity;
        item.Price = this.Price;
        Inventory.Add(item);
        Inventory = new List<InventoryItem>(Inventory);
    }
}
