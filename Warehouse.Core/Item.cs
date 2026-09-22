using System.Collections.Generic;

namespace Warehouse
{
    public class Item
    {   
        private static int _Id = 0;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price {get; private set; }
        public Blueprint Blueprint {get; private set; }
        internal Item(Blueprint blueprint)
        {
            Id = ++_Id;
            Name = blueprint.Name;
            Price = blueprint.Price;
            Blueprint = blueprint;
        }
    }
}