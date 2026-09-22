using Warehouse;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Warehouse
{
    public class Shop
    {
        private Company _company;
        private Storage _storage;

        private List<Order> _orders = new();

        public Shop(Company company, Storage storage)
        {
            _company = company;
            _storage = storage;
        }

        public async Task StartHandleOrders()
        {
    
            while (_orders.Count > 0)
            {
                HandleOrders();

                await Task.Delay(50);
            }
        }


        public void BuyItem(Blueprint blueprint, int quantity)
        {
            
            Console.WriteLine();
            
            if (_company.Budget < (blueprint.Price * quantity))
            {
                Console.WriteLine($"Company doesn't have enought money to buy {blueprint.Name} {quantity}x.");
                return;
            }

            for (int i = 0; i < quantity; i++)
            {
                Item item = new Item(blueprint);
                _company.ProcessOutcome(blueprint.Price);
                _storage.AddToStorage(item);
            }
            
            Console.WriteLine($"Succesfully bought {quantity}x {blueprint.Name} for {blueprint.Price * quantity} Kč");
        }

        public void SellItem(Blueprint blueprint, int quantity = 1)
        {
            int soldItems = 0;

            for (int i = 0; i < quantity; i++)
            {
                if (_storage.IsItemInStorage(blueprint))
                {
                    Item item = _storage.GetItemFromStorage(blueprint);
                    _storage.RemoveFromStorage(item);
                    _company.ProcessIncome(blueprint.Price);
                    soldItems++;
                }
                else
                {
                    Console.WriteLine($"No more {blueprint.Name} in storage!");
                    break;
                }  
            }

            if (soldItems > 0)
            {
                Console.WriteLine($"Successfully sold {blueprint.Name}: {quantity}x for {soldItems * blueprint.Price} Kč");
            }
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public void FinishOrder(Order order)
        {
            order.Done = true;
            _company.FinishedOrders.Add(order);
            _orders.Remove(order);
            Console.WriteLine($"Order {order.ID} with items {order} was finnished and cutomer {order.Customer.Name} get it");
        }

        public Order GetOrder()
        {
            if (_orders.Count > 0)
            {
                return _orders[0];
            }

            return null;
        }

        public int OrdersLen()
        {
            return _orders.Count;
        }

        public void HandleOrders()
        {
            List<Item> orderedProducts = new();

            while (_orders.Count > 0)
            {
                Order order = GetOrder();

                foreach(var item in order.Items)
                {
                    if (!_storage.IsItemInStorage(item.Key, item.Value))
                    {
                        HandleIngredients(item.Key, item.Value);

                        if (item.Key.CanBeCrafted)
                        {
                            _company.Production.CraftItem(item.Key, item.Value);
                        }
                        else
                        {
                            BuyItem(item.Key, item.Value);
                        }
                    }

                    for (int i = 0; i < item.Value; i++)
                        {
                            Item product = _storage.GetItemFromStorage(item.Key);
                            _storage.RemoveFromStorage(product);
                            orderedProducts.Add(product);
                        }

                    order.Customer.GetOrder(orderedProducts);
                    orderedProducts.Clear();
                }
                
                FinishOrder(order);
            }
        }

        public void HandleIngredients(Blueprint blueprint, int quantity)
        {
            if (_storage.IsItemInStorage(blueprint, quantity))
            {
                return;
            }
            else
            {
                foreach (var component in blueprint.Components)
                {
                    if (_storage.IsItemInStorage(component.Key, component.Value * quantity))
                    {
                        continue;
                    }
                    else
                    {
                        if (component.Key.CanBeCrafted)
                        {
                            HandleIngredients(component.Key, component.Value * quantity);
                            _company.Production.CraftItem(component.Key, component.Value * quantity);
                        }
                        else
                        {
                            BuyItem(component.Key, component.Value * quantity);
                        } 
                    }
                }
            }
        }
    }
}