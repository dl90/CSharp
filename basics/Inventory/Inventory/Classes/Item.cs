namespace Inventory.Classes
{
    class Item
    {
        private string name;
        private int count;
        private decimal price;

        public Item(string name, int count, decimal price)
        {
            Name = name;
            Count = count;
            Price = price;
        }

        public string Name
        {
            get
            {
               return name;
            }

            set
            {
                if (Util.CheckEmptyString(value)) name = value;
            }

        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                if (Util.CheckValidCount(value)) count = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                if (Util.CheckValidPrice(value)) price = value;
            }
        }
    }
}
