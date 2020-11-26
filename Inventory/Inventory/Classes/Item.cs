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
                if (value.Trim().Length > 0) name = value;
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
                if (value >= 0) count = value;
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
                if (value >= 0) price = value;
            }
        }
    }
}
