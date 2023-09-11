using System;
namespace Assignment1AM
{
	public class Inventory
	{
		private Product[] products;
		private int maxProducts;
		public const int MIN_PRODS = 3;
		private int numProducts;

		public Inventory()
		{
			products = new Product[MIN_PRODS];
			maxProducts = MIN_PRODS;
			numProducts = 0;
		}

		//Overloaded construcor
		public Inventory(int maxProds)
		{
			if (maxProds < MIN_PRODS)
			{
				maxProds = MIN_PRODS;
			}
			maxProducts = maxProds;
			products = new Product[maxProducts];
			numProducts = 0;
		}

		public int MaxProducts  //I am using what C# calls a property
			//which is a way to get and set private fields. I am not using a setter here.
			//I want it to be readonly.
			//This will automatically get maxProducts
		{
			get { return maxProducts; }
		}

		public int NumProducts //This will automatically get numProducts
        {
			get { return numProducts; }
		}

		public bool AddProduct(Product prod)
		{
			if (prod == null || numProducts == maxProducts)
			{
				return false; //indicating that you did not add anything
			}
			//add the product to the list and increase the count by one

			products[numProducts] = prod;
			numProducts++;
			return true;
		}

        public Product GetProductAtIndex(int whichPos)
        {
            if (whichPos < 0 || whichPos >= numProducts)
            {
                return null; //indicating no such product
            }
            //return the product at that location in the array

            return products[whichPos];
        }

        public Product RemoveProductAtIndex(int whichPos)
        {
            if (whichPos < 0 || whichPos >= numProducts)
            {
                return null; //indicating no such product
            }
			Product prodToRemove = products[whichPos];
			int lastIndex = numProducts - 1;
			//move the product at the last poisiton into the position of the one
			//you are removing.
			products[whichPos] = products[lastIndex];
			//set last position to null
            products[lastIndex] = null;
            // drop the count by one.
            numProducts--;
            return prodToRemove;
        }

		public int FindProductIndex(string prodID)
		{
			//linear search
			int pos = -1;
			for(int i = 0; i < numProducts; i++)
			{
				Product prod = products[i];
				if(prod.GetProdID() == prodID)
				{
					pos = i;
					break;  //get out of loop because you found it
				}
			}
			return pos;
		}

		private bool _swap(int x, int y)
		{
			Product temp = products[x];
			products[x] = products[y];
			products[y] = temp;
			return true;
		}

		public void SortProducts()
		{
			bool swapped;
			for(int i = 0; i < NumProducts - 1; i++)
			{
				swapped = false;
				for(int j = 0; j < NumProducts - i - 1; j++)
				{
					if(Int32.Parse(products[j].GetProdID()) > Int32.Parse(products[j + 1].GetProdID()))
					{
						swapped = _swap(j, j + 1);
					}
				}
				
				if(!swapped) break;
			}
		}

    }
}

