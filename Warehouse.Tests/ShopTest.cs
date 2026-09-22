namespace Warehouse.Tests;

public class ShopTest
{
    Company KFC = CompanyMaker.CreateKFCCompany();
    
    [Fact]
    public void TestBuyingItems()
    {
        
        KFC.Shop.BuyItem(KFC.Blueprints["hamburger bun"], 1);

        Assert.Equal(KFC.Profit, -KFC.Blueprints["hamburger bun"].Price);
        Assert.Equal(KFC.Outcome, KFC.Blueprints["hamburger bun"].Price);

        KFC.Shop.BuyItem(KFC.Blueprints["lettuce"], 0);
        Assert.Equal(false, KFC.Storage.IsItemInStorage(KFC.Blueprints["lettuce"]));

        decimal outcome = KFC.Outcome;
        KFC.Shop.BuyItem(KFC.Blueprints["lettuce"], -1);
        Assert.Equal(false, KFC.Storage.IsItemInStorage(KFC.Blueprints["lettuce"]));
        Assert.Equal(KFC.Outcome, outcome);

        KFC.Shop.BuyItem(KFC.Blueprints["lettuce"], 2);
        KFC.Shop.BuyItem(KFC.Blueprints["lettuce"], -1);
        Assert.Equal(2, KFC.Storage.HowManyItemsInStorage(KFC.Blueprints["lettuce"]));
        Assert.Equal(3, KFC.Storage.HowManyItemsInStorage());
    }

    [Fact]
    public void TestOrders()
    {
        
    }
}