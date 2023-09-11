namespace Assignment1AM;

class Program2
{
    static void Main(string[] args)
    {
        //Create an inventory object
        Inventory inventory = new Inventory(4);  //Call overloaded constructor

        uint choice;
        do
        {
            choice = Menu();
            ProcessChoice(choice, inventory);
        } while (choice != 99);

        //The following is just to stop the output screen from disappearing right away
        Console.Write("Press any key to quit: ");
        Console.ReadKey();
    }

    static uint Menu()
    {
        Console.WriteLine("Enter 1 to add a product.");
        Console.WriteLine("Enter 2 to remove a product.");
        Console.WriteLine("Enter 3 to find a product.");
        Console.WriteLine("Enter 4 to display all products.");
        Console.WriteLine("Enter 5 to sort the inventory.");
        Console.WriteLine("Enter 99 to quit.");
        Console.Write("Please make a choice... ");
        uint choice = Convert.ToUInt16(Console.ReadLine());
        return choice;
    }

    static void ProcessChoice(uint choice, Inventory inventory)
    {
        switch(choice)
        {
            case 1: AddToInventory(inventory);
                break;
            case 2: RemoveFromInventory(inventory);
                break;
            case 3: FindInInventory(inventory);
                break;
            case 4: DisplayAllProducts(inventory);
                break;
            case 5: SortAndDisplay(inventory);
                break;
            case 99: Console.WriteLine("Bye!");
                break;
            default: Console.WriteLine("Invalid choice!");
                break;
        }
    }

    static void AddToInventory(Inventory inventory)
    {
        Product prod = new Product();
        Console.Write("Enter product ID: ");
        string prodID = Console.ReadLine();
        prod.SetProdID(prodID);
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        prod.SetName(name);
        Console.Write("Enter product price: ");
        double price = Convert.ToDouble(Console.ReadLine());
        prod.SetPrice(price);
        Console.Write("Enter quantity: ");
        uint quantity = Convert.ToUInt16(Console.ReadLine());
        prod.SetQuantity(quantity);
        Console.Write("Enter markup: ");
        double markUp = Convert.ToDouble(Console.ReadLine());
        prod.SetMarkUp(markUp);
        if (inventory.AddProduct(prod))
        {
            Console.WriteLine(prodID + " added.");
        }
        else
        {
            Console.WriteLine("Unable to add " + prodID);
        }
    }

    static void RemoveFromInventory(Inventory inventory)
    {
        Console.Write("Enter product ID: ");
        string prodID = Console.ReadLine();
        int index = inventory.FindProductIndex(prodID);
        if (index == -1)
        {
            Console.WriteLine("No such product ID");
        }
        else
        {
            inventory.RemoveProductAtIndex(index);
        }
    }

    static void FindInInventory(Inventory inventory)
    {
        Console.Write("Enter product ID: ");
        string prodID = Console.ReadLine();
        int index = inventory.FindProductIndex(prodID);
        if (index == -1)
        {
            Console.WriteLine("No such product ID");
        }
        else
        {
            Product prod = inventory.GetProductAtIndex(index);
            DisplayProductData(prod);
        }
    }

    static void DisplayAllProducts(Inventory inventory)
    {
        Console.WriteLine("The current inventory contains "
            + inventory.NumProducts + " item(s).");
        for(int i = 0; i < inventory.NumProducts; i++)
        {
            Product prod = inventory.GetProductAtIndex(i);
            DisplayProductData(prod);
        }
    }

    static void DisplayProductData(Product prod)
    {
        Console.WriteLine("ID: " + prod.GetProdID());
        Console.WriteLine("Name: " + prod.GetName());
        Console.WriteLine("Price: " + prod.GetPrice().ToString("c"));
        Console.WriteLine("Quantity: " + prod.GetQuantity());

        Console.WriteLine(prod.ToString());
        Console.WriteLine("Total Cost: " + prod.GetTotalCost().ToString("c") + "\n");
    }

    static void SortAndDisplay(Inventory inventory)
    {
        inventory.SortProducts();
        DisplayAllProducts(inventory);
    }

}

