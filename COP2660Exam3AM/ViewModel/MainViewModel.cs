using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using COP2660Exam3AM.Model;

namespace COP2660Exam3AM.ViewModel;

[ObservableObject]
public partial class MainViewModel
{
    [ObservableProperty] private string itemName;
    [ObservableProperty] private int quantity;
    [ObservableProperty] private double price;
    [ObservableProperty] private List<InventoryItem> inventory;
    private readonly Page mainPage = Application.Current?.MainPage;

    public MainViewModel()
    {
        ItemName = string.Empty;
        Quantity = 0;
        Price = 0;
        Inventory = new List<InventoryItem>();
    }

    [RelayCommand]
    private async Task AddItem()
    {
        if (string.IsNullOrEmpty(this.ItemName) || this.Quantity <= 0 || this.Price <= 0)
        {
            
            await mainPage.DisplayAlert("Invalid Field Entry", "One or more data fields contains an invalid value",
                "OK");
            
            ClearAllEntryFields();
            return;
        }

        if (ItemInInventory())
        {
            
            await mainPage.DisplayAlert("Attempt To Add Item Failed", "Item is already in the inventory!", "OK");
            
            ClearAllEntryFields();
            return;
        }

        var item = new InventoryItem
        {
            ItemName = this.ItemName,
            Quantity = this.Quantity,
            Price = this.Price
        };
        Inventory.Add(item);
        Inventory = new List<InventoryItem>(Inventory);
        ClearAllEntryFields();
    }

    private void ClearAllEntryFields()
    {
        this.ItemName = string.Empty;
        this.Quantity = 0;
        this.Price = 0;
    }

    private bool ItemInInventory()
    {
        foreach (var item in Inventory)
        {
            if (item.ItemName == this.ItemName)
            {
                return true;
            }
        }

        return false;
    }
}