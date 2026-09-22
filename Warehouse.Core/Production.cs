using System.ComponentModel;

namespace Warehouse
{
    public class Production
    {
        private Storage _storage;
        internal Production(Storage storage)
        {
            _storage = storage;
        }

        public void CraftItem(Blueprint blueprint, int quantity = 1)
        {

            if (!blueprint.HasRecipe())
            {
                Console.WriteLine($"Item {blueprint.Name} is cannot be crafted, because it's a basic item.");
                return;
            }

            foreach(var component in blueprint.Components)
            {
                if (!_storage.IsItemInStorage(component.Key, (component.Value * quantity)))
                {
                    Console.WriteLine($"Item {blueprint.Name} is cannot be crafted, because is not enough {component.Key.Name} on storage.");
                    return;
                }
            }
            
            for (int i = 0; i < quantity; i++)
            {
                foreach(var component in blueprint.Components)
                    {
                        for(int j = 0; j < component.Value; j++)
                        {
                            Item item = _storage.GetItemFromStorage(component.Key);
                            _storage.RemoveFromStorage(item);
                        }
                    }
                
                Item newItem = new Item(blueprint);
                _storage.AddToStorage(newItem);
            }
            
            Console.WriteLine($"Item {blueprint.Name} {quantity}x successfully crafted.");
        }  
    }
}