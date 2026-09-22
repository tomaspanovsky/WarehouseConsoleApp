namespace Warehouse
{
    public class Customer
    {
        public string Name { get; set; }
        public decimal Money { get; private set; }
        public List<Item> BoughtItems { get; private set; } = new();
        

        public Customer(string name, decimal money)
        {
            Name = name;
            Money = money;
        }

        public void MakeOrder(Company company, params (Blueprint item, int quantity)[] items)
        {   

            Order order = new Order(this, items);

            if (Money < order.Price)
                {
                    Console.WriteLine($"Customer {Name} doen't have enought money for this order!");
                    return;
                }
            
            company.Shop.AddOrder(order);
            company.ProcessIncome(order.Price);
            Console.WriteLine($"Customer {Name} ordered {order} for {order.Price} Kč");
        }

        public void GetOrder(List<Item> products)
        {
            foreach(Item product in products)
            {
                BoughtItems.Add(product);
            }
        }

        public void WithdrawMoney(decimal money)
        {
            Money = Money + money;
        }
    }
}