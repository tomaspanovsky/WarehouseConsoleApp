namespace Warehouse
{
    public class Order
    {
        private static int _id = 0;
        public int ID {get; private set;}
        public decimal Price { get; private set;} = 0;
        public bool Done { get; set; } = false;
        public Customer Customer;

        public Dictionary<Blueprint, int> Items { get; } = new();

        internal Order(Customer customer, params (Blueprint item, int quantity)[] items)
        {
            ID = ++_id;
            Customer = customer;

            foreach(var orderedItem in items)
            {
                Items[orderedItem.item] = orderedItem.quantity;
                Price = Price + orderedItem.item.Price * orderedItem.quantity;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", Items.Select(item => $"({item.Value}x {item.Key.Name})"));
        }
    }
}
