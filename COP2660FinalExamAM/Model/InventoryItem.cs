using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP2660FinalExamAM.Model;

[ObservableObject]

public partial class InventoryItem
{
    [ObservableProperty] string _itemName;
    [ObservableProperty] int _quantity;
    [ObservableProperty] double _price;

}
