namespace Warehouse.Tests
{
    public class CustomerTest
    {
        Customer tomas = new Customer("Tomas", 500);

        [Fact]
        public void TestWithdraw()
        {
            decimal tomasMoneyBefore = tomas.Money;

            tomas.WithdrawMoney(500);

            Assert.Equal(tomasMoneyBefore + 500, tomas.Money);
        }
    }
}