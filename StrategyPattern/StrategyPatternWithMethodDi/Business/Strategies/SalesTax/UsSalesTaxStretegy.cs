using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.SalesTax
{
    class UsSalesTaxStretegy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            decimal tax = 1.20m;
            decimal total = 0;

            foreach (var item in order.LineItems)
            {
                total += item.ItemPrice;
            }

            return total * tax;
        }
    }
}
