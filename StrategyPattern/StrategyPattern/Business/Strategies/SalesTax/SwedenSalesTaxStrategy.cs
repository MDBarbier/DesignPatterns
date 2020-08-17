using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.SalesTax
{
    class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            decimal tax = 0.25m;
            decimal total = 0;

            foreach (var item in order.LineItems)
            {
                total += item.ItemPrice;
            }

            return total / tax;
        }
    }
}
