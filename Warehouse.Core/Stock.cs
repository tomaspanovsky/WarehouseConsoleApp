namespace Warehouse
{
    public class Storage
    {
        private Dictionary<Blueprint, List<Item>> stock { get; set; } = new Dictionary<Blueprint, List<Item>>();

        internal Storage(){
        }

        public void AddToStorage(Item item)
        {
            if (!stock.ContainsKey(item.Blueprint))
            {
                stock[item.Blueprint] = new List<Item>();
            }

            stock[item.Blueprint].Add(item);
        }

        public int HowManyItemsInStorage(Blueprint blueprint = null)
        {
            if (blueprint == null)
            {
                int count = 0;
                foreach(var item in stock)
                {
                    count = count + item.Value.Count;
                }
                return count;
            }

            if (!stock.ContainsKey(blueprint))
            {
                return 0;
            }

            else
            {
                return stock[blueprint].Count;
            }
        }

        public bool RemoveFromStorage(Item item)
        {
            if (item == null || !stock.ContainsKey(item.Blueprint))
            {
                return false;
            }
            
            stock[item.Blueprint].Remove(item);

            if (stock[item.Blueprint].Count == 0)
            {
                stock.Remove(item.Blueprint);
            }
            return true;
        }

        public bool IsItemInStorage(Blueprint blueprint, int quantity=1)
        {
            if (!stock.ContainsKey(blueprint)){
                return false;
            }

            return stock[blueprint].Count >= quantity;
        }

        public Item GetItemFromStorage(Blueprint blueprint)
        {
            if (stock.ContainsKey(blueprint))
            {
                List<Item> items = stock[blueprint];

                if (items.Count > 0)
                {
                    Item item = items[0];
                    return item;
                }
            }
            
            return null;
        }

        public void PrintStorage()
        {
            Console.WriteLine();
            Console.WriteLine("Items on stock: ");
            foreach(var item in stock)
            {
                Console.WriteLine($"  - {item.Value.Count}x {item.Key.Name}");
            }
            Console.WriteLine();
        }
    }
}