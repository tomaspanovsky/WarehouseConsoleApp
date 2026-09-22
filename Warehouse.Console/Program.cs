using System;
using Warehouse;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static async Task notInteractive()
    {
        Company KFC = CompanyMaker.CreateKFCCompany();
        KFC.PrintBlueprints();
        
        Customer customer1 = new Customer("Tomas", 500);
        Customer customer2 = new Customer("Lucie", 600);

        customer1.MakeOrder(KFC, (KFC.Blueprints["zinger menu"], 1));
        customer2.MakeOrder(KFC, (KFC.Blueprints["chicken strips 8"], 1));
        
        await KFC.Shop.StartHandleOrders();

        KFC.Storage.PrintStorage();
        KFC.PrintMoneyResults(); 
    }

    public static async Task Main(string[] args)
    {   
        await notInteractive();
    }
}