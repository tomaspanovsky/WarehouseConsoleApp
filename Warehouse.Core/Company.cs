namespace Warehouse
{
    public class Company
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Budget { get; private set; }
        public decimal Profit { get { return Income - Outcome; } }
        public List<Order> FinishedOrders {get; private set;} = new();

        public Dictionary<string, Blueprint> Blueprints { get; private set; }
    
        public decimal Income {get; private set; }
        public decimal Outcome {get; private set; }

        public Production Production { get; private set; }

        public Storage Storage { get; private set; }

        public Shop Shop {get; private set;}

        internal Company(string name, decimal budget, string description = "")
        {
            Name = name;
            Budget = budget;
            Description = description;
            Income = 0;
            Outcome = 0;
            Storage = new Storage();
            Production = new Production(Storage);
            Shop = new Shop(this, Storage);
        }

        internal void SetBlueprints(Dictionary<string, Blueprint> blueprints)
        {
            Blueprints = blueprints;
        }

        public override string ToString()
        {
            return $"Company name: {Name}\nDescription: {Description}";
        }

        public void ProcessIncome(decimal income)
        {
            Income = Income + income;
            Budget = Budget + income;
        }

        public void ProcessOutcome(decimal outcome)
        {
            Outcome = Outcome + outcome;
            Budget = Budget - outcome;
        }

        public void PrintMoneyResults()
        {
            Console.WriteLine();
            Console.WriteLine($"Company Budget: {Budget} Kč");
            Console.WriteLine($"Income: {Income} Kč");
            Console.WriteLine($"Outcome: {Outcome} Kč");
            Console.WriteLine($"Profit: {Profit} Kč");
        }

        public void PrintBlueprints()
        {   
            Console.WriteLine();
            Console.WriteLine($"Blueprints of company {Name}:");

            foreach(var blueprint in Blueprints)
            {
                Console.WriteLine($"  - {blueprint.Key}");
            }
        } 
    }
}