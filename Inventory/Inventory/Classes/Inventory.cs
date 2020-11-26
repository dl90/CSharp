namespace Inventory.Classes
{
    class Inventory
    {
        GenericList<Item> items;

        public Inventory()
        {
            items = new GenericList<Item>();
        }

        public void AddItem(Item arg)
        {
            items.Add(arg);
        }

        public Item GetItem(int idx)
        {
            return items.Get(idx);
        }
    }
}
