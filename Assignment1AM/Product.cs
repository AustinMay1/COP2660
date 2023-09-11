using System;
namespace Assignment1AM
{
	public class Product
	{
		private string prodID;
		private string name;
		private double price;
		private uint quantity;
		private double markUp;
		public const double MIN_MARKUP = 0.1;

		public Product()
		{
			prodID = "";
			name = "";
			price = 0;
			quantity = 0;
			markUp = MIN_MARKUP;
		}

		public bool SetProdID(string pID)
		{
			if (pID == null)
			{
				//pID = "";
                return false;
			}

			prodID = pID;
            return true;
		}

        public bool SetName(string pName)
        {
            if (pName == null)
            {
                //pName = "";
                return false;
            }

            name = pName;
            return true;
        }

        public bool SetPrice(double pPrice)
		{
            if (pPrice < 0)
            {
                //pPrice = 0;
                return false;
            }

            price = pPrice;
            return true;
        }

        public bool SetQuantity(uint pQuant)
        {
            if (pQuant < 0)
            {
                //pQuant = 0;
                return false;
            }

            quantity = pQuant;
            return true;
        }

        public void SetMarkUp(double pMarkUp)
        {
            if (pMarkUp < MIN_MARKUP)
                pMarkUp = MIN_MARKUP;

            markUp = pMarkUp;
        }

        public string GetProdID()
		{
			return prodID;
		}

        public string GetName()
        {
            return name;
        }

		public double GetPrice()
		{
			return price;
		}

        public uint GetQuantity()
        {
            return quantity;
        }

        public double GetMarkUp()
        {
            return markUp;
        }

        public double GetTotalCost()
        {
            double cost = quantity * price;
            double markUp = cost * this.markUp;
            return cost + markUp;
        }

        public override string ToString()
        {
            return $"ID: {prodID} Name: {name} Price: {price:c} Quantity: {quantity}";
        }
    }
}

