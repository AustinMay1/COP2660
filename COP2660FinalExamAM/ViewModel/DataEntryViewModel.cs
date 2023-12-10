using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using COP2660FinalExamAM.Model; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP2660FinalExamAM.ViewModel;

[ObservableObject]
public partial class DataEntryViewModel
{
    [ObservableProperty] private string itemName;
    [ObservableProperty] private string quantity;
    [ObservableProperty] private string price;
    [ObservableProperty] private List<InventoryItem> inventory;
    [ObservableProperty] private InventoryItem item;
    private readonly Page mainPage = Application.Current?.MainPage;

    public DataEntryViewModel()
    {
        ItemName = string.Empty;
        Quantity = string.Empty;
        Price = string.Empty;
        Inventory = new List<InventoryItem>();
    }

    [RelayCommand]
    private async Task AddItem()
    {
        if (string.IsNullOrEmpty(this.ItemName) || int.Parse(this.Quantity) <= 0 || double.Parse(this.Price) <= 0)
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

        Item = new InventoryItem
        {
            ItemName = this.ItemName,
            Quantity = int.Parse(this.Quantity),
            Price = double.Parse(this.Price)
        };
        Inventory.Add(Item);
        var newItem = new Dictionary<string, object> { { "NewItem", Item } };
        ClearAllEntryFields();
        await Shell.Current.GoToAsync($"inventoryitempage", newItem);
    }

    private void ClearAllEntryFields()
    {
        this.ItemName = string.Empty;
        this.Quantity = string.Empty;
        this.Price = string.Empty;
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
