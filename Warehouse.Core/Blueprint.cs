namespace Warehouse
{

    public class Blueprint
    {
        public string Name { get; private set; }
        public Dictionary<Blueprint, int> Components { get; set; } = new Dictionary<Blueprint, int>();    
        public decimal Price { get; private set; }
        public bool CanBeCrafted { get; private set;}

        internal Blueprint(string name, decimal price, bool canBeCrafted)
        {
            Name = name;
            Price = price;
            CanBeCrafted = canBeCrafted;
        }

        public void AddComponents(Dictionary<Blueprint, int> subComponents)
        {
            foreach((Blueprint component, int quantity) in subComponents)
            {
                if (!Components.ContainsKey(component))
                {
                    Components[component] = quantity;
                }
                else
                {
                    Components[component] = Components[component] + quantity;
                }   
            }
        }

        public void PrintBlueprint()
        {
            Console.WriteLine();
            Console.WriteLine($"Recipe for: {Name}, Price: {Price} Kč");
            
            if (!this.HasRecipe())
            {
                Console.WriteLine("  - No subcomponents");
                return;
            }

            Console.WriteLine("Composition:");
            foreach (var component in Components)
            {
                Console.WriteLine($"  - {component.Value}x {component.Key.Name} (Price: {component.Key.Price} Kč)");
            }
            
            Console.WriteLine();
        }

        public bool HasRecipe()
        {
            return Components.Count > 0;
        }
    }
}

