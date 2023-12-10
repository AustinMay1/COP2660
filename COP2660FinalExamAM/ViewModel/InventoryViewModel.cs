using CommunityToolkit.Mvvm.ComponentModel;
using COP2660FinalExamAM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP2660FinalExamAM.ViewModel;

[ObservableObject]
[QueryProperty(nameof(NewItem), "NewItem")]
public partial class InventoryViewModel
{
    [ObservableProperty] private List<InventoryItem> _inventory;
    public InventoryItem newItem = new InventoryItem();

    public InventoryItem NewItem
    {
        get => newItem;
        set
        {
            newItem = value;

            if (Inventory == null)
            {
                Inventory = new List<InventoryItem>();
            }

            Inventory.Add(newItem);
        }
    }
}
